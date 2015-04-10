using System;

class SequenceOfMaxSum
{
    static void Main()
    {
        int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int maxSum = numbers[0];
        int length = 1;
        int index = 0;

        for (int i = 1, sum = numbers[0], currentIndex = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];

            if (numbers[i] > sum)
            {
                sum = numbers[i];
                currentIndex = i;
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                index = currentIndex;
                length = i - currentIndex + 1;
            }
        }

        for (int i = 0; i < length; i++)
        {
            Console.Write("{0} ", numbers[index + i]);
        }

        Console.WriteLine();
    }
}