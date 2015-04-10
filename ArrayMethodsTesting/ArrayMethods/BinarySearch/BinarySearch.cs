using System;

class BinarySearch
{
    static void Main()
    {
        string[] name = { "Miloslav", "Georgi", "Nikolai", "Krasimir", "Dobri" };
        Array.Sort(name);
        int indexOfTargetAfterSort = Array.BinarySearch(name, "Krasimir");

        foreach (var firstName in name)
        {
            Console.WriteLine(firstName);
        }
        Console.WriteLine("{0} is on position: {1}", name[indexOfTargetAfterSort], indexOfTargetAfterSort);
    }
}