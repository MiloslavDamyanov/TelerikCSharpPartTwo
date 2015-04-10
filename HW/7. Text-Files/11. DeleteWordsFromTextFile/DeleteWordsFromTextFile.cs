using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Write a program that deletes from a text file all words that start with the prefix "test". 
// Words contain only the symbols 0...9, a...z, A…Z, _.
class DeleteWordsFromTextFile
{
    static List<string> lines = new List<string>();

    static void ReadText(string path)
    {
        try
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string line = string.Empty;
                while (line != null)
                {
                    line = reader.ReadLine();
                    lines.Add(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found !");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have permissions !");
        }
    }

    static void DeleteWords(string output)
    {
        try
        {
            string pattern = @"\btest\w*\b";
            StreamWriter writeToFile = new StreamWriter(output, false);
            using (writeToFile)
            {
                foreach (var line in lines)
                {
                    if (line != null)
                    {
                        writeToFile.WriteLine(Regex.Replace(line, pattern, String.Empty));
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found !");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have permissions !");
        }
        finally
        {
            Console.WriteLine("Complete !");
        }
    }

    static void Main()
    {
        string text = "../../text.txt";
        string output = "../../output.txt";
        ReadText(text);
        DeleteWords(output);
    }
}