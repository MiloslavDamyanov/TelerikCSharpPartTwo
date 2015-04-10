/*  Write a method ReadNumber(int start, int end) that enters an integer number in given range 
 *  [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. 
 *  Using this method write a program     that enters 10 numbers:
 *  a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
using System;

class ReadNumberInRange
{
    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());
        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return number;
    }

    static void Main()
    {
        int number = 1;
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter number in range [{0}...{1}]: ", number, 100);
                number = ReadNumber(number, 100);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Number is out of range");
        }
        catch (FormatException)
        {
            Console.WriteLine("This is not a number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Value was either too large or too small for an Int32.");
        }
    }
}