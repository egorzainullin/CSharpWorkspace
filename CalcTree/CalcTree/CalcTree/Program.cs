using System;

namespace CalcTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcTree = new CalcTree("(* (+ 1 1) 2)");
            Console.WriteLine(calcTree.Calculate());
        }
    }
}
