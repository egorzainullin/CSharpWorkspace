using System;

namespace StackList
{
    public class Stack
    {
        public int Length { get; private set; }

        private class StackElement
        {
            public StackElement next;

            public int value;

            public StackElement(StackElement next, int value)
            {
                this.next = next;
                this.value = value;
            }
        }
        private StackElement head;

        public Stack()
        {
            head = null;
            Length = 0;
        }

        public void Push(int value)
        {
            StackElement newElement = new StackElement(head, value);
            head = newElement;
            ++Length;
        }

        public int Pop()
        {
            if (head == null)
            {
                return 0;
            }
            int value = head.value;
            head = head.next;
            --Length;
            return value;
        }

        public int Peek()
        {
            if (head == null)
            {
                return 0;
            }
            return head.value;
        }

        public void Print()
        {
            StackElement iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.value);
                iterator = iterator.next;
            }
        }
    }
}
