using System;

namespace CalculationTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcTree = new CalcTree("(* (+ 1 1) 2)");
            Console.WriteLine(calcTree.Calculate());
            Console.WriteLine("===");
            calcTree.Print();
            Console.WriteLine("(* (+ 1 1) 2)");
        }
    }
}
