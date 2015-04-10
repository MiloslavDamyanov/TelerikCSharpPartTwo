using System;

class BinaryToHexcDirectly
{
    static void HexToBinary(string binNumber)
    {
        string[] arrBin = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111", };
        char[] arrHex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        string hexNumber = null;
        int bitsCount = 4;
        string currentOctet = null;
        int currentBit = 0;
        int end = bitsCount;
        for (int i = 0; i < binNumber.Length / bitsCount; i++)
        {
            for (currentBit = currentBit; currentBit < end; currentBit++)
            {
                currentOctet += binNumber[currentBit];
            }

            for (int index = 0; index < arrBin.Length; index++)
            {
                if (currentOctet == arrBin[index])
                {
                    hexNumber += arrHex[index];
                    currentOctet = null;
                }
            }

            bitsCount = bitsCount;
            end += bitsCount;
        }

        Console.WriteLine(hexNumber);
    }

    static void Main()
    {
        Console.Write("Binary number: ");
        string binNumber = Console.ReadLine();
        HexToBinary(binNumber);
    }
}

/*          TESTS
 *      bin       hex 
 * 000111110100 - 1F4 
 * 111111111111 - FFF 
 * 101010101010 - AAA 
 * 000100010001 - 111
 * 010010100100 - 4A4
*/