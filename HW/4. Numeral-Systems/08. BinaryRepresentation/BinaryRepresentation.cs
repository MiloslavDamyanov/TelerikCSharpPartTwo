using System;
using System.Collections.Generic;

class BinaryRepresentation
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

        AddZeros(binary);
        binary.Reverse();
        foreach (var bin in binary)
        {
            Console.Write(bin);

        }
        Console.WriteLine();
    }
    // if length is < 16 add 0 
    static void AddZeros(List<int> binary)
    {
        if (binary.Count < 16)
        {
            while (binary.Count != 16)
            {
                binary.Add(0);
            }
        }
    }
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        ConvertToBin(number);
    }
}