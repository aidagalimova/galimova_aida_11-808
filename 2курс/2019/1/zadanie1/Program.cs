using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.pinterest.ru";
            string html = GetHTMLPage(url);
            var urls = ParseImageUrl(html, url);
            int i = 0;
            foreach (var u in urls)
            {
                var t = u.Split('.');
                var filename = i.ToString() + "." + t[t.Length - 1];
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

        public static List<string> ParseImageUrl(string html, string url)
        {
            var result = new List<string>();
            string pattern = @"(https?:)?//?[^'""<>]+?\.(jpg|jpeg|gif|png)";
            foreach (Match match in Regex.Matches(html, pattern, RegexOptions.IgnoreCase))
            {
                var pictures = match.Value.Split('\n');
                foreach (var p in pictures)
                {
                    if (!result.Contains(p) && !result.Contains(url + p))
                    {
                        if (p.StartsWith("/"))
                        {
                            result.Add(url + p);
                        }
                        else
                        {
                            result.Add(p);
                        }
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
                client.DownloadFile(new Uri(url), filename);
            }
            catch
            {
                Console.WriteLine("Ошибка404");
            }
        }
    }
}