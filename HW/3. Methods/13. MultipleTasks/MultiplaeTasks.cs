using System;

class MultiplaeTasks
{
    static void InputReverse()
    {
        Console.Write("\n\nEnter number: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("number must be positive");
            InputReverse();
        }
        else
        {
            ReverseDigits(n);
        }

    }
    static void ReverseDigits(int number)
    {

        int reverse = 0;
        while (number != 0)
        {
            reverse = reverse * 10;
            reverse = reverse + number % 10;
            number = number / 10;
        }
        Console.WriteLine("Reversed Number is: {0}", reverse);
    }

    static void InputAvarage()
    {
        Console.Write("\n\nLength of a sequence! ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Number {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
        Average(array, length);
    }

    static void Average(int[] array, int length)
    {
        int sum = 0;
        for (int i = 0; i < length; i++)
        {
            sum += array[i];
        }
        int average = sum / length;
        Console.WriteLine("Average is : {0}", average);
    }

    static double CalculateEquation(int a, int b)
    {
        return (double)-b / a;
    }

    static void InputLineaEquation()
    {
        Console.WriteLine("Enter a and b:");
        Console.Write("a =  ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b =  ");
        int b = int.Parse(Console.ReadLine());

        if (a != 0)
        {
            Console.WriteLine("CalculateEquation: " + CalculateEquation(a, b));
        }
        else
        {
            Console.WriteLine("Coefficient 'a' should not be zero.");
        }
    }



    static void Menu()
    {
        Console.WriteLine("\t\tChoose a task to slove! ");
        Console.WriteLine("(1) Reverses the digits of a number ");
        Console.WriteLine("(2) Calculates the average of a sequence of integers");
        Console.WriteLine("(3) Linear equation a * x + b = 0");
        Console.Write(": ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: InputReverse();
                break;
            case 2: InputAvarage();
                break;
            case 3: InputLineaEquation();
                break;
            default: Menu();
                break;
        }
    }
    static void Main()
    {
        Menu();
    }
}