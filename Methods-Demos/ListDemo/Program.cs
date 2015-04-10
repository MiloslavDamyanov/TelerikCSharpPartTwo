using System;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            List<int> number = new List<int>();

            int n = 5;

            for (int i = 0; i < n; i++)
            {
                number.Add(i + 1);
            }

            foreach (int num in number)
            {
                Console.WriteLine(num);
            }
        }
    }