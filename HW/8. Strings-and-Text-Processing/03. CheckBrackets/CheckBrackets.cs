using System;

class CheckBrackets
{
    static void CheckExpression(string expression)
    {
        int countBrackets = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (countBrackets >= 0)
            {
                if (expression[i] == '(')
                {
                    countBrackets++;
                }
                else if (expression[i] == ')')
                {
                    countBrackets--;
                }
            }
        }
        if (countBrackets == 0)
        {
            Console.WriteLine("Correct expression!");
        }
        else if (countBrackets != 0)
        {
            Console.WriteLine("Incorrect expression! ");
        }
    }

    static void Main()
    {
        Console.Write("Expression: ");
        string expression = Console.ReadLine();
        CheckExpression(expression);
    }
}