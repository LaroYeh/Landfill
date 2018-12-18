///參考資料
///[.NET] [C#] [JSON.NET] Serialize序列化與Deserialize反序列 https://dotblogs.com.tw/berrynote/2016/08/18/200338
///[C#.net] 產生JSON字串的幾種方式整理 https://dotblogs.com.tw/shadow/2012/08/16/74099
///C# Object To JSON Parser (JSON Serializer) https://www.c-sharpcorner.com/article/object-to-json-converter/
///MSDN - HOW TO：序列化及還原序列化 JSON 資料 https://docs.microsoft.com/zh-tw/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CSharpTest.Converter
{
    class ObjectToJson
    {
        List<object> data;

        public ObjectToJson()
        {

        }
        /// <summary>
        /// Object to JSON
        /// </summary>
        public void ToJsonSample()
        {
            //https://docs.microsoft.com/zh-tw/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data

            List<emp> emps = new List<emp>();
            emps.Add(new emp { Name = "T. Nixon", Position = "System Architect", Office = "Edinburgh", Age = 61, StartDate = "Mon 25th Apr 11", Salary = "$320,800/y" });
            emps.Add(new emp { Name = "G. Winters", Position = "Accountant", Office = "Tokyo", Age = 63, StartDate = "Mon 25th Jul 11", Salary = "$170,750/y" });
            emps.Add(new emp { Name = "A. Cox", Position = "Junior Technical Author", Office = "San Francisco", Age = 66, StartDate = "Mon 12th Jan 09", Salary = "$86,000/y" });
            object data = new { data = emps };
            string json = JsonConvert.SerializeObject(data);
            Console.WriteLine(json);
            
            //object obj = new { data = emps };
            //JsonResult result = new JsonResult() { Data = obj };
        }

        

        private class emp
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public string Office { get; set; }
            public int Age { get; set; }
            public string StartDate { get; set; }
            public string Salary { get; set; }
        }
    }
}
