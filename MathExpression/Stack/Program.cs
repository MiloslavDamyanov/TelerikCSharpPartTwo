using System;
using System.Collections.Generic;

class Stack
{
    static void Main(string[] args)
    {
        // който първи влесе последен излиза (пример книги)
        Stack<int> stackOfInt = new Stack<int>();
        for (int i = 0; i < 10; i++)
        {
            stackOfInt.Push(i);
        }


    }
}