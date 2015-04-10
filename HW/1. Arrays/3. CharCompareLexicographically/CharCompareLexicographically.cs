using System;

class CharCompareLexicographically
{
    static void Main()
    {
        char[] firstSymbol = { 'a', 'c', 'b', 'h' };
        char[] secondSymbol = { 'a', 'b', 'c', 'd' };
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(firstSymbol[i].CompareTo(secondSymbol[i]));
        }
    }
}