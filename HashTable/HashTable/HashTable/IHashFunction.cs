namespace HashTable
{
    interface IHashFunction
    {
        /// <summary>
        /// посчитать значение хэш-функции
        /// </summary>
        /// <param name="value">значение, для которого нужно посчитать значение</param>
        /// <returns>возвращает хэш-код</returns>
        int Calculate(int value);
    }
}
