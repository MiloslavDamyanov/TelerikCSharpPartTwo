using System;

class ReverseDigits
{
    static int Reverse(int n)
    {
        int reverse = 0;
        while (n != 0)
        {
            reverse = reverse * 10;
            reverse = reverse + n % 10;
            n = n / 10;
        }
        return reverse;
    }

    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Reverse(number));
    }
}