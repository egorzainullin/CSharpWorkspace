namespace HashTableProject
{
    public interface IList
    {
        /// <summary>
        /// Длина списка
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Добавить значение в список
        /// </summary>
        /// <param name="value">Значение, которое необходимо добавить</param>
        void Add(int value);

        /// <summary>
        /// Очистить список
        /// </summary>
        void Clear();

        /// <summary>
        /// Удалить значение из головы списка
        /// </summary>
        void DeleteFromHead();

        /// <summary>
        /// Проверить на принадлежность
        /// </summary>
        /// <param name="value">Значение, которое необходимо проверить</param>
        /// <returns>Возвращает true, если принадлежит</returns>
        bool IsContaining(int value);

        /// <summary>
        /// Проверяет список на пустоту
        /// </summary>
        /// <returns>Возвращает true, если список пуст</returns>
        bool IsEmpty();

        /// <summary>
        /// Возвращает значение из головы
        /// </summary>
        /// <returns></returns>
        int Peek();

        /// <summary>
        /// Возвращает значение из головы, удаляет его из списка
        /// </summary>
        /// <returns></returns>
        int Pop();

        /// <summary>
        /// Печатает список на консоль
        /// </summary>
        void Print();

        /// <summary>
        /// Удаляет все элементы списка с таким значением
        /// </summary>
        /// <param name="value">Значение, которое необходимо удалить</param>
        void Remove(int value);
    }
}