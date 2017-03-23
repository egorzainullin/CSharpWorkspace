namespace StackCalculator
{
    /// <summary>
    /// Исключение, вызываемое в случае попытки достать значение из пустого стека
    /// </summary>
    public class EmptyStackException : System.SystemException
    {
        /// <summary>
        /// Конструктор по умолчанию, кидающий исключение типа <see cref="EmptyStackException"/>
        /// </summary>
        public EmptyStackException()
        { }

        /// <summary>
        /// Конструктор, с аргументом сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public EmptyStackException(string message)
            :base(message)
        { }
    }
}
