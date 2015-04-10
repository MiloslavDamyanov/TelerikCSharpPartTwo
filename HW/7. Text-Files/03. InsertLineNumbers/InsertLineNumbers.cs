using System;
using System.IO;
using System.Text;

// Write a program that reads a text file and inserts line numbers 
// in front of each of its lines. The result should be written to another text file.
class InsertLineNumbers
{
    static void Numbering(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
        int lineNumber = 0;
        using (reader)
        {
            string fileContains = string.Empty;
            string newString = string.Empty;
            while (fileContains != null)
            {
                fileContains = reader.ReadLine();
                if (fileContains == null)
                {
                    break;
                }

                lineNumber++;
                StreamWriter writer = new StreamWriter("../../newfile.txt", true);
                using (writer)
                {
                    writer.WriteLine("{0} {1}", lineNumber.ToString(), fileContains);
                }
            }
        }
    }

    static void ReadNewFile(string path)
    {
        Console.BufferWidth = Console.WindowWidth = 80;
        StreamReader reader = new StreamReader(path);
        string fileContains = string.Empty;
        using (reader)
        {
            fileContains = reader.ReadToEnd();
        }

        Console.WriteLine(fileContains);
    }

    static void Main()
    {
        Numbering("../../readme.txt");
        ReadNewFile("../../newfile.txt");
    }
}