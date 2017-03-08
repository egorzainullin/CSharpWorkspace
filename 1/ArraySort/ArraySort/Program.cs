using System;

namespace ArraySort
{
    class Program
    {
        public static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.WriteLine(element);
            }
        }

        public static void PrintMatrix(int [,] matrix)
        {
            int rowLength = matrix.GetLength(1);
            int columnLength = matrix.GetLength(0);
            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void ArraySort(int[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length; ++i)
            {
                int min = i;
                for (int j = i + 1; j < length; ++j)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void MatrixSort(int[,] matrix)
        {
            int rowLength = matrix.GetLength(1);
            int columnLength = matrix.GetLength(0);
            for (int i = 0; i < rowLength; ++i)
            {
                int min = i;
                for (int j = i + 1; j < rowLength; ++j)
                {
                    if (matrix[0, min] > matrix[0, j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    for (int k = 0; k < columnLength; k++)
                    {
                        int temp = matrix[k, min];
                        matrix[k, min] = matrix[k, i];
                        matrix[k, i] = temp;
                    }
                }
            }
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSorted(int[,] matrix)
        {
            int rowLength = matrix.GetLength(1);
            for (int i = 1; i < rowLength; i++)
            {
                if (matrix[0, i] < matrix[0, i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[] arr = { 2, 0, 3, 5, 4 };
            int[,] matrix = { { 2, 0, 3, 5, 4 }, { 2, 1, 4, 5, 6 } };
            ArraySort(arr);
            PrintArray(arr);
            Console.WriteLine(IsSorted(arr));
            MatrixSort(matrix);
            PrintMatrix(matrix);
            Console.WriteLine(IsSorted(arr));
        }
    }
}
