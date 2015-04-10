using System;

class MaxElementSort
{
    static void OutputMaxElement(int[] arr, int index)
    {
        int maxElement = MaxElement(arr, index);
        Console.WriteLine("Max element is : {0}", maxElement);
    }

    static int MaxElement(int[] array, int index)
    {
        int startIndex = index;
        int maxValue = 0;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
        }
        return maxValue;

    }

    static void Sort(int[] arr)
    {
        Array.Sort(arr);
        foreach (var array in arr)
        {
            Console.Write("{0} ", array);
        }
        Console.WriteLine();
        Array.Reverse(arr);
        foreach (var array in arr)
        {
            Console.Write("{0} ", array);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = { 25, 4, 13, 6, 28, 3, 2, 5, 1, 5, 14, 0 };
        Console.Write("Index: ");
        int index = int.Parse(Console.ReadLine());
        OutputMaxElement(arr, index);
        Sort(arr);
    }
}