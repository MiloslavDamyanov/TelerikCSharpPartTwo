using System;

class Program
{
    static bool AreAllPositive(int[] sequence)
    {
        foreach (int number in sequence)
        {
            if (number <= 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        int[] arr = new int[] { 2, 1, 4, 7, 1, 15 };
        AreAllPositive(arr);
        bool allPositive = AreAllPositive(arr);
        if (allPositive)
        {
            Console.WriteLine("All array elements are postive");
        }
        else
        {
            Console.WriteLine("There are negative elements");
        }
    }
}