using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Write a program that replaces all occurrences of the substring "start" with the 
// substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
class SubstringReplace
{
    static void Read(string path)
    {
        StreamReader reader = new StreamReader(path);
        List<string> list = new List<string>();
        using (reader)
        {
            string fileContains = string.Empty;
            while (fileContains != null)
            {
                fileContains = reader.ReadLine();
                if (fileContains == null)
                {
                    break;
                }
                else if (fileContains.Contains(":088-"))
                {
                    list.Add(fileContains.Replace(":088-", "+35988"));
                }
            }

            Write(list);
        }
    }

    static void Write(List<string> list)
    {
        StreamWriter writeToFile = new StreamWriter("../../new.txt", false);
        using (writeToFile)
        {
            foreach (var newlist in list)
            {
                writeToFile.WriteLine(newlist);
            }
        }
    }

    static void Main()
    {
        string input = @"../../00001.vcf";
        Read(input);
    }
}