using System;
using System.Collections.Generic;

class ListTest
{
    static void Main()
    {
        List<int> newList = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            newList.Add(i);
        }

        for (int i = 0; i < newList.Count; i++)
        {
            Console.WriteLine(newList[i]);
        }
        Console.WriteLine("Memory: {0} bytes",newList.Capacity);
    }
}

