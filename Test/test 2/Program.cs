﻿using System;

class PositionText
{
     static void Main(string[] args)
     {
          Console.WriteLine("It's time to enter some text.");
          Console.Write("Enter it here: ");
          string text = Console.ReadLine();
          int left = Console.CursorLeft;
          int top = Console.CursorTop;
          //Console.SetCursorPosition(15, 20);
          //Console.Write("You entered -> {0} <-", text);
          //Console.SetCursorPosition(left, top);
          //Console.WriteLine("Continuing where I left off.");

          Console.ForegroundColor = ConsoleColor.Gray;
          Console.BackgroundColor = ConsoleColor.Yellow;
          Console.Write("You entered -> ");
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.BackgroundColor = ConsoleColor.DarkGray;
          Console.Write(text);
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.BackgroundColor = ConsoleColor.Cyan;
          Console.Write(" <- ");
          Console.ResetColor();
         
      }
}