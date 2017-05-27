using System;

namespace Krka2
{
    public class GameInit
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int[,] InitalizeArray(int n)
        {
            var arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = ((i + 1) * (j + 1)) % (n * n / 2);
                }
            }
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int step = rand.Next(2);
                    int i1 = (i + step) % n;
                    int j1 = (j + step) % n;
                    Swap(ref arr[i, j], ref arr[i1, j1]);
                }
            }
            return arr;
        }
    }
}
