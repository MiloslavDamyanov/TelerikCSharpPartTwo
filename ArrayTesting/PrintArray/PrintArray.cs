using System;

public class PrintArray
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        // entering elements in the array
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int count = 0;
        while (count < 5)
        {
            Console.WriteLine("Arra[{0}] : {1}", count, array[count]);
            count++;
        }
    }
}