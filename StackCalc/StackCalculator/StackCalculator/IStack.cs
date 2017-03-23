namespace StackCalculator
{
    /// <summary>
    /// Интерфейс стек
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Добавить значение в стек
        /// </summary>
        /// <param name="value">Значение, которое необходимо добавить</param>
        void Push(int value);

        /// <summary>
        /// Очистить стек
        /// </summary>
        void Clear();

        /// <summary>
        /// Проверяет стек на пустоту
        /// </summary>
        /// <returns>Возвращает true, если список пуст</returns>
        bool IsEmpty();

        /// <summary>
        /// Возвращает значение из головы
        /// </summary>
        /// <returns></returns>
        /// /// <exception cref="EmptyStackException"
        int Peek();

        /// <summary>
        /// Возвращает значение из головы, удаляет его из стека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmptyStackException"
        int Pop();

        /// <summary>
        /// Печатает стек на консоль
        /// </summary>
        void Print();
    }
}