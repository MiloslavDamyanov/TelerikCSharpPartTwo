using System;

class MaxPlatform
{
    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(" {0}", matrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static int Sum(int[,] matrix, int k, int row, int col)
    {
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                sum += matrix[row + i, col + j];
            }
        }

        return sum;
    }

    static void Main()
    {
        int[,] matrix = { { 124, 354, 105, 240 }, { 541, 324, 300, 999 }, { 8, 210, 9, 12 }, { 1, 22, 3, 47 } };
        int k = 3;

        int maxSum = int.MinValue;
        int maxRow = int.MinValue;
        int maxCol = int.MinValue;

        for (int row = 0; row <= matrix.GetLength(0) - k; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - k; col++)
            {
                int currentSum = Sum(matrix, k, row, col);

                if (currentSum >= maxSum)
                {
                    maxSum = currentSum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        // Print matrix
        int[,] result = new int[k, k];

        for (int row = 0; row < k; row++)
        {
            for (int col = 0; col < k; col++)
            {
                result[row, col] = matrix[maxRow + row, maxCol + col];
            }
        }

        PrintMatrix(result);
    }
}