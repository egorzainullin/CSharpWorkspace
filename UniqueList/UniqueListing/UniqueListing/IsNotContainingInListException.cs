using System;
using System.Runtime.Serialization;

namespace UniqueListing
{
    [Serializable]
    public class IsNotContainingInListException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IsNotContainingInListException"/>
        /// </summary>
        public IsNotContainingInListException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IsNotContainingInListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        public IsNotContainingInListException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IsNotContainingInListException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        /// <param name="innerException">Внутренне исключение</param>
        public IsNotContainingInListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Конструктор, необходимый для работы ISerializable
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IsNotContainingInListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}