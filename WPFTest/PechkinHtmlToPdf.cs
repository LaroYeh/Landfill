using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pechkin;

namespace WPFTest
{
    class PechkinHtmlToPdf
    {
        public void PechkinMultiConvert(string FilesDir)
        {
            //取得目標資料夾中所有符合條件的所有檔案
            string[] FilePath = Directory.GetFiles(FilesDir, "*");

            //開始逐檔將HTML轉PDF
            foreach (var i in FilePath)
            {
                Console.WriteLine("開始從" + i + "\n\r 產生：" + Path.GetFileNameWithoutExtension(i) + ".pdf");

                var config = new GlobalConfig();
                var pechkin = new SimplePechkin(config);
                ObjectConfig oc = new ObjectConfig();
                oc.SetPrintBackground(true).SetLoadImages(true);
                string HTML = ""; //讀入html
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(i))
                    {
                        // Read the stream to a string, and write the string to the console.
                        HTML = sr.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                byte[] pdf = pechkin.Convert(oc,HTML);
                File.WriteAllBytes(FilesDir + @"\" + Path.GetFileNameWithoutExtension(i) + ".pdf", pdf);
                Console.WriteLine(Path.GetFileNameWithoutExtension(i) + ".pdf 轉換完成");
            }
        }
    }
}
