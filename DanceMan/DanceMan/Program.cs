using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string[,] topPivotChar = new string[6, 3];//The pivot above the legs
        string[,] downPivotChar = new string[3, 3];//The legs of the pivot

        while (true)
        {
            //Generating positions
            Random twoHands = new Random();
            int gettingRandomNumberForTwoHands = twoHands.Next(0, 5);
            Random twoLegs = new Random();
            int gettingRandomNumberForTwoLegs = twoLegs.Next(0, 4);

            //Moving the two hands
            if (gettingRandomNumberForTwoHands == 0)
            {
                topPivotChar = new string[6, 3]
                {
                    { " -", "-", "-" },
                    { "|", "*.*", "|" },
                    { " -", "-", "-" },
                    { " \\", "|", "/" },
                    { "  ", "|", " " },
                    { "  ", "|", " " },
                };
            }
            if (gettingRandomNumberForTwoHands == 1)
            {
                topPivotChar = new string[6, 3]
                {
                    { " -", "-", "-" },
                    { "|", "*.*", "|" },
                    { " -", "-", "-" },
                    { "--", "|", "--" },
                    { "  ", "|", " " },
                    { "  ", "|", " " },
                };
            }
            if (gettingRandomNumberForTwoHands == 2)
            {
                topPivotChar = new string[6, 3]
                {
                    { " -", "-", "-" },
                    { "|", "*.*", "|" },
                    { " -", "-", "-" },
                    { " /", "|", "\\" },
                    { "  ", "|", " " },
                    { "  ", "|", " " },
                };
            }
            if (gettingRandomNumberForTwoHands == 3)
            {
                topPivotChar = new string[6, 3]
                {
                    { " -", "-", "-" },
                    { "|", "*.*", "|" },
                    { " -", "-", "-" },
                    { " \\", "|", "--" },
                    { "  ", "|", " " },
                    { "  ", "|", " " },
                };
            }
            if (gettingRandomNumberForTwoHands == 4)
            {
                topPivotChar = new string[6, 3]
                {
                    { " -", "-", "-" },
                    { "|", "*.*", "|" },
                    { " -", "-", "-" },
                    { "--", "|", "/" },
                    { "  ", "|", " " },
                    { "  ", "|", " " },
                };
            }

            //Moving the two legs
            if (gettingRandomNumberForTwoLegs == 0)
            {
                downPivotChar = new string[3, 3]
                {
                    { " -", "-", "-" },
                    { " | ", "", "|" },
                    { " |",  " ", "|" },
                };
            }
            if (gettingRandomNumberForTwoLegs == 1)
            {
                downPivotChar = new string[3, 3]
                {
                    { " -", "-", " " },
                    { " |", " ", "\\" },
                    { " |", " ", " \\" },
                };
            }
            if (gettingRandomNumberForTwoLegs == 2)
            {
                downPivotChar = new string[3, 3]
                {
                    { " ", " -", "-" },
                    { " /", "", " |" },
                    { "/  ", "", "|" },
                };
            }
            if (gettingRandomNumberForTwoLegs == 3)
            {
                downPivotChar = new string[3, 3]
                {
                    { "  ", "- ", " " },
                    { " /", " ", "\\" },
                    { "/  ", " ", "\\" },
                };
            }

            //Printing the pivot
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(topPivotChar[row, col]);
                }
                Console.WriteLine();
            }

            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    Console.Write(downPivotChar[rows, cols]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}