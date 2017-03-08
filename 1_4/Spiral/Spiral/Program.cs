using System;

namespace Spiral
{
    class Program
    {
        public static void SpiralOut(int[,] matrix)
        {
            int width = matrix.GetLength(1);
            int plusToRow = 1;
            int plusToColumn = 1;
            int currentRow = width / 2;
            int currentColumn = width / 2;
            Console.WriteLine(matrix[currentRow, currentColumn]);
            while (currentColumn != width - 1 || currentRow != 0)
            {
                if (currentRow == 0)
                {
                    for (int i = 0; i < width - 1; i++)
                    {
                        ++currentColumn;
                        Console.WriteLine(matrix[currentRow, currentColumn]);
                    }
                    break;
                }
                for (int i = 0; i < plusToColumn; i++)
                {
                    ++currentColumn;
                    Console.WriteLine(matrix[currentRow, currentColumn]);
                }
                for (int i = 0; i < plusToRow; i++)
                {
                    ++currentRow;
                    Console.WriteLine(matrix[currentRow, currentColumn]);
                }
                ++plusToColumn;
                ++plusToRow;
                for (int i = 0; i < plusToColumn; i++)
                {
                    --currentColumn;
                    Console.WriteLine(matrix[currentRow, currentColumn]);
                } 
                for (int i = 0; i < plusToRow; ++i)
                {
                    --currentRow;
                    Console.WriteLine(matrix[currentRow, currentColumn]);
                }
                ++plusToColumn;
                ++plusToRow;
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            SpiralOut(arr);
        }
    }
}
