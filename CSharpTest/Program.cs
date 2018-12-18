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
using CSharpTest.Converter;

namespace CSharpTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ObjectToJson t = new ObjectToJson();
            t.ToJsonSample();
            Console.Read();
        }

        //捕捉非同步的Exception https://dotblogs.com.tw/sean_liao/2018/01/09/taskexceptionshandling
    }
}
