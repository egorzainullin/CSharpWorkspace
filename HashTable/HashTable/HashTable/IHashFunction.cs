namespace HashTableProject
{
    /// <summary>
    /// Интерфейс хэш-функции
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Посчитать значение хэш-функции
        /// </summary>
        /// <param name="value">Значение, для которого нужно посчитать значение</param>
        /// <returns>Возвращает хэш-код</returns>
        int Calculate(int value);
    }
}
