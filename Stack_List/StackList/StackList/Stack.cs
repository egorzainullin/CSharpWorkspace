using System;

namespace StackList
{
    /// <summary>
    /// Класс Стек
    /// </summary>
    public class Stack<T>
    {
        /// <summary>
        /// Длина списка
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Элемент стека
        /// </summary>
        private class StackElement<T>
        {
            /// <summary>
            /// Следующий элемент
            /// </summary>
            public StackElement<T> Next => next;

            /// <summary>
            /// Следующий элемент
            /// </summary>
            private StackElement<T> next;

            /// <summary>
            /// Значение
            /// </summary>
            public T Value => value;

            /// <summary>
            /// Значение
            /// </summary>
            private T value;

            public StackElement(StackElement<T> next, T value)
            {
                this.next = next;
                this.value = value;
            }
        }

        /// <summary>
        /// Голова стека
        /// </summary>
        private StackElement<T> head;

        /// <summary>
        /// Добавить значение в стек
        /// </summary>
        /// <param name="value">Значение</param>
        public void Push(T value)
        {
            StackElement<T> newElement = new StackElement<T>(head, value);
            head = newElement;
            ++Length;
        }

        /// <summary>
        /// Достает значение из головы, удаляет его из стека
        /// </summary>
        public T Pop()
        {
            if (head == null)
            {
                throw new NullReferenceException();
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
        public T Peek()
        {
            if (head == null)
            {
                throw new NullReferenceException();
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
        public void Clear() => head = null;

        /// <summary>
        /// Печатает стек
        /// </summary>
        public void Print()
        {
            StackElement<T> iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value);
                iterator = iterator.Next;
            }
        }
    }
}
