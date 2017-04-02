using System;

namespace Events
{
    /// <summary>
    /// Класс, реализующий бизнес логику игры
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// Идти вниз при на нажатии стрелочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnDown(object sender, EventArgs e)
        {
            ++Console.CursorTop;
        }

        /// <summary>
        /// Идти вверх при на нажатии стрелочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnUp(object sender, EventArgs e)
        {
            if (Console.CursorTop > 0)
            {
                --Console.CursorTop;
            }
        }

        /// <summary>
        /// Идти влево при на нажатии стрелочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnLeft(object sender, EventArgs e)
        {
            if (Console.CursorLeft > 0)
            {
                --Console.CursorLeft;
            }
        }

        /// <summary>
        /// Идти вправо при на нажатии стрелочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnRight(object sender, EventArgs e)
        {
            ++Console.CursorLeft;
        }
    }
}