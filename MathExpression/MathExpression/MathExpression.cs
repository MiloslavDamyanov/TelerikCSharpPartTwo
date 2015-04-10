using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
class MathExpressionExample
{
    public static List<char> arithmethicOperations = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static string TrimInput(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                result.Append(input[i]);
            }
        }
        return result.ToString();
    }

    public static List<string> SeparateTokens(string input)
    {
        var result = new List<string>();

        var number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number.Append(input[i]);
            }
            else if (!char.IsDigit(input[i]) && input[i] != '.' && number.Length != 0) // number.Length != 0 check id stringBuilder is not empty 
            {
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (arithmethicOperations.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (input[i] == ',')
            {
                result.Add(",");
            }
            else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")  // i + 1 < input.Length check if symbol is not last
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else throw new ArgumentException("Invalid Expression");
        }

        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    public static void PutInvariantCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }
    public static void Main()
    {
        PutInvariantCulture();
        string input = Console.ReadLine();
        string trimmedInput = input.Replace(" ", string.Empty);
        var separatedTokens = SeparateTokens(trimmedInput);
    }
}