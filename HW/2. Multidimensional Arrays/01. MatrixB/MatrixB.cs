using System;

class MatrixB
{
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

    // fill matrix
    private static int Input(int[,] matrix, int counter, int n)
    {
        int[] arr = new int[n * n];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }
        
        Array.Reverse(arr, n, n);
        Array.Reverse(arr, 12, n);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[col, row] = arr[counter];
                counter++;
            }
        }

        return counter;
    }

    static void Main()
    {
        int n = 4;
        int[,] matrix = new int[n, n];
        int counter = 0;
        Input(matrix, counter, n);
        Output(matrix);
    }
}