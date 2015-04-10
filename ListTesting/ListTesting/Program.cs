using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> listArray = new List<int>();
        int[] arr = new int[5];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }


        for (int i = 0; i < arr.Length; i++)
        {
            listArray.Add(arr[i]);
        }

        for (int i = 0; i < listArray.Count; i++)
        {
            Console.WriteLine(listArray[i]);
        }

    }
}
