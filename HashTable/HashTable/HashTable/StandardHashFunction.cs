namespace HashTable
{
    public class StandartHashFunction : IHashFunction
    {
        /// <summary>
        ///  считает модуль числа
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int Absolute(int value)
        {
            return value > 0 ? value : -value;
        }

        /// <summary>
        /// считает значение хэш-функции путем сложения цифр в десятичной записи числа
        /// </summary>
        /// <param name="value">значение, для которого надо посчитать хэш-функцию</param>
        public int Calculate(int value)
        {
            value = Absolute(value);
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
