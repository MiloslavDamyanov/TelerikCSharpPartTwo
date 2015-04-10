using System;
using System.Collections.Generic;

class HexadecimalToDecimal
{
    static void ConvertToDeciaml(string hexNumber)
    {
        int[] arr = new int[hexNumber.Length];
        char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 0; i < hexNumber.Length; i++)
        {
            for (int index = 0; index < symbols.Length; index++)
            {
                if (hexNumber[i] == symbols[index])
                {
                    arr[i] = index;
                }
            }
        }

        int pow = 0;
        int sum = 0;
        int result = 0;
        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            result = arr[i] * (int)Math.Pow(16, pow);
            pow++;
            sum += result;
        }

        Console.WriteLine(sum);
    }

    static void Main()
    {
        Console.Write("Hex number: ");
        string hexNumber = Console.ReadLine();
        Console.Write("Decimal number: ");
        ConvertToDeciaml(hexNumber.ToUpper());
    }
}