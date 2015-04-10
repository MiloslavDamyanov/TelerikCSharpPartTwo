using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] newArray = new int[array.Length];

        for (int index = 0; index < array.Length; index++)
        {
            newArray[array.Length - index - 1] = array[index];
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", newArray[i]);
        }
    }
}