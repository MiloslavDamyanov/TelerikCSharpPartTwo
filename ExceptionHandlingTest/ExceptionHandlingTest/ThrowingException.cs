using System;

class NullOrWhiteSpaceAreNotAllowedException : ArgumentException // : Exception наследява ArgumentException Може и Exception и др.
{  
}

class ThrowingException
{
    static string Reverse(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new NullOrWhiteSpaceAreNotAllowedException();
        }
        var charArray = str.ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }

    static void Main()
    {
        try
        {
            Console.WriteLine(Reverse("Miloslav"));
        }
        catch (NullOrWhiteSpaceAreNotAllowedException ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
