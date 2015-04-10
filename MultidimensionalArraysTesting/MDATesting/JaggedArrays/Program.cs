using System;

class JaggedArrays
{
    static void Main()
    {
        // jagged array
        int[][] jagged = new int[3][]; // масив от масив 
        jagged[0] = new int[3];
        jagged[1] = new int[2];
        jagged[2] = new int[5];

        // cube
        int[, ,] cube = new int[3, 2, 4] 
        {
            {
                {1,2,3,4},
                {5,6,7,8},
            },
            {
                {-1,-2,-3,-4},
                {-5,-6,-7,-8},
            },
            {
                {10,20,30,40},
                {50,60,70,80},
            },

        };

        for (int height = 0; height < cube.GetLength(0); height++)
        {
            for (int row = 0; row < cube.GetLength(1); row++)
            {
                for (int col = 0; col < cube.GetLength(2); col++)
                {
                    Console.Write(cube[height,row,col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();  
        }

        Console.WriteLine(cube.Rank); // общ брой размерности

    }
}