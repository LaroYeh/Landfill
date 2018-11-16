///以非同步的方式呼叫同步方法：https://docs.microsoft.com/zh-tw/dotnet/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTest.LearnWithTry
{
    delegate void StrProc(string input); //宣告委派型別
    delegate string StrProcAsync(int time, out int threadId);
    public delegate string AsyncMethodCaller(out int threadId);

    //同步
    class DelegateSample_Animal
    {
        string race;
        public DelegateSample_Animal(string race)
        {
            this.race = race;
        }
        protected internal void Move(string type)
        {
            Console.WriteLine("The {0} {1}", race, type);
        }
    }
    class DelegateSample_Unknown
    {
        public static void Commit(string msg)
        {
            Console.WriteLine("{0}", msg);
        }
    }

    //非同步
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }

    class DelegateSample_AsyncFlowcast
    {
        public int CostTime { get; set; }
        public string CodeName { get; set; }

        public DelegateSample_AsyncFlowcast(string codeName, int costTime)
        {
            CodeName = codeName;
            CostTime = costTime;
        }

        public string Working(out int threadId)
        {
            Console.WriteLine("Begin Work...");
            Thread.Sleep(CostTime);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("{0} wasted {1} sec.", CodeName, CostTime.ToString());
        }
    }
    class DelegateSample_Use
    {
        //使用靜態(Static)方法
        public static void RunSample() {
            StrProc unknownDesc = new StrProc(DelegateSample_Unknown.Commit);
            unknownDesc("Don't know");
        }

        //使用非靜態方法
        public static void RunSample(string race, string move)
        {
            DelegateSample_Animal animal = new DelegateSample_Animal(race);
            StrProc desc = new StrProc(animal.Move);
            desc(move);
        }
    }
    class DelegateSample_UseAsync
    {
        public static void RunSample()
        {
            RunSample("Default",1000);
        }
        public static void RunSample(string name, int time)
        {
            int threadId;
            DelegateSample_AsyncFlowcast daf = new DelegateSample_AsyncFlowcast(name, time);
            AsyncMethodCaller amc = new AsyncMethodCaller(daf.Working);
            IAsyncResult result = amc.BeginInvoke(out threadId, null, null);
            Console.WriteLine("Main thread {0} dose some work.", Thread.CurrentThread.ManagedThreadId);
            string returnValue = amc.EndInvoke(out threadId, result);
            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, returnValue);
        }
    }
}
