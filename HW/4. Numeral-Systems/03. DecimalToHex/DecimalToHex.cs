using System;
using System.Collections.Generic;

class DecimalToHex
{
    static void ConvertToHex(int number)
    {
        char[] hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        int result = 0;
        int reminder = 0;
        List<int> value = new List<int>();
        while (number != 0)
        {
            reminder = number % 16;
            result = number / 16;
            number = result;
            value.Add(reminder);
        }

        value.Reverse();
        for (int i = 0; i < value.Count; i++)
        {
            Console.Write(hex[value[i]]);
        }
    }

    static void Main()
    {
        Console.Write("Decimal number: ");
        int number = int.Parse(Console.ReadLine());
        ConvertToHex(number);
        Console.WriteLine();
    }
}