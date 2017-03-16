namespace HashTableProject
{
    using System;
    /// <summary>
    /// Класс стандартной хэш-функции
    /// </summary>
    public class StandartHashFunction : IHashFunction
    {
        /// <summary>
        /// Считает значение хэш-функции путем сложения цифр в десятичной записи числа
        /// </summary>
        /// <param name="value">Значение, для которого надо посчитать хэш-функцию</param>
        public int Calculate(int value)
        {
            value = Math.Abs(value);
            int result = 0;
            while (value > 0)
            {
                result += value % 10;
                value = value / 10;
            }
            return result;
        }
    }
}
