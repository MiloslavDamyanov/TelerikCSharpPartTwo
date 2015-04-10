using System;

class IsLeapYear
{
    static void LeapYear(int year)
    {
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} is leap year !", year);
        }
        else
        {
            Console.WriteLine("Year is not leap !");
        }
    }

    static void Main()
    {
        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());
        LeapYear(year);
    }
}