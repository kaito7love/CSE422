using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSE422_HoaiNam.Src
{
    internal class Problem3
    {
        public bool Exist(char[][] board, string word)
        {
            int m = board.Length;
            int n = board[0].Length;

            // Iterate through each cell in the board
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Start backtracking from the cell if the first letter matches
                    if (Backtrack(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Backtrack(char[][] board, string word, int i, int j, int index)
        {
            // If the current index matches the length of the word, we have found the word
            if (index == word.Length)
            {
                return true;
            }

            // Check if out of bounds or character doesn't match
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index])
            {
                return false;
            }

            // Temporarily mark the cell as visited by changing it to a special character
            char temp = board[i][j];
            board[i][j] = '#';

            // Explore the four possible directions: up, down, left, right
            bool found = Backtrack(board, word, i + 1, j, index + 1) ||
                         Backtrack(board, word, i - 1, j, index + 1) ||
                         Backtrack(board, word, i, j + 1, index + 1) ||
                         Backtrack(board, word, i, j - 1, index + 1);

            // Restore the cell after exploring
            board[i][j] = temp;

            return found;
        }
    }
}