using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Write a program that compares two text files line by line and prints the number 
// of lines that are the same and the number of lines that are different. 
// Assume the files have equal number of lines.
class CompareLines
{
    static void Compare(string path1, string path2)
    {
        StreamReader readFirst = new StreamReader(path1, Encoding.GetEncoding("Windows-1251"));
        StreamReader readSecond = new StreamReader(path2, Encoding.GetEncoding("Windows-1251"));
        int lineCount = 0;
        List<int> equal = new List<int>();
        List<int> different = new List<int>();
        using (readFirst)
        {
            using (readSecond)
            {
                string firstFile = string.Empty;
                string secondFile = string.Empty;
                while (firstFile != null)
                {
                    firstFile = readFirst.ReadLine();
                    secondFile = readSecond.ReadLine();
                    lineCount++;
                    if (firstFile == secondFile)
                    {
                        equal.Add(lineCount);
                    }
                    else if (firstFile != secondFile)
                    {
                        different.Add(lineCount);
                    }
                }
            }

            Output(equal, different);
        }
    }

    static void Output(List<int> equal, List<int> different)
    {
        Console.Write("Equal lines are: ");
        foreach (var eq in equal)
        {
            Console.Write("{0} ", eq);
        }

        Console.Write("\nDifferent lines are: ");
        foreach (var df in different)
        {
            Console.Write("{0} ", df);
        }

        Console.WriteLine();
    }

    static void Main()
    {
        string firstFile = @"../../file1.txt";
        string secondFile = @"../../file2.txt";
        Compare(firstFile, secondFile);
    }
}
