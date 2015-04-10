using System;
using System.Collections.Generic;

class WorkingDays
{
    static DateTime[] holidays = { new DateTime(2013, 09, 06), // Ден на Съединението Официален празник
                                   new DateTime(2013, 09, 22), // Ден на Независимостта на България 
                                   new DateTime(2013, 12, 14), // Заработване
                                   new DateTime(2013, 12, 24), // Коледа
                                   new DateTime(2013, 12, 25), // Коледа
                                   new DateTime(2013, 12, 26), // Коледа
                                   new DateTime(2013, 12, 31), // Нова Година                                   
                                 };

    static int CountDays(DateTime today, DateTime endDate)
    {
        int totalDays = (int)(endDate - today).TotalDays + 1;
        return totalDays;
    }

    static void GetWorkingDays(DateTime today, int totalDays)
    {
        DateTime[] arr = new DateTime[totalDays + 1];

        // add all days to array
        for (int i = 1; i <= totalDays; i++)
        {
            arr[i] = today.AddDays(i);
        }

        int weekendCounter = CountSatSun(totalDays, arr);
        int holidaysCounter = CountHoliDays(totalDays, arr);
        int result = totalDays - (weekendCounter + holidaysCounter);
        Console.WriteLine(result);
    }

    static int CountSatSun(int totalDays, DateTime[] arr)
    {
        int weekendCounter = 0;
        for (int i = 0; i <= totalDays; i++)
        {
            if (DayOfWeek.Saturday == arr[i].DayOfWeek || DayOfWeek.Sunday == arr[i].DayOfWeek)
            {
                weekendCounter++;
            }
        }

        return weekendCounter;
    }

    static int CountHoliDays(int totalDays, DateTime[] arr)
    {
        int holidaysCounter = 0;
        for (int i = 0; i < holidays.Length; i++)
        {
            for (int j = 0; j <= totalDays; j++)
            {
                if (holidays[i].Date == arr[j].Date)
                {
                    holidaysCounter++;
                }
            }
        }

        return holidaysCounter;
    }

    static void Main()
    {
        DateTime today = DateTime.Now;
        DateTime endDate = new DateTime(2013, 12, 31);
        int totalDays = CountDays(today, endDate);
        GetWorkingDays(today, totalDays);
    }
}
