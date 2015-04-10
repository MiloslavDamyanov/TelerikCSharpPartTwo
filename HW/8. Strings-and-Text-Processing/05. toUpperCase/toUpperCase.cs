using System;
using System.Collections.Generic;
using System.Text;

class toUpperCase
{
    static List<int> startIndex = new List<int>();
    static List<int> endIndex = new List<int>();
    static List<int> list = new List<int>();

    private static void GetIndexes(string text)
    {
        string target = ">";
        int index = text.IndexOf(target, 0);
        startIndex.Add(index);
        while (index != -1)
        {
            index = text.IndexOf(target, index + 1);
            if (index != -1)
            {
                startIndex.Add(index);
            }
        }
        target = "</";
        index = text.IndexOf(target, 0);
        endIndex.Add(index);
        while (index != -1)
        {
            index = text.IndexOf(target, index + 1);
            if (index != -1)
            {
                endIndex.Add(index);
            }
        }
        GetIndexesStartEnd();
    }

    private static void GetIndexesStartEnd()
    {
        endIndex.Reverse();
        startIndex.Reverse();
        for (int i = 0; i < endIndex.Count; i++)
        {
            for (int j = 0; j < startIndex.Count; j++)
            {
                if (endIndex[i] > startIndex[j])
                {
                    list.Add(startIndex[j]);
                    list.Add(endIndex[i]);
                    break;
                }
            }
        }

        list.Sort();
    }

    private static void Output(string text)
    {
        StringBuilder newText = new StringBuilder();
        List<int> start = new List<int>();
        List<int> end = new List<int>();
        int count = 0;

        for (int j = 0; j < list.Count; j++)
        {
            if (j % 2 == 0)
            {
                start.Add(list[j]);
            }
            else
            {
                end.Add(list[j]);
            }
        }

        for (int i = 0; i < text.Length; i++)
        {
            newText.Append(text[i]);

            if (i == start[count])
            {
                newText.Append(text.ToUpper(), start[count] + 1, end[count] - start[count]);
                i = end[count];
                count++;
                if (count >= start.Count)
                {
                    count--;
                }
            }
        }
        newText.Replace("<upcase>", "");
        newText.Replace("</upcase>", "");
        Console.WriteLine(newText);

    }

    static void Main()
    {
        const string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        GetIndexes(text);
        Output(text);
    }
}