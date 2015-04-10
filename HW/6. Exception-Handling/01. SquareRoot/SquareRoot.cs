// Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class SquareRoot
{
    static void Sqrt(string num)
    {
        try
        {
            int number = int.Parse(num);
            double result = Math.Sqrt(number);
            Console.WriteLine("Square root of {0} is: {1}", number, result);
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("invalid number");
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }

    static void Main()
    {
        Console.Write("Number: ");
        string number = Console.ReadLine();
        Sqrt(number);
    }
}