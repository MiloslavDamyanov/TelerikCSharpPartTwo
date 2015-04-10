using System;

class UnicodeLiterals
{
    static void Main()
    {
        string str = "Hi!";
        for (int i = 0; i < str.Length; i++)
        {
            Console.Write("\\u{0:X4}", Convert.ToUInt16(str[i]));
        }

        Console.WriteLine();
    }
}