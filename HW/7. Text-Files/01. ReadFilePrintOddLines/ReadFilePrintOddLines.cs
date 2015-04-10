using System;
using System.IO;
using System.Text;

// Write a program that reads a text file and prints on the console its odd lines.
class ReadFilePrintOddLines
{
    static void ReadFilePrintAllText()
    {
        StreamReader reader = new StreamReader("../../readme.txt", Encoding.GetEncoding("Windows-1251"));
        using (reader)
        {
            string fileContains = reader.ReadToEnd();
            Console.WriteLine("\nAll text: ");
            Console.WriteLine(fileContains);
            Console.WriteLine("\nOdd Lines: ");
        }
    }

    static void ReadFileAndPrintOddLines()
    {
        StreamReader reader = new StreamReader("../../readme.txt", Encoding.GetEncoding("Windows-1251"));
        using (reader)
        {
            int oddLine = 0;
            string fileContains = string.Empty;
            while (fileContains != null)
            {
                oddLine++;
                fileContains = reader.ReadLine();
                if (oddLine % 2 != 0)
                {
                    Console.WriteLine(fileContains);
                }
            }
        }
    }

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 80;
        ReadFilePrintAllText();
        ReadFileAndPrintOddLines();
    }
}