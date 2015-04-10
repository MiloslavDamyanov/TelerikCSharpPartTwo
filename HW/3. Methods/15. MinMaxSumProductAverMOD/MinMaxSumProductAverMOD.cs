using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MinMaxSumProductAverMOD
{
    static T MaxElement<T>(T[] arr)
    {
        dynamic maxValue = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }

        return maxValue;
    }

    static T MinElement<T>(T[] arr)
    {
        dynamic minValue = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }

        return minValue;
    }

    static T Average<T>(T[] arr)
    {
        dynamic sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum / arr.Length;
    }

    static T Product<T>(T[] arr)
    {
        dynamic product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    static T Sum<T>(T[] arr)
    {
        dynamic sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    static void Main()
    {
        int[] array = { 5, 12, 11, 8, 3, 54, 2, 5, 1 };

        Console.WriteLine("Max element in array is: {0}", MaxElement(array));
        Console.WriteLine("Min element in array is {0}", MinElement(array));
        Console.WriteLine("Average is: {0}", Average(array));
        Console.WriteLine("Product is: {0}", Product(array));
        Console.WriteLine("Sum of elemnts in array is: {0}", Sum(array));
    }
}