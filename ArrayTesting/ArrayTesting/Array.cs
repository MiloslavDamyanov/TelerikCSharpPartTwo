using System;

public class ArrayTestApp
{
    public static void Main()
    {
        string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        for (int i = 0; i < dayOfWeek.Length; i++)
        {
            Console.WriteLine(dayOfWeek[i].ToLower());
        }
    }
}