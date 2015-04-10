using System;
using System.Collections.Generic;
using System.Text;

class ExtractSenteces
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        List<string> sentences = new List<string>();
        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            temp.Append(text[i]);
            if (text[i] == '.')
            {
                sentences.Add(temp.ToString().TrimStart(' ', '\0'));
                temp.Clear();
            }
        }

        for (int i = 0; i < sentences.Count; i++)
        {
            if (sentences[i].Contains(" in "))
            {
                Console.WriteLine(sentences[i]);
            }
        }
    }
}