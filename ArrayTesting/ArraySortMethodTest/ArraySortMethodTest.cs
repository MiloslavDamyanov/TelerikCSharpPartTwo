using System;

class ArraySortMethodTest
{
    static void Main()
    {
        int[] myArray = { 1, 5, 2, 3, 4, 7, 9, 10, 8, 6 };
        Array.Sort(myArray);
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine(myArray[i]);
        }
    }
}