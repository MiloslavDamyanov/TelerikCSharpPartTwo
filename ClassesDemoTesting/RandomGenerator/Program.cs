using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Random RandomGenerator2 = new Random();
        Console.WriteLine(RandomGenerator2.Next());
        while (true)
        {
            Random RandomGenerator = new Random(RandomGenerator2.Next());
            Console.WriteLine(RandomGenerator.Next());
            Thread.Sleep(200);
        }
    }
}