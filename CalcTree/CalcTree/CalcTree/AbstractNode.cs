namespace CalculationTree
{
    /// <summary>
    /// Абстрактная вершина для вычислительного дерева
    /// </summary>
    internal abstract class AbstractNode
    {
        /// <summary>
        /// Посчитать, начиная с этой вершины
        /// </summary>
        public abstract int Calculate();

        /// <summary>
        /// Напечатать значение вершины
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Возвращает строку, соответствующую дереву разбора
        /// </summary>
        public abstract string TreeIntoString();
    }
}