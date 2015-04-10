using System;

public class Quick
{
    static void QuickSort()
    {
        int[] array = { 7, 10, 6, 2, 11, 8, 13 };
        Sort(array, 0, array.Length - 1);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine();
    }

    static void Sort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int i = left;
        int j = right;
        int p = array[right];

        while (i < j)
        {
            while (i < j && array[i] <= p)
            {
                i++;
            }

            while (i < j && array[j] >= p)
            {
                j--;
            }

            if (i < j)
            {
                int t = array[i];
                array[i] = array[j];
                array[j] = t;
            }
        }

        int temp = array[i];
        array[i] = array[right];
        array[right] = temp;

        Sort(array, left, i - 1);
        Sort(array, i + 1, right);
    }

    static void Main()
    {
        QuickSort();
    }
}