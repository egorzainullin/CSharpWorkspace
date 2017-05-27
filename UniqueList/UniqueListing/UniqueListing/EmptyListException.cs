using System;
using System.Runtime.Serialization;

namespace UniqueListing
{
    /// <summary>
    /// Исключение, возникающие в случае попытки достать значения из пустого списка
    /// </summary>
    [Serializable]
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmptyListException"/>
        /// </summary>
        public EmptyListException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmptyListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        public EmptyListException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmptyListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public EmptyListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Конструктор, необходимый для работы ISerializable
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EmptyListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}