using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

struct Car
{
    public int x;
    public int y;
    public char symbol;
    public ConsoleColor Color;
}

class Program
{
    // default colot is grey 
    static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }


    static void Main()
    {
        int playFieldWidth = 5;
        // remove scrollbars
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 30;

        // Our car
        Car userCar = new Car();
        userCar.x = 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.symbol = '@';
        userCar.Color = ConsoleColor.Yellow;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x - 1 >= 0)
                    {
                        userCar.x = userCar.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x + 1 < playFieldWidth)
                    {
                        userCar.x = userCar.x + 1;
                    }

                }


            }


            // Move our car (key pressed)
            // Move cars 
            // Check is if other cars are hitting us
            // Clear Console
            Console.Clear();
            // Redraw playfield
            PrintOnPosition(userCar.x, userCar.y, userCar.symbol, userCar.Color);

            // Draw info
            // Slow down program 
            Thread.Sleep(100);
        }
    }
}

//Car audi = new Car();   // направи обек от тип Cars с име audi и задели памет
//audi.Color = ConsoleColor.Red; // цвят на колата червен