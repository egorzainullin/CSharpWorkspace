using System;

namespace StackList
{
    class Program
    {
        public static bool Test1()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            stack.Print();
            Console.WriteLine("====");
            Console.WriteLine(stack.Length);
            Console.WriteLine("====");
            var list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Remove(4);
            list.Print();
            Console.WriteLine("====");
            Console.WriteLine(list.Peek());
            Console.WriteLine(list.Length);
            Console.WriteLine(list.IsContaining(4));
            return stack.Length == 2 && list.Length == 1 && list.Peek() == 3;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Test1());
        }
    }
}
