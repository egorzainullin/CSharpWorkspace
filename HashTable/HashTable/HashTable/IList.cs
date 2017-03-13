namespace HashTable
{
    public interface IList
    {
        /// <summary>
        /// длина списка
        /// </summary>
        int Length { get; }

        /// <summary>
        /// добавить значение в список
        /// </summary>
        /// <param name="value">значение, которое необходимо добавить</param>
        void Add(int value);

        /// <summary>
        /// очистить список
        /// </summary>
        void Clear();

        /// <summary>
        /// удалить значение из головы списка
        /// </summary>
        void DeleteFromHead();

        /// <summary>
        /// проверить на принадлежность
        /// </summary>
        /// <param name="value">значение, которое необходимо проверить</param>
        /// <returns>возвращает true, если принадлежит</returns>
        bool IsContaining(int value);

        /// <summary>
        /// проверяет список на пустоту
        /// </summary>
        /// <returns>возвращает true, если список пуст</returns>
        bool isEmpty();

        /// <summary>
        /// возвращает значение из головы
        /// </summary>
        /// <returns></returns>
        int Peek();

        /// <summary>
        /// возвращает значение из головы, удаляет его из списка
        /// </summary>
        /// <returns></returns>
        int Pop();

        /// <summary>
        /// печатает список на консоль
        /// </summary>
        void Print();

        /// <summary>
        /// удаляет все элементы списка с таким значением
        /// </summary>
        /// <param name="value">значение, которое необходимо удалить</param>
        void Remove(int value);
    }
}