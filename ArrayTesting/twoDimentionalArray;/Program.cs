using System;

class Program
{
    static void Main()
    {
        Console.Write("Number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Number of colums: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] twoDimArray = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("[{0},{1}] = ", row, col);
                twoDimArray[row, col] = int.Parse(Console.ReadLine());
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("  {0}", twoDimArray[row, col]);
            }

            Console.WriteLine();
        }
    }
}