using System;

class Variations
{
    static void Generator(int[] arr, int index, int n)
    {
        if (index == arr.Length)
        {
            Output(arr);
        }
        else
        {
            for (int i = 1; i < n + 1; i++)
            {
                arr[index] = i;
                Generator(arr, index + 1, n);
            }
        }
    }

    static void Output(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }

        Console.WriteLine();
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine()); 
        int[] array = new int[k];
        Generator(array, 0, n);
    }
}