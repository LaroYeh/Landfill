using System;
using System.Windows;
using System.Windows.Shapes;
using System.IO;
using System.Threading.Tasks;

using SelectPdf; //轉PDF用
using System.Threading; //延遲用


namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public Task<string> DoWork() //命名可以隨意，只要跟有async的「button_Click」中的await相呼應就好
        {
            return Task.Factory.StartNew(() => this.DoingDetail("放參數的地方"));
        }

        private string DoingDetail(string para1) {
            //...放要執行的程式段...
            Thread.Sleep(5000); //比如說這段

            return "執行完成時要回傳的訊息\r\n";
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //取得目標資料夾中所有符合條件的所有檔案
            //showInfo.AppendText("開始處理" +  " ... ");
            for (int i = 0; i < 10; i++)
            {
                showInfo.AppendText("開始處理 run " + (i + 1) + " ...");
                string str = await DoWork(); //在想等待的位置放上
                showInfo.AppendText(str);
                ProgressStatus.Value += 10;
            }
            //取得目標資料夾中所有符合條件的所有檔案
            String FilesDir = DirPath.Text;
 
            
        }

        private void ConvertPDF_Click(object sender, RoutedEventArgs e)
        {
            PechkinHtmlToPdf ptp = new PechkinHtmlToPdf();
            ptp.PechkinMultiConvert(DirPath.Text);
        }
    }
}
