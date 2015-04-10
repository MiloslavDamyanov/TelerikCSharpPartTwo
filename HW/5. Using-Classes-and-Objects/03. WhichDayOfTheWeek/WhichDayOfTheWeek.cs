using System;
using System.Globalization;

class WhichDayOfTheWeek
{
    static void Main()
    {        
        DateTime toDay = DateTime.Now;
        Console.WriteLine("Today is: {0}", toDay.DayOfWeek);
    }
}