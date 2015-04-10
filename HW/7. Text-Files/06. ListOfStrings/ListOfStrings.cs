using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file
class ListOfStrings
{
    static void SortList(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
        List<string> list = new List<string>();
        using (reader)
        {
            string fileContains = string.Empty;
            while (fileContains != null)
            {
                fileContains = reader.ReadLine();
                list.Add(fileContains);
            }

            list.Sort();

            StreamWriter writeToFile = new StreamWriter("../../sortedList.txt", false);
            using (writeToFile)
            {
                foreach (var newList in list)
                {
                    if (newList != null)
                    {
                        writeToFile.WriteLine(newList);
                    }
                }
            }
        }
    }

    static void Main()
    {
        SortList("../../list.txt");
    }
}