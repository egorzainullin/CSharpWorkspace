using System;

namespace Events
{
    /// <summary>
    /// Инициализирует класс <see cref="EventLoop"/>, необходимый для создания бесконечной цикла событий
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Событие, возникающее при нажатии стрелочки налево
        /// </summary>
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

        /// <summary>
        /// Событие, возникающее при нажатии стрелочки вправо
        /// </summary>
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        /// <summary>
        /// Событие, возникающее при нажатии стрелочки вверх
        /// </summary>
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        /// <summary>
        /// Событие, возникающее при нажатии стрелочки вниз
        /// </summary>
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Метод, запускающий игру
        /// </summary>
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
