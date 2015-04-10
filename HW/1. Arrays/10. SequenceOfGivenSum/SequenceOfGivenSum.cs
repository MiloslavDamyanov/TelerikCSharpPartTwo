using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        int[] myArray = { 4, 3, 1, 4, 2, 5, 8 };
        int result = 11;
        int length = myArray.Length;
        for (int i = 0; i < length; i++)
        {
            for (int j = i, sum = 0; j < length; j++)
            {
                if ((sum += myArray[j]) == result)
                {
                    for (int k = 0, c = j - i + 1; k < c; k++)
                    {
                        Console.Write("{0} ", myArray[i + k]);
                    }
                }
            }
        }

        Console.WriteLine();
    }
}