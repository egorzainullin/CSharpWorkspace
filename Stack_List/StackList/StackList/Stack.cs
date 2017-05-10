using System;

namespace StackList
{
    /// <summary>
    /// Класс Стек
    /// </summary>
    public class Stack<T>
    {
        /// <summary>
        /// Длина стека
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Элемент стека
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Следующий элемент
            /// </summary>
            public StackElement Next => next;

            /// <summary>
            /// Следующий элемент
            /// </summary>
            private StackElement next;

            /// <summary>
            /// Значение
            /// </summary>
            public T Value => value;

            /// <summary>
            /// Значение
            /// </summary>
            private T value;

            public StackElement(StackElement next, T value)
            {
                this.next = next;
                this.value = value;
            }
        }

        /// <summary>
        /// Голова стека
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Добавить значение в стек
        /// </summary>
        /// <param name="value">Значение</param>
        public void Push(T value)
        {
            StackElement newElement = new StackElement(head, value);
            head = newElement;
            ++Length;
        }

        /// <summary>
        /// Достает значение из головы, удаляет его из стека
        /// </summary>
        /// <exception cref="NullReferenceException">Попытка достать значение из пустого стека</exception>
        public T Pop()
        {
            if (head == null)
            {
                throw new NullReferenceException("Стек пуст");
            }
            T value = head.Value;
            head = head.Next;
            --Length;
            return value;
        }

        /// <summary>
        /// Достает значение из головы
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Попытка достать значение из пустого стека</exception>
        public T Peek()
        {
            if (head == null)
            {
                throw new NullReferenceException("Стек пуст");
            }
            return head.Value;
        }

        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        /// <returns>true, если пуст, false, если нет</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Очищает стек
        /// </summary>
        public void Clear()
        {
            head = null;
            Length = 0;
        }
    }
}
