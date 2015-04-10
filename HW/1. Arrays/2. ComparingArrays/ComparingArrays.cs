using System;

class ComparingArrays
{
    static void Main()
    {
        bool equal = false;
        Console.Write("Enter length of first array: ");
        int firstArrLength = int.Parse(Console.ReadLine());

        Console.Write("Enter length of second array: ");
        int secondArrLength = int.Parse(Console.ReadLine());

        string[] firstArray = new string[firstArrLength];
        string[] secondArray = new string[secondArrLength];

        Console.WriteLine("\nFirst array\n");
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("value {0}: ", i + 1);
            firstArray[i] = Console.ReadLine();
        }

        Console.WriteLine("\nSecond array\n");
        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.Write("value {0}: ", i + 1);
            secondArray[i] = Console.ReadLine();
        }

        // comparing length of arrays
        if (firstArrLength == secondArrLength)
        {
            for (int i = 0; i < firstArrLength; i++)
            {
                // comparing values 
                if (firstArray[i] == secondArray[i])
                {
                    equal = true;
                }
                else
                {
                    equal = false;
                }
            }
        }
        else
        {
            equal = false;
        }

        if (equal)
        {
            Console.WriteLine("\nArrays are equal !");
        }
        else
        {
            Console.WriteLine("\nArrays are different !");
        }
    }
}