using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void ConvertToBin(int number)
    {
        int result = 0;
        int bit = 0;
        List<int> binary = new List<int>();
        while (number != 0)
        {
            bit = number % 2;
            result = number / 2;
            number = result;
            binary.Add(bit);
        }

        binary.Reverse();
        foreach (var bin in binary)
        {
            Console.Write(bin);
        }
    }

    static void Main()
    {
        Console.Write("Decimal number: ");
        int number = int.Parse(Console.ReadLine());
        ConvertToBin(number);
        Console.WriteLine();
    }
}