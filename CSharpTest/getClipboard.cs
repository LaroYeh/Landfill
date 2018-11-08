using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpTest
{
    /*
        //testEqual();
        getClipboard gc = new getClipboard();
        Console.WriteLine(gc.getDataFormats());
    */
    class GetClipboard
    {
        public string text { get; set; }
        public string getClipboardText() {
            var str = Clipboard.GetText();
            return str;
        }
        public object getDataFormats() {
            var Value = Clipboard.GetDataObject();

            //foreach寫法
            string[] formats = Value.GetFormats();
            //LINQ寫法
            var formatsL = from f in Value.GetFormats()
                           select f;

            string str="";
            foreach (var i in formatsL) {
                str += i.ToString() + ", ";
            }
            return str;
        }
    }
}
