/// <summary>
/// класс Список, необходимый для таблицы
/// </summary>
namespace HashTable
{
    using System;

    /// <summary>
    /// класс элемент списка
    /// </summary>
    public class ListElement
    {
        /// <summary>
        /// приватное поле: следующий элемент
        /// </summary>
        private ListElement next;

        /// <summary>
        /// приватное поле: значение
        /// </summary>
        private int value;

        /// <summary>
        /// перекрытый метод ToString(), возвращающий значение элемента списка
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Value " + value;
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="next"> следующий элемент </param>
        /// <param name="value"> значение </param>
        public ListElement(ListElement next, int value)
        {
            this.next = next;
            this.value = value;
        }

        /// <summary>
        /// метод, возвращающий следующий элемент
        /// </summary>
        /// <returns></returns>
        public ListElement Next()
        {
            ListElement iterator = this;
            if (iterator != null)
            {
                return iterator.next;
            }
            return null;
        }

        /// <summary>
        /// возвращает значение элемента списка
        /// </summary>
        /// <returns></returns>
        public int Value()
        {
            return value;
        }

        /// <summary>
        /// удаляет следующий элемент за данным, если удаление невозможно, ничего не делает
        /// </summary>
        public void RemoveByReference()
        {
            ListElement position = this;
            if (position != null && position.next != null)
            {
                position.next = position.next.next;
            }
        }
    }

    /// <summary>
    /// Класс Список
    /// </summary>
    public class List
    {
        /// <summary>
        /// свойство: длина списка
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// голова списка
        /// </summary>
        public ListElement Head { get { return head; } private set { } }

        /// <summary>
        /// вспомогательное поле для свойства Head
        /// </summary>
        private ListElement head;

        // конструктор списка
        public List()
        {
            head = null;
            Length = 0;
        }

        //печатает список, выводя каждое значение на своей строке
        public void Print()
        {
            ListElement iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value());
                iterator = iterator.Next();
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
            head = head.Next();
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
            int value = head.Value();
            head = head.Next();
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
            return head.Value();
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
                if (iterator.Value() == value)
                {
                    return true;
                }
                iterator = iterator.Next();
            }
            return false;
        }

        /// <summary>
        /// проверяет на пустоту
        /// </summary>
        /// <returns></returns>
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
