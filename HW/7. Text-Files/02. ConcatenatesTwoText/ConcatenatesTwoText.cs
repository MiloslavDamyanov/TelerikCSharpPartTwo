using System;
using System.IO;
using System.Text;

// Write a program that concatenates two text files into another text file.
class ConcatenatesTwoText
{
    static string Reader(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
        string fileContains = null;
        using (reader)
        {
            fileContains = reader.ReadToEnd();
        }

        return fileContains;
    }

    static void Writer(string fileContains)
    {
        StreamWriter writer = new StreamWriter("../../text3.txt", true);
        using (writer)
        {
            writer.WriteLine(fileContains);
        }
    }

    static void Concatenating(string firstFile, string secondFile)
    {
        Writer(Reader(firstFile));
        Writer(Reader(secondFile));
        Console.WriteLine("All done !");
    }

    static void Main()
    {
        string firstFile = @"../../text1.txt";
        string secondFile = @"../../text2.txt";
        Concatenating(firstFile, secondFile);
    }
}
