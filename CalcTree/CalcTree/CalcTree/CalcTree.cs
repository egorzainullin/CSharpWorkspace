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
        private TreeElement root;

        /// <summary>
        /// Считает значение дерева
        /// </summary>
        /// <returns></returns>
        public int Calculate() => root.Calculate();

        /// <summary>
        /// Печатает дерево
        /// </summary>
        public string Print() => root.PrintTree();
        
        /// <summary>
        /// Генерирует дерево по заданному выражению
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private TreeElement GenerateTree(string expression)
        {
            if (expression[0] != '(')
            {
                return new TreeElement(expression);
            }
            string op = expression[1].ToString();
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
            return new TreeElement(op, left, right);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CalcTree"/>
        /// </summary>
        /// <param name="expression">Выражение, которое должно удовлетворять следующему формату, соблюдая пробелы: инфиксная форма, например (* (+ 1 1) 2)</param>
        public CalcTree(string expression)
        {
            root = GenerateTree(expression);
        }

        /// <summary>
        /// Элемент дерева: оператор или число
        /// </summary>
        private class TreeElement
        {
            /// <summary>
            /// Свойство: значение в вершине
            /// </summary>
            public string Value => value;

            /// <summary>
            /// Поле значение в вершине
            /// </summary>

            private string value;

            /// <summary>
            /// Проверяет, является ли вершина оператором
            /// </summary>
            /// <returns></returns>
            public bool IsOperator() => value == "+" || value == "-" || value == "*" || value == "/";

            /// <summary>
            /// Левый ребенок оператора
            /// </summary>
            private TreeElement leftChild;

            /// <summary>
            /// Правый ребенок оператора
            /// </summary>
            private TreeElement rightChild;

            /// <summary>
            /// Сохраняет дерево в строку, начиная с root
            /// </summary>
            /// <param name="root"></param>
            private string PrintTree(TreeElement root)
            {
                if (root == null)
                {
                    return "";
                }
                string outString = "";
                if (root.IsOperator())
                {
                    outString = "(" + root.Value + " " + PrintTree(root.leftChild) + " " + PrintTree(root.rightChild) + ")";
                }
                else
                {
                    outString = root.Value;
                }
                return outString;
            }

            /// <summary>
            /// Печатает дерево, начиная с этой вершины
            /// </summary>
            /// <param name="root"></param>
            public string PrintTree()
            {
                string outString = PrintTree(this);
                Console.WriteLine(outString);
                return outString;
            }

            /// <summary>
            /// Посчитать значение, начиная с этой вершины
            /// </summary>
            /// <returns>Посчитанное значение</returns>
            public int Calculate()
            {
                switch (value)
                {
                    case "+":
                        return leftChild.Calculate() + rightChild.Calculate();
                        break;
                    case "*":
                        return leftChild.Calculate() * rightChild.Calculate();
                        break;
                    case "-":
                        return leftChild.Calculate() - rightChild.Calculate();
                        break;
                    case "/":
                        return leftChild.Calculate() / rightChild.Calculate();
                        break;
                    default:
                        return Int32.Parse(value);
                        break;
                }
            }

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="TreeElement"/>
            /// </summary>
            /// <param name="value">Оператор</param>
            /// <param name="leftChild">Ссылка левый операнд</param>
            /// <param name="rightChild">Ссылка на правый операнд</param>
            public TreeElement(string value, TreeElement leftChild, TreeElement rightChild)
            {
                this.value = value;
                this.leftChild = leftChild;
                this.rightChild = rightChild;
            }

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="TreeElement"/>
            /// </summary>
            /// <param name="value">Число</param>
            public TreeElement(string value)
                : this(value, null, null)
            { }

            /// <summary>
            /// Печатает оператор / операнд на консоль
            /// </summary>
            public void Print() => Console.Write(value);
        }
    }
}
