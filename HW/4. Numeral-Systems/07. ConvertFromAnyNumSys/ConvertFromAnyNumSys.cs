using System;
using System.Collections.Generic;

class ConvertFromAnyNumSys
{
    // Deciaml to Bin
    static void DecimalToBin(int number)
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
        Console.Write("Bin: ");
        foreach (var bin in binary)
        {
            Console.Write(bin);
        }
    }
    // Deciaml to Hex
    static void DecimalToHex(int number)
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
        Console.Write("Hex: ");
        for (int i = 0; i < value.Count; i++)
        {
            Console.Write(hex[value[i]]);
        }
        Console.WriteLine();
    }
    // Hex To Dec
    static void HexToDec(string number)
    {
        int[] arr = new int[number.Length];
        char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 0; i < number.Length; i++)
        {
            for (int index = 0; index < symbols.Length; index++)
            {
                if (number[i] == symbols[index])
                {
                    arr[i] = index;
                }
            }
        }

        int pow = 0;
        int sum = 0;
        int result = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            result = arr[i] * (int)Math.Pow(16, pow);
            pow++;
            sum += result;
        }

        Console.WriteLine("Decimal: {0}",sum);
    }
    // Bin to Deciaml
    static void BinToDecimal(string strNumber)
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
    // Convert to Dec
    static int ConvertToDec(string number, int baseFrom)
    {
        int decNum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] > '9')
            {
                decNum += (number[i] - '7') * (int)Math.Pow(baseFrom, (number.Length - 1 - i));
            }
            else
            {
                decNum += (number[i] - '0') * (int)Math.Pow(baseFrom, (number.Length - 1 - i));
            }
        }
        return decNum;
    }
    
    static void Menu(string number, int from, int to)
    {
        int decNumber = ConvertToDec(number, from);
        if (to == 2)
        {
            DecimalToBin(decNumber);
        }
        else if (to == 16)
        {
            DecimalToHex(decNumber);
        }
        else if (from == 16 && to == 10)
        {

            HexToDec(number);
        }
        else if (from == 2 && to == 10)
        {
            BinToDecimal(number);
        }


    }
    static void Main()
    {
        Console.Write("Number: ");
        string number = Console.ReadLine();
        Console.Write("Convert from: ");
        int from = int.Parse(Console.ReadLine());
        Console.Write("Convert to: ");
        int to = int.Parse(Console.ReadLine());
        Menu(number.ToUpper(), from, to);
    }
}