using System;
using System.Collections.Generic;
using System.IO;

class Table
{
    static List<int> numbers = new List<int>();

    static void AddNumbers()
    {
        ReadFile();
        int[,] battlefiled = new int[8, 8];
        int i = 0;
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++, i++)
            {
                battlefiled[row, col] = numbers[i];
            }
        }
    }

    static void ReadFile()
    {
        StreamReader read = new StreamReader("../../figursNum.txt");
        string strNumber = string.Empty;
        int intNumber = 0;
        using (read)
        {
            while (strNumber != null)
            {
                strNumber = read.ReadLine();
                if (strNumber != null)
                {
                    intNumber = int.Parse(strNumber);
                    numbers.Add(intNumber);
                }
            }
        }
    }

    static void Main()
    {        
        AddNumbers();        
    }
}
