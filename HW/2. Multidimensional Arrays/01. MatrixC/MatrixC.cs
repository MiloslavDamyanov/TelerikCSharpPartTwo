using System;

class MatrixC
{
    static void Main()
    {
        int n = 4;

        int[,] matrix = new int[n, n];
        int counter = 1;

        for (int row = 0; row <= n - 1; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                matrix[n - row + col - 1, col] = counter++;
            }
        }

        for (int row = n - 2; row >= 0; row--)
        {
            for (int col = row; col >= 0; col--)
            {
                matrix[row - col, n - col - 1] = counter++;
            }
        }

        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] <= 9)
                {
                    Console.Write("  {0}", matrix[row, col]);
                }
                else
                {
                    Console.Write(" {0}", matrix[row, col]);
                }
            }

            Console.WriteLine();
        }
    }
}