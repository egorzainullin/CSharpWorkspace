/// <summary>
/// класс Список
/// </summary>
namespace StackList
{
    using System;

    /// <summary>
    /// Класс Список
    /// </summary>
    public class List<T>
    {
        /// <summary>
        /// Класс элемент списка
        /// </summary>
        private class ListElement<T>
        {
            /// <summary>
            /// Конструктор, создающий новый экземпляр класса <see cref="ListElement"/>
            /// </summary>
            /// <param name="next"> Следующий элемент </param>
            /// <param name="value"> Значение </param>
            public ListElement(ListElement<T> next, T value)
            {
                this.Next = next;
                this.Value = value;
            }

            /// <summary>
            /// Следующий элемент списка
            /// </summary>
            public ListElement<T> Next { get; private set; }

            /// <summary>
            /// Значение элемента списка
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Удаляет следующий элемент за данным, если удаление невозможно, ничего не делает
            /// </summary>
            public void RemoveByReference()
            {
                if (Next != null)
                {
                    Next = Next.Next;
                }
            }
        }

        /// <summary>
        /// Длина списка
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// голова списка
        /// </summary>
        private ListElement<T> head;

        /// <summary>
        /// Печатает список, выводя каждое значение на своей строке
        /// </summary>
        public void Print()
        {
            ListElement<T> iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value);
                iterator = iterator.Next;
            }
        }

        /// <summary>
        /// Добавляет значение в список
        /// </summary>
        /// <param name="value">значение</param>
        public void Add(T value)
        {
            ListElement<T> newElement = new ListElement<T>(head, value);
            head = newElement;
            ++Length;
        }

        /// <summary>
        /// Удаляет элемент из головы списка
        /// </summary>
        public void DeleteFromHead()
        {
            if (head == null)
            {
                return;
            }
            head = head.Next;
            --Length;
        }

        /// <summary>
        /// Достает значение из головы, удаляет его из списка
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }
            T value = head.Value;
            head = head.Next;
            --Length;
            return value;
        }

        /// <summary>
        /// Очищает список
        /// </summary>
        public void Clear() => head = null;

        /// <summary>
        /// Достает значение из головы
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }
            return head.Value;
        }

        /// <summary>
        /// Проверят на принадлежность
        /// </summary>
        /// <param name="value">Значение, которое надо проверить на принадлежность</param>
        /// <returns></returns>
        public bool IsContaining(T value)
        {
            ListElement<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Value.Equals(value))
                {
                    return true;
                }
                iterator = iterator.Next;
            }
            return false;
        }

        /// <summary>
        /// Проверяет на пустоту
        /// </summary>
        public bool IsEmpty() => head == null;
        
        /// <summary>
        /// Удаляет все элементы из списка по значению
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            while (head != null && head.Value.Equals(value))
            {
                DeleteFromHead();
            }
            ListElement<T> iterator = head;
            while (iterator != null)
            {
                while (iterator != null && iterator.Next != null && iterator.Next.Value.Equals(value))
                {
                    iterator.RemoveByReference();
                    --Length;
                }
                iterator = iterator.Next;
            }
        }
    }
}
