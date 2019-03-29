using System;
using System.Linq;
using System.Diagnostics;
// https://www.codewars.com/kata/52e88b39ffb6ac53a400022e/train/csharp
//input: kyu5_52e88b39ffb6ac53a400022e.UInt32ToIP(2149583361);
//output: 128.32.10.1 
namespace CSharpTest.Codewars
{
    class kyu5_52e88b39ffb6ac53a400022e
    {
        public static string UInt32ToIP(uint ip)
        {
            string bIp = Convert.ToString(ip, 2).PadLeft(32, '0');
            int[] iIp = new int[4];
            
            for (int i = 0; i<iIp.Length; i++)
            {
                iIp[i] = Convert.ToInt32(bIp.Substring(i* 8, 8), 2);
            }
            return String.Join(".",iIp);
        }
    }
}

// 網路推薦解法
// => string.Join(".",(new int[] {24,16,8,0}).Select(e=> ip >> e & 255));
// https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/and-operator