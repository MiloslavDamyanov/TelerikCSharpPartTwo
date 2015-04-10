using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Modify the solution of the previous problem to replace only whole words (not substrings).
class WordReplace
{
    static List<string> list = new List<string>();

    static void Read(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
        using (reader)
        {
            string fileContains = string.Empty;
            while (fileContains != null)
            {
                fileContains = reader.ReadLine();
                list.Add(fileContains);
            }
        }
    }

    static void Write(List<string> list)
    {
        StreamWriter writeToFile = new StreamWriter("../../new.txt", true);
        using (writeToFile)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    writeToFile.WriteLine(Regex.Replace(list[i], "\\bstart\\b", "finish"));
                }
            }
        }
    }

    static void Main()
    {
        string input = @"../../text.txt";
        Read(input);
        Write(list);
    }
}