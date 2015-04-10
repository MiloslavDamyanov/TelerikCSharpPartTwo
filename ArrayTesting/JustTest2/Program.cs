using System;

class JustTest1
{
    static void Main()
    {
        int[,] matrix = 
        {
            {1,2,3,4},
            {5,6,7,8}
        };

        Console.WriteLine(matrix.GetLength(0)); // 2
        Console.WriteLine(matrix.GetLength(1)); // 4

    }
}