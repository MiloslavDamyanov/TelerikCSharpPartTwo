using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Dict
{
    static List<string> explanations = new List<string>();
    static List<string> term = new List<string>();
    static Dictionary<string, string> dictionary = new Dictionary<string, string>();

    static void ReadDict()
    {
        StreamReader readLine = new StreamReader("../../dictionary.txt");
        string line = string.Empty;
        using (readLine)
        {
            while (line != null)
            {
                line = readLine.ReadLine();
                if (line != null)
                {
                    explanations.Add(line);
                }
            }
        }
    }

    static void ParseTerms()
    {
        StringBuilder word = new StringBuilder();
        for (int i = 0; i < explanations.Count; i++)
        {
            for (int j = 0; j < explanations[i].Length; j++)
            {
                if (explanations[i][j] != '-')
                {
                    word.Append(explanations[i][j]);
                }
                else if (explanations[i][j] == '-')
                {
                    term.Add(word.ToString().TrimEnd(' ', '\0').ToUpper());
                    word.Clear();
                    break;
                }
            }
        }

        AddToDictionary();
    }

    static void AddToDictionary()
    {
        for (int i = 0; i < term.Count; i++)
        {
            dictionary.Add(term[i], explanations[i]);
        }
    }

    static void Output(string term)
    {
        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            if (term == pair.Key)
            {
                Console.WriteLine(pair.Value);
            }
        }

        if (!dictionary.ContainsKey(term))
        {
            Console.WriteLine("not found!");
        }
    }

    static void Main()
    {
        string term = ".net";
        ReadDict();
        ParseTerms();
        Output(term.ToUpper());
    }
}