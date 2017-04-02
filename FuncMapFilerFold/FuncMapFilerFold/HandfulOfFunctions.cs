using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncMapFilerFold
{
    /// <summary>
    /// Класс, реализующий несколько функций
    /// </summary>
    public static class HandfulOfFunctions
    {
        /// <summary>
        /// Метод, который возвращает преобразованной список с помощью полученной функции
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="function">Функция, которая преобразует список</param>
        /// <returns></returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var returningList = new List<int>();
            foreach (var element in list)
            {
                returningList.Add(function(element));
            }
            return returningList;
        }

        /// <summary>
        /// Метод, возвращающий список, который состоит из элементов исходного и удовлетворяет предикату
        /// </summary>
        /// <param name="list"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var returningList = new List<int>();
            return list.FindAll(i => function(i));
        }

        /// <summary>
        /// Метод, принимает список, начальное значение и функцию, которая берёт текущее накопленное значение и текущий элемент списка, и возвращает следующее накопленное значение
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="acc">Начальное значение</param>
        /// <param name="function">Функция</param>
        /// <returns></returns>
        public static int Fold(List<int> list, int acc, Func<int, int, int> function)
        {
            foreach(var element in list)
            {
                acc = function(acc, element);
            }
            return acc;
        }
    }
}
