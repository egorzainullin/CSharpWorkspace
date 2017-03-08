using System;

namespace _1_2_fibonacci
{
    class Program
    {
        static int Fibonacci(int n)
        {
            int fibonacciPreviousPrevious = 1;
            int fibonacciPrevious = 1;
            int fibonacciCurrent = 1;
            for (int i = 2; i < n; ++i)
            {
                fibonacciCurrent = fibonacciPrevious + fibonacciPreviousPrevious;
                fibonacciPreviousPrevious = fibonacciPrevious;
                fibonacciPrevious = fibonacciCurrent;
            }
            return fibonacciCurrent;
        }

        static bool Test1()
        {
            return Fibonacci(9) == 34;
        }

        static void Main(string[] args)
        {
            int n = 0;
            n = Int32.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
            Console.WriteLine(Test1());
        }
    }
}
