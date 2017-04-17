using System;

namespace CalculationTree
{
    internal class NumberNode : AbstractNode
    {
        /// <summary>
        /// Значение
        /// </summary>
        private int value;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="NumberNode"/> 
        /// </summary>
        /// <param name="value">Строка, являющаяся числом</param>
        public NumberNode(string value)
        {
            this.value = Int32.Parse(value);
        }

        /// <summary>
        /// Считает значение, начиная с этой вершины
        /// </summary>
        /// <returns></returns>
        public override int Calculate() => value;

        /// <summary>
        /// Печатает значение этой вершины
        /// </summary>
        public override void Print() => Console.WriteLine(value);

        /// <summary>
        /// Возвращает строку, соответствующую дереву разбора
        /// </summary>
        /// <returns></returns>
        public override string TreeIntoString() => value.ToString();
    }
}