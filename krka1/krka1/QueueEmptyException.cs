using System;
using System.Runtime.Serialization;

namespace QueueP
{
    /// <summary>
    /// Исключение, вызываемое в случае попытки достать значение из пустой очереди
    /// </summary>
    [Serializable]
    public class QueueEmptyException : Exception
    {
        /// <summary>
        /// Конструктор по умолчанию, кидающий исключение типа <see cref="QueueEmptyException"/>
        /// </summary>
        public QueueEmptyException()
        {
        }

        /// <summary>
        /// Конструктор, с аргументом сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public QueueEmptyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Конструктор, с аргументом сообщение и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public QueueEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueueEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}