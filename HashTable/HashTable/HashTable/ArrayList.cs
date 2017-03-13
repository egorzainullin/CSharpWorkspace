using System;

namespace HashTable
{
    public class ArrayList : IList
    {
        public int Length => pointer + 1;

        private int[] arr = new int[1000];

        private int pointer = -1;

        public ArrayList()
        {
       
        }

        public void Add(int value)
        {
            ++pointer;
            arr[pointer] = value;
        }

        public void Clear()
        {
            pointer = -1;
        }

        public void DeleteFromHead()
        {
            --pointer;
        }

        public bool IsContaining(int value)
        {
            for (int i = 0; i <= pointer; i++)
            {
                if (arr[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isEmpty()
        {
            return pointer == -1;
        }

        public int Peek()
        {
            return arr[pointer];
        }

        public int Pop()
        {
            return arr[pointer--];
        }

        public void Print()
        {
            for (int i = 0; i <= pointer; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private void MoveAfterDelete(int elementNumber)
        {
            for (int i = elementNumber; i <= pointer; i++)
            {
                arr[i] = arr[i + 1];
            }
            --pointer;
        }

        public void Remove(int value)
        {
            int i = 0;
            while (i <= pointer)
            {
                while (arr[i] == value)
                {
                    MoveAfterDelete(i);
                }
                ++i;
            }
        }
    }
}
