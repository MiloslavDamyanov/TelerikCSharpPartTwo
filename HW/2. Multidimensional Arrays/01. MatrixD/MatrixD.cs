using System;

class MatrixD
{
    static void Main()
    {
        int n = 4;
        int[,] matrix = new int[n, n];
        string direction = "down";
        int currentRow = 0;
        int currentCol = 0;

        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "down" && (currentRow >= n || matrix[currentRow, currentCol] != 0))
            {
                currentCol++;
                currentRow--;
                direction = "right";
            }
            else if (direction == "right" && (currentCol >= n || matrix[currentRow, currentCol] != 0))
            {
                currentCol--;
                currentRow--;
                direction = "up";
            }
            else if (direction == "up" && (currentRow < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentRow++;
                currentCol--;
                direction = "left";
            }
            else if (direction == "left" && (currentCol < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentCol++;
                currentRow++;
                direction = "down";
            }

            matrix[currentRow, currentCol] = i;

            // directions
            if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "left")
            {
                currentCol--;
            }
            else if (direction == "up")
            {
                currentRow--;
            }
        }

        // print matrix
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] <= 9)
                {
                    Console.Write("  " + matrix[row, col]);
                }
                else
                {
                    Console.Write(" " + matrix[row, col]);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}