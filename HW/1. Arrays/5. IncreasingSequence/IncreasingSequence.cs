using System;

class IncreasingSequence
{
    static void Main()
    {
        int[] array = { 1, 2, 4, 8, 1, 2, 4 };

        int counter = 1;
        int maxCounter = 1;
        int index = 0;
        int startIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[i - 1])
            {
                counter++;
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    startIndex = index;
                }
            }
            else
            {
                counter = 1;
                index = i;
            }
        }

        int endIndex = (startIndex + maxCounter) - 1;
       
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();      
    }
}