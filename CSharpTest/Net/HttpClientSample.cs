/// 參考資料
/// HTTP Get and Post request in C#.net：https://www.youtube.com/watch?v=EPSjxg4Rzs8
/// MSDN：https://docs.microsoft.com/zh-tw/windows/uwp/networking/httpclient
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace CSharpTest.Net
{
    class HttpClientSample
    {
        public async void SendRequest(string url) {
            using (var client = new HttpClient())
            {
                //無法處理使用SSL加密的傳輸
                //待參考此處改寫https://dotblogs.com.tw/bob1440/archive/2012/01/09/65041.aspx
                HttpResponseMessage response = await client.GetAsync(url);
                Console.WriteLine(response.IsSuccessStatusCode);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Headers);
                Console.WriteLine(response.Version);
                Console.WriteLine(response.Content);
                Console.WriteLine(response.ReasonPhrase);
                Console.WriteLine(response.EnsureSuccessStatusCode());
            }
        }
        public async void SendResponse() { }
    }
}
