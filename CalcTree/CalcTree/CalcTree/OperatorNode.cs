using System;

namespace CalculationTree
{
    /// <summary>
    /// Оператор - вершина дерева
    /// </summary>
    internal class OperatorNode : AbstractNode
    {
        /// <summary>
        /// Тип оператора: +, -, *, /
        /// </summary>
        private char operatorType;

        /// <summary>
        /// Левый операнд оператора
        /// </summary>
        private AbstractNode leftChild;

        /// <summary>
        /// Правый операнд оператора
        /// </summary>
        private AbstractNode rightChild;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OperatorNode"/> 
        /// </summary>
        /// <param name="op">Оператор</param>
        /// <param name="left">Левый потомок</param>
        /// <param name="right">Правый потомок</param>
        public OperatorNode(char op, AbstractNode left, AbstractNode right)
        {
            this.operatorType = op;
            this.leftChild = left;
            this.rightChild = right;
        }

        /// <summary>
        /// Посчитать, начиная с этой вершины
        /// </summary>
        public override int Calculate()
        {
            switch (operatorType)
            {
                case '+':
                    return leftChild.Calculate() + rightChild.Calculate();
                case '*':
                    return leftChild.Calculate() * rightChild.Calculate();
                case '-':
                    return leftChild.Calculate() - rightChild.Calculate();
                case '/':
                    return leftChild.Calculate() / rightChild.Calculate();
                default:
                    throw new FormatException("Не оператор");
            }
        }

        /// <summary>
        /// Напечатать значение вершины
        /// </summary>
        public override void Print() => Console.WriteLine(operatorType.ToString());

        /// <summary>
        /// Возвращает строку, соответствующую дереву разбора
        /// </summary>
        public override string TreeIntoString()
        {
            string outString = "(" + operatorType + " " + leftChild.TreeIntoString() + " " + rightChild.TreeIntoString() + ")";
            return outString;
        }
    }
}