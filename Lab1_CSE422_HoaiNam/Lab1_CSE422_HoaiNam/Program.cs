using Lab1_CSE422_HoaiNam.Src;
using System;

class Program
{
    static void Main()
    {
        Problem1 problem1 = new Problem1();
        //problem1.FindMedian();
        Problem2 problem2 = new Problem2();
        
        // Problem 2: Divide Two Integers
        Console.WriteLine("Problem 2");
        problem2.Divided(); // Output: 3


        char[][] board = new char[][]
           {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
           };

        string word = "ABCCED";

        char[][] board2 = new char[][]
         {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'D', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
         };

        string word2 = "ABCCED";

        Problem3 WordSearch = new Problem3();
        bool result = WordSearch.Exist(board, word);
        bool result2 = WordSearch.Exist(board2, word2);

        Console.WriteLine($"Word '{word}' exists in the grid: {result}");
        Console.WriteLine($"Word '{word2}' exists in the grid: {result2}");

    }
}
