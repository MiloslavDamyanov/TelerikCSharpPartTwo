using System;

class Eratosthenes 
{
    static void Main()
    {
        bool[] array = new bool[(int)10000000];

        for (int i = 2; i * i <= array.Length; i++)
        {
            if (!array[i])
            {
                for (int j = i * i; j < array.Length; j = j + i)
                {
                    array[j] = true;
                }
            }
        }

        for (int i = 2; i < array.Length; i++)
        {
            if (!array[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}

/*
 bg.wikipedia.org/wiki/Решето_на_Ератостен
 */