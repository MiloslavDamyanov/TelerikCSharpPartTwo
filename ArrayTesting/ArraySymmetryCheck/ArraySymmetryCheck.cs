using System;

public class ArraySymmetryCheck
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        bool isSymmetryc = true;

        // entering elements in the array
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        // checking for symmetric
        for (int i = 0; i < array.Length / 2; i++)
        {
            if (array[i] != array[n - i - 1])
            {
                isSymmetryc = false;
            }
        }

        Console.WriteLine(isSymmetryc);

        // message
        if (isSymmetryc)
        {
            Console.WriteLine("The array is symmetric");
        }
        else
        {
            Console.WriteLine("The array is not symetric");
        }
    }
}