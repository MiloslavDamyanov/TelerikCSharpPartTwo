 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReverseWords
{
    static List<string> listWords = new List<string>();
    static List<string> templistWords = new List<string>();
    static List<int> indexPunctuationMark = new List<int>();
    static List<char> punctuationMark = new List<char>();

    private static void AddWordsToList(string text)
    {
        StringBuilder txt = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            txt.Append(text[i]);
            if (text[i] == ' ' || text[i] == '!' || text[i] == '?' || text[i] == '.' || text[i] == ':')
            {
                listWords.Add(txt.ToString().TrimEnd(' ', '\0'));
                txt.Clear();
            }
        }
    }

    private static void GetIndexOfPunctuationMark()
    {
        for (int i = 0; i < listWords.Count; i++)
        {
            if (listWords[i].Contains(',') || listWords[i].Contains('.') || listWords[i].Contains('?') || listWords[i].Contains('!') || listWords[i].Contains(';') || listWords[i].Contains(':'))
            {
                indexPunctuationMark.Add(i);
                if (i <= listWords.Count - 1)
                {
                    punctuationMark.Add(listWords[i][listWords[i].Length - 1]);
                }

                templistWords.Add(listWords[i].TrimEnd(listWords[i][listWords[i].Length - 1], '\0'));
            }
            else
            {
                templistWords.Add(listWords[i]);
            }
        }
    }

    private static void CreateReversedSentece()
    {
        StringBuilder sentence = new StringBuilder();
        templistWords.Reverse();
        int j = 0;
        for (int i = 0; i < templistWords.Count; i++)
        {
            if (templistWords[i] == templistWords[indexPunctuationMark[j]])
            {
                sentence.Append(templistWords[i] + punctuationMark[j] + " ");
                j++;
            }
            else
            {
                sentence.Append(templistWords[i] + " ");
            }
        }

        Console.WriteLine(sentence);
    }

    static void Main()
    {
        string text = "C# is not C++, not PHP and not Delphi!";
        AddWordsToList(text);
        GetIndexOfPunctuationMark();
        CreateReversedSentece();
    }
}