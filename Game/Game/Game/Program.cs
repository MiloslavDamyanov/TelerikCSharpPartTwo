using System;
using System.Threading;

class Program
{
    static int shipSize = 3;
    static int playerSize = 2;
    static int playerPosition = 0;
    static int shipPosition = 0;

    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight = 25;
        Console.BufferWidth = Console.WindowWidth = 40;
    }

    static void DrawPlayer()
    {
        for (int y = 0; y < playerSize; y++)
        {
            
        }
    }

    static void DrawShip()
    {

    }
    static void Main()
    {
        RemoveScrollBars();
        while (true)
        {
            // Move player

            // Move ships 

            // Redraw all

            // - Clear all

            // - draw player
            DrawPlayer();
            // - draw ships 
            DrawShip();
            // - print result

            // sleep 
            Thread.Sleep(60);
        }
    }
}