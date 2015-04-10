using System;

class VariableNumberParameters
{
    // Params
    static int SumNumbers(params int[] numbers)
    {
        int result = 0;
        foreach (var number in numbers)
        {
            result += number;
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine(SumNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
    }
}