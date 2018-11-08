using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace CSharpTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AsyncSample_SimpleTask a = new AsyncSample_SimpleTask();
            a.Sim_Task();
            AsyncSample_Factory ASF = new AsyncSample_Factory();
            ASF.Sim_BtnClick();
            Console.Read();
        }
    }
}
