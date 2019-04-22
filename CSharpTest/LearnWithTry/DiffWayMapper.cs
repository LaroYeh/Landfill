using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;
using AutoMapper;
namespace CSharpTest.LearnWithTry
{
    class DiffWayMapper
    {
        public static void GetName()
        {
            var unitA = new Status() { HP = 10, MP = 10 };
            Console.WriteLine("");

            #region 取得Status的自訂Display
            //取得Status的自訂Display
            foreach (var p in typeof(Status).GetProperties())
            {
                var msg = string.Empty;
                MemberInfo property = typeof(Status).GetProperty(p.Name);
                var displayAttr = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                msg = p.Name + " -> " + displayAttr.Name;
                Console.WriteLine(msg);
            }
            #endregion

            #region Way1.讓ViewModelE繼承Model
            Console.WriteLine("【Way1】");
            //手動映射
            var unit1 = new ViewModelW() {
                HP = unitA.HP,
                MP = unitA.MP,
            };
            #region 取得Status的自訂Display
            //取得Status的自訂Display
            foreach (var p in typeof(ViewModelW).GetProperties())
            {
                var msg = string.Empty;
                MemberInfo property = typeof(ViewModelW).GetProperty(p.Name);
                var displayAttr = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                msg = p.Name + " -> " + displayAttr.Name;
                Console.WriteLine(msg);
            }
            #endregion

            //AutoMapper
            //每個版本(7.0)寫法都不太一樣，詳見官方說明: http://docs.automapper.org/en/stable/Getting-started.html
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Status, ViewModelW>());
            var mapper = config.CreateMapper();
            var unit1_AutoMapper = mapper.Map<ViewModelW>(unitA);

            #region 取得Status的自訂Display
            //取得Status的自訂Display
            foreach (var p in typeof(ViewModelW).GetProperties())
            {
                var msg = string.Empty;
                MemberInfo property = typeof(ViewModelW).GetProperty(p.Name);
                var displayAttr = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                msg = p.Name + " -> " + displayAttr.Name;
                Console.WriteLine(msg);
            }
            #endregion
            #endregion

            #region Way2.直接將Model加到ViewModelE中
            Console.WriteLine("【Way2】");
            var unit2 = new ViewModelE() { status = unitA};
            unit2.status = unitA;
            #region 取得Status的自訂Display
            foreach (var p in typeof(ViewModelE).GetProperties())
            {
                var msg = string.Empty;
                MemberInfo property = typeof(ViewModelE).GetProperty(p.Name);
                var displayAttr = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

                if (displayAttr != null)
                {
                    msg = p.Name + " -> " + displayAttr.Name;
                    Console.WriteLine(msg);
                }
            }
            #endregion
            #endregion
        }

        class ViewModelW : Status
        {
            [Display(Name = "體力")]
            public int HP { get; set; }
            [Display(Name = "法力")]
            public int MP { get; set; }
        }
        class ViewModelE
        {
            [Display(Name = "生命")]
            public int HP { get { return status.HP; } }
            [Display(Name = "魔力")]
            public int MP { get { return status.MP; } }
            public Status status { get; set; }
        }
        class Status
        {
            [Display(Name = "生命值")]
            public int HP { get; set; }
            [Display(Name = "魔力值")]
            public int MP { get; set; }
        }
    }
}

//取得屬性的方法參考
//https://stackoverflow.com/questions/32808132/how-to-get-the-value-in-displayname-attribute-in-controller-for-any-prope
//https://docs.microsoft.com/zh-tw/dotnet/api/system.attribute.isdefined?view=netframework-4.8