using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTest
{
    class AsyncSample_SimpleTask
    {
        public void Sim_Task()
        {
            Task<int> task = Task.Run(() => Enumerable.Range(1, 5000).Count(n => (n % 3) == 0));
            task.ContinueWith(c => {
                int result = task.Result;
                Console.WriteLine("整除3的有:" + task.Result);
            });
            Console.WriteLine("Task 執行中...");
        }
    }
    class AsyncSample_Factory
    {
        //模擬Controller或外部調用
        public async void Sim_BtnClick()
        {
            //取得目標資料夾中所有符合條件的所有檔案
            //showInfo.AppendText("開始處理" +  " ... ");
            for (int i = 0; i < 10; i++)
            {
                //showInfo.AppendText("開始處理 run " + (i + 1) + " ...");
                Console.WriteLine("開始處理 run " + (i + 1) + " ...");
                string str = await DoWork(); //在想等待的位置放上
                Console.WriteLine(str);
                //showInfo.AppendText(str);
                Console.WriteLine("完成" + (i+1) * 10 + "%");
                //ProgressStatus.Value += 10;
            }
        }

        //建立TaskFactory
        private Task<string> DoWork() //命名可以隨意，只要跟有async的「button_Click」中的await相呼應就好
        {
            return Task.Factory.StartNew(() => this.DoingDetail("放參數的地方"));
        }

        //模擬花費時間的運算
        private string DoingDetail(string para1)
        {
            //...放要執行的程式段...
            Thread.Sleep(5000); //比如說這段

            return "執行完成時要回傳的訊息\r\n";
        }
    }
   
}
