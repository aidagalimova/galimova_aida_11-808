using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Net;
namespace kr
{
    class MyClass
    {
        int postId { get; set; }
        int id { get; set; }
        string name { get; set; }
        string mail { get; set; }
        public string body { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solve();
        }

        public static void Solve()
        {
            string HtmlText = string.Empty;
            string url = "https://jsonplaceholder.typicode.com/comments";
            HttpWebRequest myHttwebrequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();

            List<MyClass> lst = JsonConvert.DeserializeObject<List<MyClass>>(HtmlText);

            int ans = (lst.Where((item, index) => index % 2 == 0)).Sum(a => a.body.Length);

            Console.WriteLine(ans);
        }
    }
}