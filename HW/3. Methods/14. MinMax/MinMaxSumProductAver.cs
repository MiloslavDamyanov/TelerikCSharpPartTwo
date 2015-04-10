using System;

class MinMaxSumProductAver
{
    static int MaxElement(int[] arr)
    {
        int maxValue = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }

        return maxValue;
    }

    static int MinElement(int[] arr)
    {
        int minValue = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }

        return minValue;
    }

    static int Average(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        int average = sum / arr.Length;
        return average;
    }

    static int Product(int[] arr)
    {
        int product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    static void PrintResult(int max, int min, int average, int product, int sum)
    {
        Console.WriteLine("Max element in array is: {0}", max);
        Console.WriteLine("Min element in array is {0}", min);
        Console.WriteLine("Average is: {0}", average);
        Console.WriteLine("Product is: {0}", product);
        Console.WriteLine("Sum of elemnts in array is: {0}", sum);
    }

    static void Main()
    {
        int[] array = { 5, 12, 11, 8, 3, 54, 2, 5, 1 };
        int max = MaxElement(array);
        int min = MinElement(array);
        int average = Average(array);
        int product = Product(array);
        int sum = Sum(array);
        PrintResult(max, min, average, product, sum);
    }
}