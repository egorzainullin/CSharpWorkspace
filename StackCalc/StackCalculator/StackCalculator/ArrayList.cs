using System;

namespace StackCalculator
{
    /// <summary>
    /// Список на массивах
    /// </summary>
    public class ArrayList : IStack
    {
        /// <summary>
        /// Длина списка
        /// </summary>
        public int Length => pointer + 1;

        /// <summary>
        /// Вспомогательный массив для хранения элементов списка
        /// </summary>
        private int[] arr = new int[1000];

        /// <summary>
        /// Указатель на последний элемент
        /// </summary>
        private int pointer = -1;
        
        /// <summary>
        /// Добавляет элемент в список
        /// </summary>
        /// <param name="value">Значение, которое необходимо добавить</param>
        public void Add(int value)
        {
            ++pointer;
            arr[pointer] = value;
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            pointer = -1;
        }

        /// <summary>
        /// Удалить элемент из головы
        /// </summary>
        public void DeleteFromHead()
        {
            --pointer;
        }

        /// <summary>
        /// Проверка элемента на принадлежность
        /// </summary>
        /// <param name="value">Значение, которое необходимо проверить на принадлежность</param>
        /// <returns>Возвращает true, если принадлежит</returns>
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
        /// Проверяет список на пустоту
        /// </summary>
        /// <returns>Возвращает true, если пуст</returns>
        public bool IsEmpty()
        {
            return pointer == -1;
        }

        /// <summary>
        /// Возвращает значение из головы
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (pointer == -1)
            {
                throw new EmptyStackException("Попытка взять значение из пустого стека");
            }
            return arr[pointer];
        }

        /// <summary>
        /// Выталкивает элемент из головы
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (pointer == -1)
            {
                throw new EmptyStackException("Попытка взять значение из пустого стека");
            }
            return arr[pointer--];
        }

        /// <summary>
        /// Печатает элементы из списка
        /// </summary>
        public void Print()
        {
            for (int i = 0; i <= pointer; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        /// <summary>
        /// Вспомогательная функция, которая удаляет данный элемент и сдвигает следующие в его сторону
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
        /// Удалить все элементы списка с таким значением
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

        /// <summary>
        /// Реализует интерфейс стека
        /// </summary>
        /// <param name="value">Значение, которое необходимо добавить</param>
        public void Push(int value)
        {
            Add(value);
        }
    }
}
