/* "Human readable duration format"
 Your task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

The function must accept a non-negative integer. If it is zero, it just returns "now". Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

It is much easier to understand with an example:

formatDuration(62)    // returns "1 minute and 2 seconds"
formatDuration(3662)  // returns "1 hour, 1 minute and 2 seconds"
For the purpose of this Kata, a year is 365 days and a day is 24 hours.

Note that spaces are important.

Detailed rules
The resulting expression is made of components like 4 seconds, 1 year, etc. In general, a positive integer and one of the valid units of time, separated by a space. The unit of time is used in plural if the integer is greater than 1.

The components are separated by a comma and a space (", "). Except the last component, which is separated by " and ", just like it would be written in English.

A more significant units of time will occur before than a least significant one. Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

Different components have different unit of times. So there is not repeated units like in 5 seconds and 1 second.

A component will not appear at all if its value happens to be zero. Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

A unit of time must be used "as much as possible". It means that the function should not return 61 seconds, but 1 minute and 1 second instead. Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.
 */

using System;
using System.Linq;

//using CSharpTest.Codewars;
//kyu4_52742f58faf5485cae000b9a.HumanTimeFormat.formatDuration(1);

namespace CSharpTest.Codewars
{
    class kyu4_52742f58faf5485cae000b9a
    {
        //Make about 2hr
        public class HumanTimeFormat
        {
            public static string formatDuration(int seconds)
            {
                if (seconds == 0)
                {
                    return "now";
                }
                int[] num = new int[5];
                string[] str = new string[5];
                string msg = string.Empty;
                num[0] = seconds / (60 * 60 * 24 * 365);
                seconds = seconds % (60 * 60 * 24 * 365);
                num[1] = seconds / (60 * 60 * 24);
                seconds = seconds % (60 * 60 * 24);
                num[2] = seconds / (60 * 60);
                seconds = seconds % (60 * 60);
                num[3] = seconds / 60;
                num[4] = seconds % 60;

                //get desc
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i] > 0)
                    {
                        str[i] = num[i] + " " + GetDesc(i, num[i]);
                    }
                }
                msg = String.Join(", ", str.Where(p => !string.IsNullOrEmpty(p)));             

                //replace "," to " and"
                int idx_dock = msg.LastIndexOf(',');

                return idx_dock > 0 ? msg.Substring(0, idx_dock) + msg.Substring(idx_dock).Replace(",", " and") : msg;
            }
            /// <summary>
            /// 轉換描述
            /// </summary>
            /// <param name="t">type</param>
            /// <param name="v">value</param>
            /// <returns></returns>
            public static string GetDesc(int t, int v)
            {
                string m = string.Empty;
                switch (t)
                {
                    case 0:
                        m = "year";
                        break;
                    case 1:
                        m = "day";
                        break;
                    case 2:
                        m = "hour";
                        break;
                    case 3:
                        m = "minute";
                        break;
                    case 4:
                        m = "second";
                        break;
                    default:
                        break;
                }
                if (v > 1)
                {
                    m += "s";
                }
                return m;
            }
        }
    }
}
