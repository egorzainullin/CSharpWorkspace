using System;

namespace HashTableProject
{
    public class ArrayList : IList
    {
        /// <summary>
        /// длина списка
        /// </summary>
        public int Length => pointer + 1;

        /// <summary>
        /// вспомогательный массив для хранения элементов списка
        /// </summary>
        private int[] arr = new int[1000];

        /// <summary>
        /// указатель на последний элемент
        /// </summary>
        private int pointer = -1;

        /// <summary>
        /// конструктор, создающий новый экземпляр класса <see cref="ArrayList"/>
        /// </summary>
        public ArrayList()
        {
       
        }

        /// <summary>
        /// добавляет элемент в список
        /// </summary>
        /// <param name="value">значение, которое необходимо добавить</param>
        public void Add(int value)
        {
            ++pointer;
            arr[pointer] = value;
        }

        /// <summary>
        /// очистить список
        /// </summary>
        public void Clear()
        {
            pointer = -1;
        }

        /// <summary>
        /// удалить элемент из головы
        /// </summary>
        public void DeleteFromHead()
        {
            --pointer;
        }

        /// <summary>
        /// проверка элемента на принадлежность
        /// </summary>
        /// <param name="value">значение, которое необходимо проверить на принадлежность</param>
        /// <returns>возвращает true, если принадлежит</returns>
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

        /// <summary>
        /// проверяет список на пустоту
        /// </summary>
        /// <returns>возвращает true, если пуст</returns>
        public bool isEmpty()
        {
            return pointer == -1;
        }

        /// <summary>
        /// возвращает значение из головы
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            return arr[pointer];
        }

        /// <summary>
        /// выталкивает элемент из головы
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            return arr[pointer--];
        }

        /// <summary>
        /// печатает элементы из списка
        /// </summary>
        public void Print()
        {
            for (int i = 0; i <= pointer; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        /// <summary>
        /// вспомогательная функция, которая удаляет данный элемент и сдвигает следующие в его сторону
        /// </summary>
        /// <param name="elementNumber">элемент, который необходимо удалить</param>
        private void MoveAfterDelete(int elementNumber)
        {
            for (int i = elementNumber; i <= pointer; i++)
            {
                arr[i] = arr[i + 1];
            }
            --pointer;
        }

        /// <summary>
        /// удалить все элементы списка с таким значением
        /// </summary>
        /// <param name="value">значение, которое необходимо удалить из списка</param>
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
