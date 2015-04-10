using System;

class Program
{
    static int numberOfColls = 0;

    static void Main()
    {
        numberOfColls++;
        Console.WriteLine(numberOfColls);
        Main();
    }
}