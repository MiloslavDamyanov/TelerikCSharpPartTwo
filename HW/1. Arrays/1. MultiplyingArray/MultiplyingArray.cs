using System;

class MultiplyingArray
{
    static void Main()
    {
        int[] array = new int[20];
        int multiplier = 5;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i * multiplier;
            Console.WriteLine(array[i]);
        }
    }
}