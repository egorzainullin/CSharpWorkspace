using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            eventLoop.LeftHandler += Game.OnLeft;
            eventLoop.RightHandler += Game.OnRight;
            eventLoop.UpHandler += Game.OnUp;
            eventLoop.DownHandler += Game.OnDown;
            eventLoop.Run();
        }
    }
}
