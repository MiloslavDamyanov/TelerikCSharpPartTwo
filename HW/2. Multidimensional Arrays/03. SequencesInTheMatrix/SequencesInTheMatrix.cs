using System;

class SequencesInTheMatrix
{
    static void Main()
    {
        string[,] matrix = { { "a", "b", "a", "f" }, { "c", "c", "a", "c" }, { "c", "b", "a", "z" }, };

        PrintMatrix(matrix);

        // vertical                                                               // a
        int nextElement = 1;                                                      // a
        int countOfEqualElements = 0;                                             // a
        int[] lengthOfEqualElemnts = new int[matrix.GetLength(1)];
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == matrix[nextElement, col])
                {
                    countOfEqualElements++;
                    lengthOfEqualElemnts[col] = countOfEqualElements;
                }
            }

            countOfEqualElements = 0;
        }

        // index of max length in LengthOfEqualElemnts[]
        int maxValue = 0;
        int index = 0;
        maxValue = lengthOfEqualElemnts[0];
        for (int i = 0; i < lengthOfEqualElemnts.Length; i++)
        {
            if (lengthOfEqualElemnts[i] > maxValue)
            {
                maxValue = lengthOfEqualElemnts[i];
                index = i;
            }
        }

        Console.Write("\t");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (maxValue == matrix.GetLength(0))
            {
                Console.Write("{0} ", matrix[i, index]);
            }
        }

        Console.WriteLine();

        //------------------------------------------------------------------------------
        // horizontal                                                        // c c c c 
        int nextElementH = 1;
        int countOfEqualElementsH = 0;
        int[] lengthOfEqualElemntsH = new int[matrix.GetLength(0)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == matrix[row, nextElementH])
                {
                    countOfEqualElementsH++;
                    lengthOfEqualElemntsH[row] = countOfEqualElementsH;
                }
            }

            countOfEqualElementsH = 0;
        }

        // index of max length in LengthOfEqualElemnts[]
        int maxValueH = 0;
        int indexH = 0;
        maxValueH = lengthOfEqualElemntsH[0];
        for (int i = 0; i < lengthOfEqualElemntsH.Length; i++)
        {
            if (lengthOfEqualElemntsH[i] > maxValueH)
            {
                maxValueH = lengthOfEqualElemntsH[i];
                indexH = i;
            }
        }

        Console.Write("\t");
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (maxValueH == matrix.GetLength(1))
            {
                Console.Write("{0} ", matrix[indexH, i]);
            }
        }

        Console.WriteLine();

        // diagonal
        // ....
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("  {0}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}

// Tests
// horizontal 
// string[,] matrix = { { "a", "b", "a","f" },    
//                      { "c", "c", "c","c" },    
//                      { "c", "b", "a","z" }, };
// vertical
// string[,] matrix = { { "a", "b", "a","f" },    
//                      { "c", "c", "a","c" },    
//                      { "c", "b", "a","z" }, };