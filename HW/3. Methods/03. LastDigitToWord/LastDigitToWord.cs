using System;

class DigitToWord
{
    static int InputNumber()
    {
        Console.Write("Enter positive number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int GetLastDigit(int number)
    {
        int lastDigit = number % 10;
        return lastDigit;
    }

    static void LastDigitToWord(int digit)
    {
        string[] arr = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        Console.Write("Last digit is: ");
        Console.WriteLine(arr[digit]);
    }

    static void Main()
    {
        int number = InputNumber();
        int lastDigit = GetLastDigit(number);
        LastDigitToWord(lastDigit);
    }
}