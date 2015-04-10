using System;
using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
           
            List<string> listStr = new List<string>() { "sometext" };

            listStr.Add("c");

            foreach (var item in listStr)
            {
                Console.WriteLine(item);
            }
        }
    }