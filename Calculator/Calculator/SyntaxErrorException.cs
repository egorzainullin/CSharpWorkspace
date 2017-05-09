using System;
using System.Runtime.Serialization;

namespace Calculator
{
    /// <summary>
    /// Исключение, которое возникает при синтаксической ошибке ввода числа
    /// </summary>
    [Serializable]
    public class SyntaxErrorException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SyntaxErrorException"/>
        /// </summary>
        public SyntaxErrorException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SyntaxErrorException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        public SyntaxErrorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SyntaxErrorException"/>
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо прикрепить</param>
        /// <param name="innerException">Внутреннее сообщение</param>
        public SyntaxErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Необходимый конструктор для сериализации
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SyntaxErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

