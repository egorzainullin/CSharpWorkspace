using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueP
{

    /// <summary>
    /// Очередь с приоритетами
    /// </summary>
    public class QueuePrior
    {
        /// <summary>
        /// Длина очереди
        /// </summary>
        public int Length => length;

        /// <summary>
        /// Длина очереди-поле
        /// </summary>
        private int length;

        /// <summary>
        /// Голова очереди
        /// </summary>
        private QueueElement head;
        
        /// <summary>
        /// Хвост очереди
        /// </summary>
        private QueueElement tail;

        /// <summary>
        /// Элемент очереди
        /// </summary>
        private class QueueElement
        {
            /// <summary>
            /// Следующий элемент
            /// </summary>
            public QueueElement Next => next;

            /// <summary>
            /// Следующий элемент
            /// </summary>
            private QueueElement next;

            /// <summary>
            /// Значение элемента очереди
            /// </summary>
            public int Value => value;

            /// <summary>
            /// Значение элемента очереди
            /// </summary>
            private int value;

            /// <summary>
            /// Приоритет очереди
            /// </summary>
            public int Prior => prior;

            /// <summary>
            /// Приоритет очереди
            /// </summary>
            private int prior;

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="QueueElement"/>
            /// </summary>
            /// <param name="value">Значение</param>
            /// <param name="prior">Приоритет</param>
            /// <param name="next">Следующий элемент</param>
            public QueueElement(int value, int prior, QueueElement next)
            {
                this.value = value;
                this.prior = prior;
                this.next = next;
            }

            /// <summary>
            /// Меняет значение и приоритеты первого со вторым
            /// </summary>
            public static void SwapValues(QueueElement first, QueueElement second)
            {
                int temp = first.value;
                first.value = second.value;
                second.value = temp;
                temp = first.prior;
                first.prior = second.prior;
                second.prior = temp;
            }
        }

        /// <summary>
        /// Добавляет значение в очередь
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="prior">его приоритет</param>
        public void Enqueue(int value, int prior)
        {
            if (length == 0)
            {
                head = new QueueElement(value, prior, null);
                tail = head;
            }
            else
            {
                var newElement = new QueueElement(value, prior, head);
                head = newElement;
                var iterator = head;
                while (iterator != tail && iterator.Prior < iterator.Next.Prior)
                {
                    QueueElement.SwapValues(iterator, iterator.Next);
                    iterator = iterator.Next;
                }
            }
            ++length;
        }

        /// <summary>
        /// Достает значение из очереди
        /// </summary>
        /// <returns>Возвращает значение с наивысшим приоритетом</returns>
        public int Dequeue()
        {
            if (length == 0)
            {
                throw new QueueEmptyException("Очередь пуста");
            }
            int temp;
            if (head == tail)
            {
                --length;
                temp = head.Value;
                head = null;
                tail = null;
                return temp; 
            }
            --length;
            temp = head.Value;
            head = head.Next;
            return temp;
        }
    }
}
