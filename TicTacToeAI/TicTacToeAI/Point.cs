using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAI
{
    public class Point
    {
        public int X = 0;

        public int Y = 0;

        public override string ToString()
        {
            return X + " " + Y;
        }

        public Point(int x,  int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
