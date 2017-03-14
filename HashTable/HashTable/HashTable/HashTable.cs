﻿using System;

namespace HashTable
{
    class HashTable
    {
        /// <summary>
        /// размер таблицы
        /// </summary>
        private int tableSize = 997;

        /// <summary>
        /// массив списков, необходимый для работы хэш-таблицы, каждый элемент соответствует возможному хэшу
        /// </summary>
        private IList[] hashLists;

        /// <summary>
        /// интерфейс хэш-функции
        /// </summary>
        private IHashFunction hashFunction;

        private class StandartHashFunction : IHashFunction
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
        /// <summary>
        /// Создает новый экземпляр класса <see cref="HashTable"/> и инициализирует значениями по умолчанию 
        /// </summary>
        public HashTable()
        {
            hashFunction = new StandartHashFunction();
            hashLists = new List[tableSize];
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="HashTable"/> и инициализирует хэш-функцию заданной
        /// </summary>
        /// <param name="GotHashFunction"> полученная хэш-функция</param>
        public HashTable(IHashFunction GotHashFunction)
        {
            hashFunction = GotHashFunction;
            hashLists = new List[tableSize];
        }

        /// <summary>
        /// проверяет элемент на принадлежность хэш-таблице
        /// </summary>
        /// <returns>возвращает true, если принадлежит</returns>
        public bool isContaining(int value)
        {
            int hash = hashFunction.Calculate(value) % tableSize;
            return hashLists[hash].IsContaining(value) ? true : false;
        }

        /// <summary>
        /// Добавляет элемент в хэш-таблицу
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            int hash = hashFunction.Calculate(value) % tableSize;
            if (!hashLists[hash].IsContaining(value))
            {
                hashLists[hash].Add(value);
            }
        }

        /// <summary>
        /// удаляет элемент из хэш-таблицы
        /// </summary>
        /// <param name="value">значение, которое необходимо удалить</param>
        public void Remove(int value)
        {
            int hash = hashFunction.Calculate(value) % tableSize;
            if (hashLists[hash].IsContaining(value))
            {
                hashLists[hash].Remove(value);
            }
        }
    }
}
