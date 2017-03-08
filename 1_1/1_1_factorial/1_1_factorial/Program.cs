using System;

namespace _1_1_factorial
{
    class Program
    {
        static int Factorial(int n)
        {
            int product = 1;
            for (var i = 1; i <= n; ++i)
            {
                product *= i;
            }
            return product;
        }

        static bool Test1()
        {
            return Factorial(3) == 6;
        }

        static void Main(string[] args)
        {
            int n = 0;
            n = Int32.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
            Console.WriteLine(Test1());
        }
    }
}
