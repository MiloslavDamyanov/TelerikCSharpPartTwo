using System;

class IndexOfLetters
{
    static void Main()
    {
        char cap = 'A';
        char low = 'a';
        char[] capLetters = new char[26];
        char[] lowerLetters = new char[26];

        for (int i = 0; i < 26; i++)
        {
            capLetters[i] = cap;
            lowerLetters[i] = low;
            cap++;
            low++;
        }

        string str = Console.ReadLine();
        char[] word = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            word[i] = (char)str[i];
        }

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < capLetters.Length; j++)
            {
                if (word[i] == capLetters[j] || word[i] == lowerLetters[j])
                {
                    Console.Write("{0} ", j + 1);
                }
            }
        }

        Console.WriteLine();
    }
}