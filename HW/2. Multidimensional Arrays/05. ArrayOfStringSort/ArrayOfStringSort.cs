using System;

class ArrayOfStringSort
{
    static void Swap(string[] array, int i, int j)
    {
        string t = array[i];
        array[i] = array[j];
        array[j] = t;
    }

    static int Partition(string[] array, int left, int right)
    {
        Swap(array, new Random().Next(left, right + 1), right);
        int pivot = array[right].Length, i = left;

        for (int j = left; j < right; j++)
        {
            if (array[j].Length <= pivot)
            {
                Swap(array, i++, j);
            }
        }

        Swap(array, i, right);
        return i;
    }

    static void QuickSort(string[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int q = Partition(array, left, right);

        QuickSort(array, left, q - 1);
        QuickSort(array, q + 1, right);
    }

    static void Main()
    {
        string[] array = { "ads", "22", "dassdd", "s", "55555", "4444" };

        QuickSort(array, 0, array.Length - 1);

        foreach (string item in array)
        {
            Console.WriteLine(item);
        }
    }
}