using System;

class HelloMethod
{
    static void Output(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static void AskName(ref string name)
    {
        Console.Write("Name: ");
        name = Console.ReadLine();
    }

    static void Main()
    {
        string name = null;
        AskName(ref name);
        Output(name);
    }
}