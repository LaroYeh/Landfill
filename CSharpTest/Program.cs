﻿using System;
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
            string input = Console.ReadLine();


            //string output = kyu4_52742f58faf5485cae000b9a.HumanTimeFormat.formatDuration(Convert.ToInt32(input));

            int output = kyu6_iq_test.Test("1 2 3");

            Console.WriteLine(output);
            Console.Read();
        }

        //捕捉非同步的Exception https://dotblogs.com.tw/sean_liao/2018/01/09/taskexceptionshandling
    }
}
