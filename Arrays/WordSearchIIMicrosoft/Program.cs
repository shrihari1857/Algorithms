using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearchIIMicrosoft
{
    class Program
    {
        public static List<string> collection = new List<string>();
        public static int[,] directions = new int[,] { { 0, 1}, { 0, -1 }, { 1, 0 }, { -1, 0 }};
        static void Main(string[] args)
        {
            var words = new List<string> { "oath", "pea", "eat", "rain" };
            var board = new char[,]
            {
                {'o', 'a', 'a', 'n'},
                {'e', 't', 'a', 'e'},
                {'i', 'h', 'k', 'r'},
                {'i', 'f', 'l', 'v'}
            };
            foreach (var word in words)
            {
                WordSearch(board, word, 0, 0, 0);
            }
        }

        public static void WordSearch(char[,] board, string word, int index, int row, int col)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(word[0] == board[i, j] && DFS(board, word, index, i, j))
                    {
                        collection.Add(word);
                        return;
                    }
                }
            }
        }

        private static bool DFS(char[,] board, string word, int index, int row, int col)
        {
            if (index >= word.Length)
                return true;

            if (row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1))
                return false;

            if (word[index] == board[row, col])
            {
                for (int k = 0; k < directions.GetLength(0); k++)
                {
                    if (DFS(board, word, index + 1, row + directions[k, 0], col + directions[k, 1]))
                        return true;
                } 
            }

            return false;
        }
    }
}
