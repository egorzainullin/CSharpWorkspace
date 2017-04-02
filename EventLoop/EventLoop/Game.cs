using System;

namespace Events
{
    internal class Game
    {
        internal static void OnDown(object sender, EventArgs e)
        {
            ++Console.CursorTop;
        }

        internal static void OnUp(object sender, EventArgs e)
        {
            if (Console.CursorTop > 0)
            {
                --Console.CursorTop;
            }
        }

        internal static void OnLeft(object sender, EventArgs e)
        {
            if (Console.CursorLeft > 0)
            {
                --Console.CursorLeft;
            }
        }

        internal static void OnRight(object sender, EventArgs e)
        {
            ++Console.CursorLeft;
        }
    }
}