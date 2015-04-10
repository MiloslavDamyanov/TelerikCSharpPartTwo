using System;

class MatrixA
{
    // fill matrix
    private static int Input(int[,] matrix, int counter)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[col, row] = counter;
                counter++;
            }
        }

        return counter;
    }

    // print matrix
    private static void Output(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(" {0}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        int rows = 4;
        int cols = 4;
        int[,] matrixA = new int[rows, cols];
        int counter = 1;
        Input(matrixA, counter);
        Output(matrixA);
    }
}