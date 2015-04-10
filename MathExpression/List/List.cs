using System;
using System.Collections.Generic;

class ListExample
{
    static void Main()
    {
        List<string> listOfStrings = new List<string>() { "C#", "Java" };

        listOfStrings.Add("MySQL");
        listOfStrings.Add("Python");
        listOfStrings.Insert(2, "C++");
        //   listOfStrings.Remove("C#"); // Търси даден елемент и ако го намери го трие
        // listOfStrings.RemoveAt(listOfStrings.Count-1); // премахва елемент от дадена позиция
        // listOfStrings.Clear(); премахва всички елементи от List
        foreach (var item in listOfStrings)
        {
            Console.WriteLine(item);
        }
        string word = "Java";
        bool a = listOfStrings.Contains(word); //ако има такъв елемент изписва true ако няма false
        Console.WriteLine("{0}: {1}", word, a);
        int index = listOfStrings.IndexOf(word); // връща индекса на ден елемент 
        Console.WriteLine("{0} is at index {1}",word,index);
        listOfStrings.Sort();
        Console.WriteLine("\nSorted List: ");
        foreach (var item in listOfStrings)
        {
            Console.WriteLine(item);
        }
        listOfStrings.ToArray(); // прави масив       
        Console.WriteLine("\nCapcity of List is: {0}",listOfStrings.Capacity);
       
    }
}

/*
 * 
 */