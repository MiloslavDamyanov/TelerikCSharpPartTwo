using System;

class Program
{
    private static void PrintLine(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            Console.Write(" {0}", i);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int n = 10;

        for (int line = 1; line <= n; line++)
        {
            PrintLine(1, line);
        }

        for (int line = n - 1; line >= 1; line--)
        {
            PrintLine(1, line);
        }

    }
}

// without methods
//int n = 10;

//        for (int row = 1; row <= n; row++)
//        {
//            for (int i = 1; i < row + 1; i++)
//            {
//                Console.Write("{0} ", i);
//            }
//            Console.WriteLine();
//        }

//        for (int row = n - 1; row >= 1; row--)
//        {
//            for (int i = 1; i < row + 1; i++)
//            {
//                Console.Write("{0} ", i);
//            }
//            Console.WriteLine();
//        }