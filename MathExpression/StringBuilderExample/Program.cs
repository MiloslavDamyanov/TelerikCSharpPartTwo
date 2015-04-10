using System;
using System.Text;
using System.Collections.Generic;
class StringBuilderExample
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();

        text.Append("Miloslav ");
        text.Append("Ivanov ");
        text.Append("Damyanov ");
        text.Append("born: ");
        text.Append("1987 ");
        text.Append("month: ");
        text.Append("August");
        text.Append("Date: ");
        text.Append("28");

        Console.WriteLine(text.ToString());

    }
}