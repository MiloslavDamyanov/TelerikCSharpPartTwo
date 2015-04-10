using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Write a program that reads a text file containing a square matrix of numbers and finds in the matrix
// an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains 
// the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should 
// be a single number in a separate text file. Example:

// 4
// 2 3 3 4
// 0 2 3 4 -----> 17
// 3 7 1 2
// 4 3 3 2
class ReadSquareMatrix
{
    static int MaxPlatform(int[,] matrix)
    {
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine(bestSum);
        return bestSum;
    }

    static void WriteToFile(int fileContains)
    {
        StreamWriter writer = new StreamWriter("../../output.txt", false);
        using (writer)
        {
            writer.WriteLine(fileContains);
        }
    }

    static void Input(int[,] matrix, List<int> numbers)
    {
        int i = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = numbers[i];
                i++;
            }
        }
    }

    static List<int> ConvertToInt(string str)
    {
        List<string> numbers = new List<string>();
        List<int> list = new List<int>();
        string temp = null;
        for (int i = 2; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                temp += str[i];
            }
            else if (str[i] == ' ')
            {
                numbers.Add(temp);
                temp = null;
            }
        }

        numbers.Add(temp);
        temp = null;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] != null)
            {
                list.Add(int.Parse(numbers[i]));
            }
        }

        return list;
    }

    static string ReadFile()
    {
        string row = string.Empty;
        string numbers = null;
        StreamReader readMatrix = new StreamReader("../../matrix.txt");

        using (readMatrix)
        {
            while (row != null)
            {
                row = readMatrix.ReadLine();
                numbers += ' ' + row;
            }
        }

        return numbers;
    }

    static int GetSizeOfMatrix(string numbers)
    {
        int size = int.Parse(numbers[1].ToString());
        return size;
    }

    static void Main()
    {
        string strNumbers = ReadFile();
        int size = GetSizeOfMatrix(strNumbers);
        int[,] matrix = new int[size, size];
        Input(matrix, ConvertToInt(strNumbers));
        WriteToFile(MaxPlatform(matrix));
    }
}