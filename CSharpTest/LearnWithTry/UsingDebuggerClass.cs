using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpTest.LearnWithTry
{
    class UsingDebuggerClass
    {
        public static void UsingDebugger()
        {
            if (Debugger.IsAttached) //判斷是否有Attached
            {
                uint ip = 32;
                var test = string.Join(".", (new int[] { 24, 16, 8, 0 }).Select(e => ip >> e & 255));

                Debugger.Break(); //中斷點

            }
        }

    }
}

//Reference
//Debugger Class https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debugger?view=netframework-4.7.2
//Support for debugging lambda expressions with Visual Studio 2015 https://devblogs.microsoft.com/devops/support-for-debugging-lambda-expressions-with-visual-studio-2015/
//https://www.red-gate.com/simple-talk/dotnet/.net-framework/linq-secrets-revealed-chaining-and-debugging/
//https://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2049821-debug-lambda-expressions
