using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string numberLength = n.ToString();

        int oddNumber = 0;
        int evenNumber = 0;
        int result = 0;
        int digitCount = 1;
        int power = 1;
        int[] arr = new int[numberLength.Length];
        
        for (int i = 0; i < numberLength.Length; i++)
        {
            int lastDigit = n % 10;
            n /= 10;

            arr[i] = lastDigit;
        }

        for (int i = 0; i < numberLength.Length; i++)
        {
            if (i % 2 != 0)
            {
                result += arr[i] * power;
                power++;
                oddNumber = result * result;
            }
            else if (i % 2 == 0)
            {
                result += (arr[i]* arr[i]) * power;
                
                power++;
            }
            
        }

        Console.WriteLine(result);
    }
}


