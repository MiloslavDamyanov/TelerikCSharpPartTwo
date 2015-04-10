using System;

class BinarySearch
{
    static void Main()
    {
        int[] numbers = { 2, 5, 6, 18, 19, 25, 46, 78, 102, 114 };
        int startIndex = 0;
        int endIndex = numbers.Length;
        int middle = (startIndex + endIndex) / 2;
        Console.WriteLine("Middle {0}", middle);
        Console.WriteLine("2, 5, 6, 18, 19, 25, 46, 78, 102, 114");
        Console.WriteLine();
        Console.Write("value: ");
        int value = int.Parse(Console.ReadLine()); 

        while (value > 0)
        {
            while (value < numbers[middle])
            {
                endIndex = middle;
                middle = (endIndex + startIndex) / 2;
                if (value == numbers[middle])
                {
                    Console.WriteLine("index: {0}", middle);
                }
            }

            while (value > numbers[middle])
            {
                startIndex = middle;
                middle = (endIndex + startIndex) / 2;
                if (value == numbers[middle])
                {
                    Console.WriteLine("index: {0}", middle);
                }
            }

            break;
        }
    }
}