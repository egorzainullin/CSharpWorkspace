using System;

namespace QueueP
{
    public class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueuePrior();
            queue.Enqueue(1, 1);
            queue.Enqueue(3, 3);
            queue.Enqueue(2, 2);
            queue.Enqueue(4, 4);
            Console.WriteLine(queue.Length);
            Console.WriteLine(queue.Dequeue());
        }
    }
}
