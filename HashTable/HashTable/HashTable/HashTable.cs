using System;

namespace HashTableProject
{
    public class HashTable
    {
        /// <summary>
        /// Размер таблицы
        /// </summary>
        private int tableSize = 997;

        /// <summary>
        /// Количество элементов в таблице
        /// </summary>
        public int NumberOfElements { get; private set; }

        /// <summary>
        /// Массив списков, необходимый для работы хэш-таблицы, каждый элемент соответствует возможному хэшу
        /// </summary>
        private IList[] hashLists;

        /// <summary>
        /// Интерфейс хэш-функции
        /// </summary>
        private IHashFunction hashFunction;

        private class StandartHashFunction : IHashFunction
        {
            
            /// <summary>
            /// Считает значение хэш-функции путем сложения цифр в десятичной записи числа
            /// </summary>
            /// <param name="value">значение, для которого надо посчитать хэш-функцию</param>
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

        /// <summary>
        /// Инициализирует массив списков
        /// </summary>
        private void InitializeListArr()
        {
            hashLists = new IList[tableSize];
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="HashTable"/> и инициализирует хэш-функцию заданной
        /// </summary>
        /// <param name="GotHashFunction"> полученная хэш-функция</param>
        public HashTable(IHashFunction GotHashFunction)
        {
            hashFunction = GotHashFunction;
            InitializeListArr();
            for (int i = 0; i < tableSize; i++)
            {
                hashLists[i] = new List();
            }
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="HashTable"/> и инициализирует значениями по умолчанию 
        /// </summary>
        public HashTable()
        : this(new StandartHashFunction())
        { }

        /// <summary>
        /// Проверяет элемент на принадлежность хэш-таблице
        /// </summary>
        /// <returns>Возвращает true, если принадлежит</returns>
        public bool IsContaining(int value)
        {
            int hash = Math.Abs(hashFunction.Calculate(value)) % tableSize;
            return hashLists[hash].IsContaining(value);
        }

        /// <summary>
        /// Добавляет элемент в хэш-таблицу
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            int hash = Math.Abs(hashFunction.Calculate(value)) % tableSize;
            if (!hashLists[hash].IsContaining(value))
            {
                hashLists[hash].Add(value);
                ++NumberOfElements;
            }
        }

        /// <summary>
        /// Удаляет элемент из хэш-таблицы
        /// </summary>
        /// <param name="value">Значение, которое необходимо удалить</param>
        public void Remove(int value)
        {
            int hash = Math.Abs(hashFunction.Calculate(value)) % tableSize;
            if (hashLists[hash].IsContaining(value))
            {
                hashLists[hash].Remove(value);
                --NumberOfElements;
            }
        }
    }
}
