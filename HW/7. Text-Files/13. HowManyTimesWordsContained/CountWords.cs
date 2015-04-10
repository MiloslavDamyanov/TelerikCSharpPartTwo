using System;
using System.Collections.Generic;
using System.IO;

// Write a program that reads a list of words from a file words.txt 
// and finds how many times each of the words is contained in another 
// file test.txt. The result should be written in the file result.txt 
// and the words should be sorted by the number of their occurrences in 
// descending order. Handle all possible exceptions in your methods.
class Count
{
    static List<string> listWords = new List<string>();

    static void WriteToFIle(List<string> list)
    {
        string result = @"..\..\result.txt";
        StreamWriter writer = new StreamWriter(result, false);
        using (writer)
        {
            list.Sort();
            list.Reverse();
            foreach (var item in list)
            {
                writer.WriteLine(item);
            }
        }
    }

    static List<string> CountWords()
    {
        string fileName = @"..\..\text.txt";
        List<string> str = new List<string>();
        for (int i = 0; i < listWords.Count; i++)
        {
            string word = listWords[i];

            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                int occurrences = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    int index = line.IndexOf(word);
                    while (index != -1)
                    {
                        occurrences++;
                        index = line.IndexOf(word, index + 1);
                    }

                    line = reader.ReadLine();
                }

                str.Add(occurrences.ToString() + " - " + word);
            }
        }

        return str;
    }

    static void ReadWord()
    {
        StreamReader read = new StreamReader("../../words.txt");
        using (read)
        {
            string word = string.Empty;
            while (word != null)
            {
                word = read.ReadLine();
                if (word != null)
                {
                    listWords.Add(word);
                }
            }
        }
    }

    static void Main()
    {
        ReadWord();
        List<string> result = CountWords();
        WriteToFIle(result);
    }
}