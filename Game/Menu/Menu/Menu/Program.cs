using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Menu
{
    

    static void Blindfold()
    {

        int digit = 1;
        ConsoleKeyInfo keyInfo;
        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    digit--;
                    break;

                case ConsoleKey.DownArrow:
                    digit++;
                    break;
                case ConsoleKey.RightArrow:
                    // Print next col
                    // 
                    break;
            }
        }
        Console.SetCursorPosition(5, 1);
        Console.WriteLine("Blindfold");
        Color(2);
        Console.SetCursorPosition(5, 2);
        Color(0);
        Console.WriteLine("Show");
        Console.SetCursorPosition(5, 3);
        Color(2);
        Console.WriteLine("Hide");
    }

    static void Main()
    {
        Blindfold();
    }

    static void Color(int value)
    {
        if (value == 0)        
            Console.ForegroundColor = ConsoleColor.Yellow;        
        else if (value == 1)        
            Console.ForegroundColor = ConsoleColor.Gray;
        else if (value == 2)
            Console.ForegroundColor = ConsoleColor.DarkCyan;
    }


}
