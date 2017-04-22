/// <summary>
/// класс Список
/// </summary>
namespace StackList
{
    using System;
    using System.Collections;

    /// <summary>
    /// Класс Список
    /// </summary>
    public class List<T> : IEnumerable
    {
        /// <summary>
        /// Класс элемент списка
        /// </summary>
        private class ListElement<T1>
        {
            /// <summary>
            /// Конструктор, создающий новый экземпляр класса <see cref="ListElement"/>
            /// </summary>
            /// <param name="next"> Следующий элемент </param>
            /// <param name="value"> Значение </param>
            public ListElement(ListElement<T1> next, T1 value)
            {
                this.Next = next;
                this.Value = value;
            }

            /// <summary>
            /// Следующий элемент списка
            /// </summary>
            public ListElement<T1> Next { get; private set; }

            /// <summary>
            /// Значение элемента списка
            /// </summary>
            public T1 Value { get; set; }

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
        /// <exception cref="NullReferenceException" />
        public void DeleteFromHead()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }
            head = head.Next;
            --Length;
        }

        /// <summary>
        /// Достает значение из головы, удаляет его из списка
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException" />
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
        public void Clear()
        {
            head = null;
            Length = 0;
        }

        /// <summary>
        /// Достает значение из головы
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException" />
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

        /// <summary>
        /// Получить энумератор
        /// </summary>
        /// <returns>Возвращает энумератор</returns>
        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        /// <summary>
        /// Класс, реализующий IEnumerator для списка
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        private class ListEnumerator<T1> : IEnumerator
        {
            /// <summary>
            /// Энумератор
            /// </summary>
            private ListElement<T> enumerator;

            /// <summary>
            /// Первый элемент
            /// </summary>
            private ListElement<T> head;

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="ListEnumerator{T1}"/>
            /// </summary>
            /// <param name="list"></param>
            public ListEnumerator(List<T> list)
            {
                head = list.head;
            }

            /// <summary>
            /// Пройдена ли коллекция
            /// </summary>
            private bool isPassed = false;

            /// <summary>
            /// Переключает указатель на следующий элемент коллекции
            /// Возвращает true в случае успешной операции
            /// </summary>
            /// <returns>Возвращает true в случае успешной операции, false, если вся коллекция уже пройдена</returns>
            /// <exception cref="InvalidOperationException" />
            public bool MoveNext()
            {
                if (isPassed)
                {
                    throw new InvalidOperationException("Коллекция уже закончилась");
                }
                if (enumerator == null)
                {
                    enumerator = head;
                    return true;
                }
                enumerator = enumerator.Next;
                if (enumerator == null)
                {
                    isPassed = true;
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Возвращает значение энумератора в данный момент
            /// </summary>
            public Object Current => enumerator.Value;

            /// <summary>
            /// Ставит энумератор в начальную позицию перед первым элементом
            /// </summary>
            public void Reset()
            {
                isPassed = false;
                enumerator = null;
            }
        }
    }
}
