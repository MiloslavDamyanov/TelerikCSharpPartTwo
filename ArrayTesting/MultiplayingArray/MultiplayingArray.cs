using System;

class MultiplayingArray
{
    static void Main()
    {
        int n = 20;
        int[] array = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            array[i] = i * 2;
        }

        /*
          for (int i = 0; i < n; i++)
          {
              Console.WriteLine(array[i]);
          } 
        */

        // прави едно и също като for 
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}