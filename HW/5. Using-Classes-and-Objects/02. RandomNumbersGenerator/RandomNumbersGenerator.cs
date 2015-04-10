using System;
using System.Threading;

class RandomNumbersGenerator
{
    // Generate random numbers with both bounds specified. 
    static void BothBoundsRandoms(int lower, int upper)
    {
        Console.WriteLine("\nRandom object, lower = {0}, " + "upper = {1}", lower, upper);
        Random randNum = new Random();

        // Generate 10 random integers from the lower to  
        // upper bounds. 
        for (int j = 0; j < 10; j++)
        {
            Console.Write("{0} ", randNum.Next(lower, upper));
        }

        Console.WriteLine();
    }

    static void Main()
    {
        BothBoundsRandoms(100, 200);
    }
}