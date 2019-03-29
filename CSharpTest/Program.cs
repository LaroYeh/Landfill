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
using CSharpTest.Codewars;

namespace CSharpTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            float[] values = Enumerable.Range(0, 100).Select(i => (float)i / 10).ToArray();
            System.Diagnostics.Debugger.Break();

            UsingDebuggerClass.UsingDebugger();
            string input = Console.ReadLine();
            var output = kyu5_52e88b39ffb6ac53a400022e.UInt32ToIP(2149583361);
            Console.WriteLine(output);
            Console.Read();
        }

        //捕捉非同步的Exception https://dotblogs.com.tw/sean_liao/2018/01/09/taskexceptionshandling
    }
}
