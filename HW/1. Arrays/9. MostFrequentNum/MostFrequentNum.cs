using System;

class MostFrequentNum
{
    static void Main()
    {
        int[] numbers = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        // sorting array
        Array.Sort(numbers);

        // searching sequence of equal elements 
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

        Console.WriteLine("{0}({1} times)", numbers[maxIndex], bestLength);
    }
}