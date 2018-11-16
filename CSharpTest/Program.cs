using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using CSharpTest.LearnWithTry;
using CSharpTest.Net;


namespace CSharpTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var test = new HttpClientSample();
                test.SendRequest("https://http2.github.io");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        //捕捉非同步的Exception https://dotblogs.com.tw/sean_liao/2018/01/09/taskexceptionshandling
    }
}
