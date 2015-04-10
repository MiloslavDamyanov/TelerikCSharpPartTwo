using System;
using System.Numerics;

class Program
{
    static void Factorial()
    {
        BigInteger factorial = 1;
        int input = int.Parse(Console.ReadLine());
        for (int i = 1; i < input; i++)
        {
            factorial *= i;
            if (input - 1 == i)
            {
                Console.WriteLine(factorial);
            }
        }
    }
    static void Main()
    {
        Factorial();
    }
}