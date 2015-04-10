using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string number = n.ToString();
        int[] arr =  new int[number.Length];

        //reverse position of numbers 37 to 73
        char[] cArray = number.ToCharArray();
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            arr[i] = Convert.ToInt32(cArray[i]);
            reverse += cArray[i];

        }

        for (int i = 0; i < cArray.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
      

    }
}


