using System;

class HexToBinDirectly
{
    static void HexToBinary(string value)
    {
        string[] arrBin = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111", };
        char[] arrHex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        string binaryNumber = null;
        for (int pos = 0; pos < value.Length; pos++)
        {
            for (int index = 0; index < arrBin.Length; index++)
            {
                if (value[pos] == arrHex[index])
                {
                    binaryNumber += arrBin[index];
                }
            }
        }

        RemoveZeros(binaryNumber);
    }

    static void RemoveZeros(string binaryNumber)
    {
        int index = 0;
        int pos = 0;
        while (binaryNumber[pos] == '0')
        {
            pos++;
            index++;
        }

        string newBinaryNumber = null;
        for (int i = index; i < binaryNumber.Length; i++)
        {
            newBinaryNumber += binaryNumber[i];
        }

        Console.WriteLine(newBinaryNumber);
    }

    static void Main()
    {
        Console.Write("Hex: ");
        string value = Console.ReadLine();
        HexToBinary(value.ToUpper());
    }
}