using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[16];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }

        Array.Reverse(arr, 4, 4);
        Array.Reverse(arr, 12, 4);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}