using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int count = 1;
        int[][] jagged = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jagged[i] = new int[i];
        }
       
    }
}
