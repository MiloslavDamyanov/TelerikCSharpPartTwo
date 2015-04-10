using System;

class Program
{
    static void Main()
    {
        int[,] matrix = 
        { 
          { 1, 2, 3, 4 },  // row 0 values 
          { 5, 6, 7, 8 },  // row 1 values 
        };

        // The matrix size is 2 x 4 (2 rows , 4 cols)

        int CountRows = matrix.GetLength(0); // брой редове 
        int CountCols = matrix.GetLength(1); // брой колони 

        Console.WriteLine("{0}  {1}",CountRows,CountCols);

    }
}