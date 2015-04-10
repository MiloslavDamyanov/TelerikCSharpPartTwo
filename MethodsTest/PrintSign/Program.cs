using System;

class Program
{
    static void PrintSign(int number)
    {
        if (number > 0)
        {
            Console.WriteLine("Positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        PrintSign(number);
    }
}