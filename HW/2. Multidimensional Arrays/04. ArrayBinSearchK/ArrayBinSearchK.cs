using System;

class ArrayBinSearchK
{
    static void Main()
    {
        Console.Write("Array length N:  ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K:  ");
        int value = int.Parse(Console.ReadLine());

        // input array
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0}: ", i + 1);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        Console.WriteLine("Array after sort");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }

        int index = Array.BinarySearch(arr, value);
        while (index < 0)
        {
            if (value < arr[0])
            {
                break;
            }

            value--;
            index = Array.BinarySearch(arr, value);
        }

        if (index < 0)
        {
            Console.WriteLine("Element not found!");
        }
        else
        {
            Console.WriteLine("Element is {0} ", arr[index]);
        }
    }
}