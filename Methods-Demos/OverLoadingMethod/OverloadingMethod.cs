using System;

class OverloadingMethod
{
    static int Multiplay(int a, int b)
    {
        return a * b;
    }

    static int Multiplay(string a, string b)
    {
        return Multiplay(int.Parse(a), int.Parse(b));
    }

    static int Multiplay(int[] numbers)
    {
        int result = 1;

        // foreach (var num in numbers)
        // {
        //    result *= num;
        // }

        foreach (var num in numbers)
        {
            result = Multiplay(result, num);
        }
        return result;
    }

    static int Multiplay(string[] numbersAsStrings)
    {
        //int[] numbers = new int[numbersAsStrings.Length];
        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    numbers[i] = int.Parse(numbersAsStrings[i]);
        //}
        //return Multiplay(numbers);

        int result = 1;
        foreach (var numStr in numbersAsStrings)
        {
            result = Multiplay(result, int.Parse(numStr));
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine(Multiplay("4", "5"));
        Console.WriteLine(Multiplay(5, 4));
        Console.WriteLine(Multiplay(new int[] { 1, 2, 3, 4 }));
        Console.WriteLine(Multiplay(new string[] { "1", 2.ToString(), "3", "4" }));
    }
}