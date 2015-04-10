using System;
using System.Collections.Generic;

class CalcSumOfString
{
    static int Split(string str)
    {
        List<string> numbers = new List<string>();
        string temp = null;
        for (int i = 0; i < str.Length; i++)
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

        int[] arr = new int[numbers.Count];
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            arr[i] = int.Parse(numbers[i]);
            sum += arr[i];
        }

        return sum;
    }

    static void Main()
    {
        string str = "43 68 9 23 318";
        Console.WriteLine(Split(str));
    }
}