using System;

namespace StackList
{
    public class ListElement
    {
        private ListElement next;

        private int value;

        public override string ToString()
        {
            return "Value " + value;
        }

        public ListElement(ListElement next, int value)
        {
            this.next = next;
            this.value = value;
        }

        public ListElement Next()
        {
            ListElement iterator = this;
            if (iterator != null)
            {
                return iterator.next;
            }
            return null;
        }

        public int Value()
        {
            return value;
        }

        public void RemoveByReference()
        {
            ListElement position = this;
            if (position != null && position.next != null)
            {
                position.next = position.next.next;
            }
        }
    }

    public class List
    {
        public int Length { get; private set; }

        public ListElement Head { get { return head; } private set { } }

        private ListElement head;

        public List()
        {
            head = null;
            Length = 0;
        }

        public void Print()
        {
            ListElement iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value());
                iterator = iterator.Next();
            }
        }

        public void Add(int value)
        {
            ListElement newElement = new ListElement(head, value);
            head = newElement;
            ++Length;
        }

        public void DeleteFromHead()
        {
            if (head == null)
            {
                return;
            }
            head = head.Next();
            --Length;
        }

        public int Pop()
        {
            if (head == null)
            {
                return 0;
            }
            int value = head.Value();
            head = head.Next();
            --Length;
            return value;
        }

        public void Clear()
        {
            while (head != null)
            {
                DeleteFromHead();
            }
        }

        public int Peek()
        {
            if (head == null)
            {
                return 0;
            }
            return head.Value();
        }

        public bool IsContains(int value)
        {
            ListElement iterator = head;
            while (iterator != null)
            {
                if (iterator.Value() == value)
                {
                    return true;
                }
                iterator = iterator.Next();
            }
            return false;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void Remove(int value)
        {
            while (head != null && head.Value() == value)
            {
                DeleteFromHead();
            }
            ListElement iterator = head;
            while (iterator != null)
            {
                while (iterator != null && iterator.Next() != null && iterator.Next().Value() == value)
                {
                    iterator.RemoveByReference();
                    --Length;
                }
                iterator = iterator.Next();
            }
        }
    }
}
