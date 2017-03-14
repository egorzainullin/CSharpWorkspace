/// <summary>
/// класс Список
/// </summary>
namespace HashTableProject
{
    using System;

    /// <summary>
    /// Класс Список
    /// </summary>
    public class List : IList
    {
        /// <summary>
        /// класс элемент списка
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// перекрытый метод ToString(), возвращающий значение элемента списка
            /// </summary>
            public override string ToString()
            {
                return "Value " + Value;
            }

            /// <summary>
            /// конструктор, создающий новый экземпляр класса <see cref="ListElement"/>
            /// </summary>
            /// <param name="next"> следующий элемент </param>
            /// <param name="value"> значение </param>
            public ListElement(ListElement next, int value)
            {
                this.Next = next;
                this.Value = value;
            }

            /// <summary>
            /// следующий элемент списка
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// значение элемента списка
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// удаляет следующий элемент за данным, если удаление невозможно, ничего не делает
            /// </summary>
            public void RemoveByReference()
            {
                if (this.Next != null)
                {
                    this.Next = this.Next.Next;
                }
            }
        }

        /// <summary>
        /// свойство: длина списка
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// голова списка
        /// </summary>
        private ListElement head;

        /// <summary>
        /// конструктор списка
        /// </summary>
        public List()
        {

        }

        /// <summary>
        /// печатает список, выводя каждое значение на своей строке
        /// </summary>
        public void Print()
        {
            ListElement iterator = head;
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
        public void Add(int value)
        {
            ListElement newElement = new ListElement(head, value);
            head = newElement;
            ++Length;
        }

        /// <summary>
        /// удаляет элемент из головы списка
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
        /// достает значение из головы, удаляет его из списка
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (head == null)
            {
                return 0;
            }
            int value = head.Value;
            head = head.Next;
            --Length;
            return value;
        }

        /// <summary>
        /// очищает список
        /// </summary>
        public void Clear()
        {
            while (head != null)
            {
                DeleteFromHead();
            }
        }

        /// <summary>
        /// достает значение из головы
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (head == null)
            {
                return 0;
            }
            return head.Value;
        }

        /// <summary>
        /// проверят на принадлежность
        /// </summary>
        /// <param name="value">значение, которое надо проверить на принадлежность</param>
        /// <returns></returns>
        public bool IsContaining(int value)
        {
            ListElement iterator = head;
            while (iterator != null)
            {
                if (iterator.Value == value)
                {
                    return true;
                }
                iterator = iterator.Next;
            }
            return false;
        }

        /// <summary>
        /// проверяет на пустоту
        /// </summary>
        public bool isEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// удаляет все элементы из списка по значению
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            while (head != null && head.Value == value)
            {
                DeleteFromHead();
            }
            ListElement iterator = head;
            while (iterator != null)
            {
                while (iterator != null && iterator.Next != null && iterator.Next.Value == value)
                {
                    iterator.RemoveByReference();
                    --Length;
                }
                iterator = iterator.Next;
            }
        }
    }
}
