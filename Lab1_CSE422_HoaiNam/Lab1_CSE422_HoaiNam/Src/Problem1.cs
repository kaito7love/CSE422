using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSE422_HoaiNam.Src
{
    internal class Problem1
    {
        int[] array1 = { 3, 2, 5 };
        int[] array2 = { 6, 1, 4 };
        public Problem1()
        {
        }

        public void FindMedian()
        {
            //// Read first array input from user
            //Console.WriteLine("Enter the first array of numbers (comma-separated):");
            //string input1 = Console.ReadLine();
            //int[] nums1 = input1.Split(',').Select(int.Parse).ToArray();

            //// Read second array input from user
            //Console.WriteLine("Enter the second array of numbers (comma-separated):");
            //string input2 = Console.ReadLine();
            //int[] nums2 = input2.Split(',').Select(int.Parse).ToArray();

            int[] combined = array1.Concat(array2).OrderBy(x => x).ToArray();

            int maxLength = combined.Length;
            double median = 0;
            if (maxLength % 2 == 0)
            {
                median = (combined[maxLength / 2 - 1] + combined[maxLength / 2]) / 2.0;
            }
            else
            {
                median = combined[maxLength / 2];
            }

            Console.WriteLine(string.Join(", ", combined));
            Console.WriteLine(string.Join(", ", median));
        }
    }
}
