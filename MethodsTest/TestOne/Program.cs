using System;

class Program
{
   
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char symbol = '@';
        Counter(n,symbol);
    }

    static void Counter(int n, char symbol)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0}",symbol);
        }
        Console.WriteLine();
    }
}