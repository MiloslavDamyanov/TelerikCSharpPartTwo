using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Chess
{
    private static void PrintBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            Console.Write(".- - -  - - -  - - -  - - -  - - -  - - -  - - -  - - -.\n");
            Console.Write(".  @  ..     ..     ..     ..     ..     ..      .     .\n");
            Console.Write(".     ..     ..     ..     ..     ..     ..      .     .\n");
            Console.Write(".- - -  - - -  - - -  - - -  - - -  - - -  - - -  - - -.\n");
        }
    }
    static void Main()
    {
        while (true)
        {
            Console.BufferHeight = Console.WindowHeight = 35;
            Console.BufferWidth = Console.WindowWidth = 70;
            PrintBoard();
            Thread.Sleep(100);
            Console.Clear();
        }
    }
}

            //Console.Write(".- - -  - - -  - - -  - - -  - - -  - - -  - - -  - - -.\n");
            //Console.Write(".     ..     ..     ..     ..     ..     ..      .     .\n");
            //Console.Write(".     ..     ..     ..     ..     ..     ..      .     .\n");
            //Console.Write(".- - -  - - -  - - -  - - -  - - -  - - -  - - -  - - -.\n");