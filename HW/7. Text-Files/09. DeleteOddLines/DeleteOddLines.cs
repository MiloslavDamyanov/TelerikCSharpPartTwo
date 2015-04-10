using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Write a program that deletes from given text file all odd lines. The result should be in the same file.
class DeleteOddLines
{
    static List<string> list = new List<string>();

    static void ReadFile(string file)
    {
        StreamReader reader = new StreamReader(file);
        string text = string.Empty;
        int count = 0;
        using (reader)
        {
            while (text != null)
            {
                count++;                
                text = reader.ReadLine();
                if (count % 2 == 0)
                {                    
                    list.Add(text);
                }
            }                 
        }
    }

    static void WriteToFile(string file)
    {
        StreamWriter write = new StreamWriter(file);
        using (write)
        {
            for (int i = 0; i < list.Count; i++)
            {
                write.WriteLine(list[i]);
            }
        }

        Console.WriteLine("All odd lines are deleted!");
    }

    static void Main()
    {
        string file = @"../../text.txt";
        ReadFile(file);
        WriteToFile(file);
    }
}

// Text:
// Although the StringBuilder class generally offers better 
// performance than the String class, you should not automatically 
// replace String with StringBuilder whenever you want to manipulate strings. 
// Performance depends on the size of the string, the amount of memory to be 
// allocated for the new string, the system on which your app is executing, 
// and the type of operation. You should be prepared to test your app to 
// determine whether 