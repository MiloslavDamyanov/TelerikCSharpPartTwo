using System;
using System.Collections.Generic;

class CountNumberInArray
{
    static int CountNumber(int[] array, int num)
    {
        int arrayLength = array.Length;
        int count = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            if (num == array[i])
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        int[] numbers = { 21, 21, 16, 5, 22, 8, 21, 1, 8 };
        Console.WriteLine("21, 21, 16, 5, 22, 8, 21, 1 ,8");
        Console.Write("Pick a number: ");
        int num = int.Parse(Console.ReadLine());

        int result = CountNumber(numbers, num);
        if (result > 0)
        {
            Console.WriteLine("Number {0} appear {1} time/s", num, result);
        }
        else
        {
            Console.WriteLine("Number not found! ");
        }

    }
}