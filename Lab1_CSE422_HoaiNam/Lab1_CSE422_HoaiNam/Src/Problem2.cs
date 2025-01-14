using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1_CSE422_HoaiNam.Src
{
    internal class Problem2
    {
        int dividend1 = 7;
        int divisor1 = -3;

        int dividend2 = 10;
        int divisor2 = 3;

        public void Divided()
        {
            int result1 = DivideCondition(dividend1, divisor1);
            int result2 = DivideCondition(dividend2, divisor2);

            Console.WriteLine($"{dividend1} / {divisor1} = {result1}");
            Console.WriteLine($"{dividend2} / {divisor2} = {result2}");
        }

        private int DivideCondition(int dividend, int divisor)
        {

            int INT_MAX = 2147483647; // 2^31 - 1
            int INT_MIN = -2147483648; // -2^31


            if (divisor == 0)
            {
                throw new DivideByZeroException("Divisor cannot be zero.");
            }


            int result = dividend / divisor;

            if (result > INT_MAX)
            {
                return INT_MAX;
            }
            else if (result < INT_MIN)
            {
                return INT_MIN;
            }

            return result;
        }
    }
}