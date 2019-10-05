using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bd
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://study.istamendil.info";
            string html = GetHTMLPage(url);
            var urls = ParsePageUrl(html, url);
            int i = 0;
            foreach (var u in urls)
            {
                var filename = i.ToString() + ".html";
                DownloadFile(u, filename);
                Console.WriteLine(u);
                i = i + 1;
            }
        }

        public static string GetHTMLPage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var html = new StringBuilder();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        html.Append(line);
                    }
                }

            }
            response.Close();
            return html.ToString();
        }

        public static List<string> ParsePageUrl(string html, string url)
        {
            var result = new List<string>();
            result.Add(html);
            string pattern = @"(https?:)//[^'""<>]+?\.(com|ru|net)";
            foreach (Match match in Regex.Matches(html, pattern, RegexOptions.IgnoreCase))
            {
                var pages = match.Value.Split('\n');
                foreach (var p in pages)
                {
                    if (!result.Contains(p))
                    {
                        
                            result.Add(p);
                        
                    }
                }
            }
            return result;
        }

        public static void DownloadFile(string url, string filename)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(url, filename);
            }
            catch
            {
                Console.WriteLine("Ошибка404");
            }
        }
    }
}
