
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Write a program that removes from a text file all words listed in 
// given another text file. Handle all possible exceptions in your methods.
class RemoveWordsFromText
{
    static List<string> listWords = new List<string>();
    static List<string> lines = new List<string>();

    static void ReadWords(string path)
    {
        try
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string words = string.Empty;
                while (words != null)
                {
                    words = reader.ReadLine();
                    if (words != null)
                    {
                        listWords.Add(words);
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
    }

    static void ReadText(string path)
    {
        try
        {
            StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
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

    static string CreatePattern()
    {
        string pattern = @"\b";
        for (int i = 0; i < listWords.Count; i++)
        {
            pattern += listWords[i];
            if (i != listWords.Count - 1)
            {
                pattern += "|";
            }
            else if (i == listWords.Count - 1)
            {
                pattern += @"\b";
            }
        }

        return pattern;
    }

    static void DeleteWords()
    {
        try
        {
            string pattern = CreatePattern();
            StreamWriter writeToFile = new StreamWriter("../../output.txt", false);
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
        string words = "../../words.txt";
        string text = "../../text.txt";
        ReadWords(words);
        ReadText(text);
        DeleteWords();
    }
}
