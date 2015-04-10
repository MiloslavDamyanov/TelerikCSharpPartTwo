using System;

class Program
{
    static void Month(int month)
    {
        string[] str = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        Console.WriteLine(str[month - 1]);
    }
    static void Main()
    {
        Console.Write("Month: ");
        int num = int.Parse(Console.ReadLine());
        Month(num);
    }
}