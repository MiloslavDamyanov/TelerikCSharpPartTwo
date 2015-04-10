using System;

class CountSubstring
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we re drinking all the day. We will move out of it in 5 days.";
        int count = 0;
        int index = text.IndexOf("in", 0);
        while (index != -1)
        {
            count++;
            index = text.ToLower().IndexOf("in", index + 1);
        }

        Console.WriteLine(count);
    }
}
