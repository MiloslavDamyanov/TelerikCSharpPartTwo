using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        Console.Write("string: ");
        string str = Console.ReadLine();
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine(charArray);
    }
}