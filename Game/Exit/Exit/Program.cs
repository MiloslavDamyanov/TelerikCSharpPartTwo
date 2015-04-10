using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void InitGame()
    {
        while (true)
        {
            Console.Write("*");
        }
    }


    static void Exit()
    {
        ConsoleKeyInfo keyInfo;
        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape:
                    Console.WriteLine();
                    break;

            }
        }
    }

    static void Main()
    {
        
        bool exit = false;
        while (!exit)
        {
            Console.Write("Your Number: ");
            InitGame();
            Console.Write("Do you want to exit? Yes/No: ");
            if (Console.ReadLine() != "No")
                exit = true;
        }
    }

}