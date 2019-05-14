using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;
namespace кр
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
        public static async void Solve()
        {
            string baseUrl = "https://jsonplaceholder.typicode.com/comments";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            List<MyClass> lst = JsonConvert.DeserializeObject<List<MyClass>>(data);

                            int ans = 0;
                            for (int i = 0; i < lst.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    ans += lst[i].body.Length;
                                }
                            }
                            Console.WriteLine(ans);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }
        static void Main(string[] args)
        {
            Solve();
        }
    }
}