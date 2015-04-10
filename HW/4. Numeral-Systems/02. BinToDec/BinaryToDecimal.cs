using System;
using System.Collections.Generic;

class BinToDec
{
    static void ConvertToDecimal(string strNumber)
    {
        // get last digit and add to array
        int len = strNumber.Length;
        int number = int.Parse(strNumber);
        int sum = 0;
        int[] arr = new int[len];
        for (int i = 0; i < len; i++)
        {
            int digit = number % 10;
            number /= 10;
            arr[i] = digit;
        }

        for (int i = 0, pow = 0; i < arr.Length; pow++, i++)
        {
            sum += arr[i] * (int)Math.Pow(2, pow);
        }

        Console.WriteLine("Decimal: " + sum);
    }

    static void Main()
    {
        Console.Write("Binary number: ");
        string strNumber = Console.ReadLine();

        ConvertToDecimal(strNumber);
    }
}