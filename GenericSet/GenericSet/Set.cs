using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericSet
{
    /// <summary>
    /// Класс Множество, позволяющий хранить значения определенного типа
    /// </summary>
    /// <typeparam name="T">Тип сохраняемого значения</typeparam>
    public class Set<T> : IEnumerable<T>
    {
        /// <summary>
        /// Словарь для хранения данных множества
        /// </summary>
        private Dictionary<T, T> dictionary = new Dictionary<T, T>();

        /// <summary>
        /// Получить генериковый энумератор
        /// </summary>
        /// <returns>Генериковый энумератор</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        /// <summary>
        /// Получить энумератор
        /// </summary>
        /// <returns>Энумератор</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        /// <summary>
        /// Добавляет элемент в множество
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        /// <returns>True, если такого элемента еще нет, false, если есть</returns>
        public bool Add(T value)
        {
            try
            {
                dictionary.Add(value, value);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет на принадлежность данному множеству
        /// </summary>
        /// <param name="value">Значение, которое необходимо проверить, есть ли оно в этом множестве</param>
        /// <returns>True, если содержится, false, если нет</returns>
        public bool IsContaining(T value) => dictionary.ContainsKey(value);

        /// <summary>
        /// Удаляет элемент по указанному значению
        /// </summary>
        /// <param name="value">Значение, которое необходимо было удалить</param>
        /// <returns>True, если элемент был найден и удален, false, если нет</returns>
        public bool Remove(T value) => dictionary.Remove(value);

        /// <summary>
        /// Удаляет все элементы множества
        /// </summary>
        public void Clear() => dictionary.Clear();

        /// <summary>
        /// Объединяет два множества
        /// </summary>
        /// <param name="set1">Первое множество</param>
        /// <param name="set2">Второе множество</param>
        /// <returns>Полученное после объединения множество</returns>
        public static Set<T> Combine(Set<T> set1, Set<T> set2)
        {
            var answer = new Set<T>();
            foreach (var i in set1)
            {
                answer.Add(i);
            }
            foreach (var i in set2)
            {
                answer.Add(i);
            }
            return answer;
        }

        /// <summary>
        /// Пересекает два множества
        /// </summary>
        /// <param name="set1">Первое множество</param>
        /// <param name="set2">Второе множество</param>
        /// <returns>Полученное после пересечения множество</returns>
        public static Set<T> Intersect(Set<T> set1, Set<T> set2)
        {
            var answer = new Set<T>();
            foreach (var i in set1)
            {
                if (set2.IsContaining(i))
                {
                    answer.Add(i);
                }
            }
            return answer;
        }
    }
}
