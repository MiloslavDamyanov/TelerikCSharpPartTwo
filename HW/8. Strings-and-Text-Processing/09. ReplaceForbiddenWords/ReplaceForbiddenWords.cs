using System;
using System.Text;

class ReplaceForbiddenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] words = { "Microsoft", "PHP", "CLR" };
        StringBuilder newText = new StringBuilder();
        newText.Append(text);
        for (int i = 0; i < words.Length; i++)
        {
            newText.Replace(words[i], new string('*', words[i].Length));
        }

        Console.WriteLine(newText);
    }
}
