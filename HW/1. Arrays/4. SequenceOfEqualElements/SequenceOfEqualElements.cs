using System;

class SequenceOfEqualElements
{
    static void Main()
    {
        int[] numbers = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

        int bestLength = 1, maxIndex = 0;
        for (int i = 1, length = 1; i < numbers.Length; i++)
        {
            if (numbers[i - 1] == numbers[i])
            {
                length = length + 1;
            }
            else
            {
                length = 1;
            }

            if (length > bestLength)
            {
                bestLength = length;
                maxIndex = i - length + 1;
            }
        }

        for (int i = 0; i < bestLength; i++)
        {
            Console.Write("{0} ", numbers[maxIndex + i]);
        }

        Console.WriteLine();
    }
}