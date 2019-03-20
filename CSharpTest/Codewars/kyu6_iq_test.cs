/*
https://www.codewars.com/kata/iq-test/train/csharp

Bob is preparing to pass IQ test. The most frequent task in this test is to find out which one of the given numbers differs from the others. Bob observed that one number usually differs from the others in evenness. Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, and return a position of this number.

! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)

##Examples :
IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even
IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Codewars
{
    class kyu6_iq_test
    {
        public static int Test1(string numbers)
        {
            int idx = 1;
            var num = from a in numbers.Split(' ') select Convert.ToInt32(a);
            var even = from e in num.Take(3) where e % 2 == 0 select e;
            var remainder = Convert.ToInt32(even.Count() > 1);
            foreach (var n in num)
            {
                if (n % 2 == remainder) { break; }
                idx++;
            }
            return idx;
        }
    }
}
