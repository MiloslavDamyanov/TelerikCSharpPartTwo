using System;

class BatesGoikoTower
{
    static void Main()
    {
        char dot = '.';
        char slash = '/';
        char backSlash = '\\';
        char dash = '-';

        int n = int.Parse(Console.ReadLine());

        int counter = n - 1;
        int dashCounter = 0;
        int dotCounter = 0;
        for (int row = 0; row < n; row++)
        {
            Console.Write(new string(dot, counter));
            Console.Write(new string(slash, 1));

            if (row < 5)
            {
                if (row % 2 == 0)
                {
                    Console.Write(new string(dot, dotCounter));
                }
                else if (row % 2 != 0)
                {
                    Console.Write(new string(dash, dashCounter));
                }
            }
            if (row >= 5 && row < 6)
            {
                Console.Write(new string(dot, dotCounter));
            }
            else if (row == 6)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 6 && row <= 9)
            {
                Console.Write(new string(dot, dotCounter));
            }
            else if (row == 10)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 10 && row <= 14)
            {
                Console.Write(new string(dot, dotCounter));
            }
            else if (row == 15)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 15 && row <= 20)
            {
                Console.Write(new string(dot, dotCounter));
            }
            else if (row == 21)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 21 && row <= 27)                                  
            {
                Console.Write(new string(dot, dotCounter));
            }
            else if (row == 28)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 28 && row <= 35)
            {
                Console.Write(new string(dot, dotCounter));     
            }
            else if (row == 36)
            {
                Console.Write(new string(dash, dashCounter));
            }
            else if (row > 36 && row <= 44)
            {
                Console.Write(new string(dot, dotCounter)); 
            }

            Console.Write(backSlash);
            Console.WriteLine(new string(dot, counter));
            counter--;
            dashCounter += 2;
            dotCounter += 2;
        }



    }
}


