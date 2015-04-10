using System;

class GetMaxNum
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        int maxNum = Math.Max(firstNumber, secondNumber);
        return maxNum;
    }

    static void Main()
    {
        Console.Write("First number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());
        int maxOfTwoNumbers = GetMax(firstNumber, secondNumber);
        Console.WriteLine("Max number is: {0}", GetMax(maxOfTwoNumbers, thirdNumber));
    }
}