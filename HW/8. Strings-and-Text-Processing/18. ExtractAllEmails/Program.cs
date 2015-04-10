using System;
using System.Text.RegularExpressions;

class ExtractEmail
{
    static void Main()
    {
        string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@gmail.com.";
        string pattern = @"\w+@\w+\.\w+";
        foreach (var item in Regex.Matches(text, pattern))
            Console.WriteLine(item);
    }
}
