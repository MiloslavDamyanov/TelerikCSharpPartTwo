using System;
using System.Text;

class TwentyChars
{
    private static void Output(string str)
    {
        StringBuilder newString = new StringBuilder();
        newString.Append(str);
        if (newString.Length < 20)
        {
            Console.WriteLine(newString + new string('*', 20 - newString.Length));
        }
        else
        {
            Console.WriteLine(newString);
        }
    }

    static void Main()
    {
        Console.Write("String: ");
        string str = Console.ReadLine();
        Output(str);
    }

}

//if (newStr.Length < 20)
//        {
//            while (newStr.Length <= 20)
//            {
//                newStr.Append("*");
//            }
//            Console.WriteLine(newStr);
//        }
//        else
//        {
//            Console.WriteLine(newStr);
//        }













