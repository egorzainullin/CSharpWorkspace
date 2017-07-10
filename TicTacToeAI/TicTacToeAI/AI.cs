using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAI
{
    public class AI : IAI
    {
        private int typeOfShape = -1;

        public Point GetCurrentTurnAfterPLayer(int[,] obtainedDesk)
        {
            int[,] desk = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    desk[i, j] = obtainedDesk[i, j];
                }
            }
            var list = new List<Point>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (desk[i,j] == 0)
                    {
                        list.Add(new Point(i, j));
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            foreach (var point in list)
            {
                desk[point.X, point.Y] = typeOfShape;
                if (TicTacToeGameLogic.SomeoneWin(desk) == -1)
                {
                    desk[point.X, point.Y] = 0;
                    return point;
                }
                desk[point.X, point.Y] = 0;
            }
            foreach (var point in list)
            {
                desk[point.X, point.Y] = -typeOfShape;
                if (TicTacToeGameLogic.SomeoneWin(desk) == 1)
                {
                    desk[point.X, point.Y] = 0;
                    return point;
                }
                desk[point.X, point.Y] = 0;
            }
            var rand = new Random();
            int turnNumber = rand.Next(list.Count - 1);
            return list[turnNumber];
        }

        public int GetTypeOfShape() => typeOfShape;

        private bool IsContrLosingPosition()
        {
            return true;
        }

        private bool IsWinningPosition()
        {
            return true;
        }
    }
}
