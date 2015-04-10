using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int[] reversed = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            reversed[arr.Length - i - 1] = arr[i];
        }
        // записване на двата масива в нов с обща дължина на двата масива 
        int length = reversed.Length + arr.Length;
        int[] newArray = new int[length];
        for (int i = 0; i < length / 2; i++)
        {
            newArray[i] = arr[i];
            if (i == length / 2 - 1)
            {
                length = arr.Length * 2;
                for (int k = length / 2, j = 0; k < length; j++, k++)
                {
                    newArray[k] = reversed[j];
                }
            }
        }
        // отпечатване на масива с for и с foreach 
        for (int i = 0; i < newArray.Length; i++)
        {
            Console.Write("{0} ", newArray[i]);
        }
        Console.WriteLine("\r");


        foreach (var newTmpArr in newArray)
        {
            Console.Write("{0} ", newTmpArr);
        }

        for (int i = 0; i < arr.Length; i += 2) // изкарва само четните 
        {
            Console.WriteLine(arr[i]);
        }
    }
}