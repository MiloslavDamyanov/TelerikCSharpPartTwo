using System;

public class ForeachTest
{
    public static void Main()
    {
        string[] capitals = { "Sofia", "London", "Moscow", "Washington", "Paris" };
        foreach (string capital in capitals)
        {
            Console.WriteLine(capital);
        }
    }
}