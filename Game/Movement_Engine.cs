using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movement_Engine
{
    class Program
    {
        const ConsoleColor hero_color = ConsoleColor.Black;

        public static Coordinate Hero { get; set; }

        static void Main(string[] args)
        {
            InitGame();

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveHero(1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0);
                        break;
                }
            }
        }

        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                x = Hero.x + x,
                y = Hero.y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();

                Console.BackgroundColor = hero_color;
                Console.SetCursorPosition(newHero.x, newHero.y);
                Console.Write("@");

                Hero = newHero;
            }
        }

        static void RemoveHero()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Hero.x, Hero.y);
            Console.Write(" ");
        }

        static bool CanMove(Coordinate c)
        {
            if (c.x < 0 || c.x >= Console.WindowWidth)
                return false;

            if (c.y < 0 || c.y >= Console.WindowHeight)
                return false;

            return true;
        }

        static void InitGame()
        {
            SetBackgroundColor();

            Hero = new Coordinate()
            {
                x = 0,
                y = 0
            };

            MoveHero(0, 0);
        }

        static void SetBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }

    class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
