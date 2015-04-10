using System;
using System.Collections.Generic;

class PrintDifferentLetters
{

    static void Main()
    {
        Dictionary<char, int> letterCount = new Dictionary<char, int>();
        string str = "test test";
        char letter = 'a';
        int count = 1;
        for (int i = 0; i < 26; i++)
        {
            letterCount.Add(letter, 0);
            letter++;
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (letterCount.ContainsKey(str[i]))
            {
                
            }
        }
    }
}

//static void AddToDictionary()
//   {
//       for (int i = 0; i < term.Count; i++)
//       {
//           dictionary.Add(term[i], explanations[i]);
//       }
//   }

//   static void Output(string term)
//   {
//       foreach (KeyValuePair<string, string> pair in dictionary)
//       {
//           if (term == pair.Key)
//           {
//               Console.WriteLine(pair.Value);
//           }
//       }