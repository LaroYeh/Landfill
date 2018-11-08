using System;
using System.IO; //只要牽涉到檔案的存取就不可避的namespace
using SelectPdf; //這就是在NuGet中裝的DLL

namespace CSharpTest
{
    //string DirPath = @"C:\Users\user1\Documents\Visual Studio 2015\Projects\CSharpTest\CSharpTest\TestSample";
    //LazyHtmlToPdf htp = new LazyHtmlToPdf();
    //htp.multiConvert(DirPath);
    class LazyHtmlToPdf
    {
        public void multiConvert(string FilesDir) 
        {
            //取得目標資料夾中所有符合條件的所有檔案
            string[] FilePath = Directory.GetFiles(FilesDir, "*");

            //開始逐檔將HTML轉PDF
            foreach (var i in FilePath)
            {
                Console.WriteLine("開始從"+i+"\n\r 產生："+ Path.GetFileNameWithoutExtension(i) + ".pdf");
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = converter.ConvertUrl(i);
                doc.Save(FilesDir+@"\"+Path.GetFileNameWithoutExtension(i) + ".pdf");
                doc.Close();
                Console.WriteLine(Path.GetFileNameWithoutExtension(i) + ".pdf 轉換完成");
            }
        }
    }
}
