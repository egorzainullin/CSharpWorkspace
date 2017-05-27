using System;
using System.Runtime.Serialization;

namespace UniqueListing
{
    /// <summary>
    /// Исключение, возникающее в случае в добавления UniqueList уже существующего элемента
    /// </summary>
    [Serializable]
    public class AlreadyInListException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AlreadyInListException"/>
        /// </summary>
        public AlreadyInListException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AlreadyInListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        public AlreadyInListException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AlreadyInListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public AlreadyInListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Конструктор, необходимый для работы ISerializable
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected AlreadyInListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}