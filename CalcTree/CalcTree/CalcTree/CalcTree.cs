using System;

namespace CalculationTree
{
    /// <summary>
    /// Класс дерево разбора
    /// </summary>
    public class CalcTree
    {
        /// <summary>
        /// Корень дерева
        /// </summary>
        private AbstractNode root;

        /// <summary>
        /// Считает значение дерева
        /// </summary>
        /// <returns></returns>
        public int Calculate() => root.Calculate();

        /// <summary>
        /// Печатает дерево
        /// </summary>
        public string Print()
        {
            string outString = root.PrintTree();
            Console.WriteLine(outString);
            return outString;
        }
        
        /// <summary>
        /// Генерирует дерево по заданному выражению
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private AbstractNode GenerateTree(string expression)
        {
            if (expression[0] != '(')
            {
                return new NumberNode(expression);
            }
            char op = expression[1];
            string leftOperand = "";
            string rightOperand = "";
            if (expression[2] != ' ')
            {
                throw new FormatException("Неверный формат");
            }
            if (expression[3] != '(')
            {
                int i = 3;
                while (expression[i] != ' ')
                {
                    leftOperand += expression[i];
                    ++i;
                }
                for (int j = i + 1; j < expression.Length - 1; ++j)
                {
                    rightOperand += expression[j];
                }
            }
            if (expression[3] == '(')
            {
                leftOperand = "(";
                int i = 4;
                int openingBracketsCount = 1;
                int closingBracketsCount = 0;
                while (openingBracketsCount > closingBracketsCount)
                {
                    if (expression[i] == '(')
                    {
                        ++openingBracketsCount;
                    }
                    else if (expression[i] == ')')
                    {
                        ++closingBracketsCount;
                    }
                    leftOperand += expression[i];
                    ++i;
                }
                for (int j = i + 1; j < expression.Length - 1; ++j)
                {
                    rightOperand += expression[j];
                }
            }
            var left = GenerateTree(leftOperand);
            var right = GenerateTree(rightOperand);
            return new OperatorNode(op, left, right);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CalcTree"/>
        /// </summary>
        /// <param name="expression">Выражение, которое должно удовлетворять следующему формату, соблюдая пробелы: инфиксная форма, например (* (+ 1 1) 2)</param>
        public CalcTree(string expression)
        {
            root = GenerateTree(expression);
        }
    }
}
