using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

struct Car
{
    public int x;
    public int y;
    public char symbol;
    public ConsoleColor Color;
}

class Program
{

    static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }


    static void Main()
    {
        int playFieldWidth = 5;
        int livesCount = 5;
        double speed = 100.0;
        // remove scrollbars
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;

        // Our car
        Car userCar = new Car();
        userCar.x = 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.symbol = '@';
        userCar.Color = ConsoleColor.Blue;
        Random randomGenerator = new Random();
        // other cars 
        List<Car> cars = new List<Car>();


        while (true)
        {
            speed++;
            bool hitted = false;
            
            {
                // new car
                Car newCar = new Car();
                newCar.Color = ConsoleColor.Green;
                newCar.x = randomGenerator.Next(0, playFieldWidth);
                newCar.y = 0; // най - отгоре
                newCar.symbol = '#';
                cars.Add(newCar);
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                // за да няма закъснение при натискане на key прочита всички останали клавиши от буфера 
              //  while (Console.KeyAvailable) Console.ReadKey(true); // - за да се движе по - плавно колата Console.ReadKey(true);
                {
                    Console.ReadKey();
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x - 1 >= 0)
                    {
                        userCar.x = userCar.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x + 1 < playFieldWidth)
                    {
                        userCar.x = userCar.x + 1;
                    }
                }
            }


            List<Car> newList = new List<Car>();
            // Move cars 
            for (int i = 0; i < cars.Count; i++)
            {
                Car oldCar = cars[i];
                Car newCar = new Car();
                newCar.x = oldCar.x;
                newCar.y = oldCar.y + 1;
                newCar.symbol = oldCar.symbol;
                newCar.Color = oldCar.Color;

                if (newCar.y == userCar.y && newCar.x == userCar.x)
                {
                    livesCount--;
                    hitted = true;
                    speed += 50;
                    if (livesCount <= 0)
                    {
                        PrintStringOnPosition(8, 10, "GAME OVER !!!", ConsoleColor.Red);
                        PrintStringOnPosition(8, 12, "Press [Enter] to exit", ConsoleColor.Yellow);
                        Environment.Exit(0);
                    }
                }
                if (newCar.y < Console.WindowHeight)
                {
                    newList.Add(newCar);
                }

            }
            cars = newList;
            Console.Clear();
            if (hitted)
            {
                cars.Clear();
                PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
            }
            else
            {
                PrintOnPosition(userCar.x, userCar.y, userCar.symbol, userCar.Color);
            }
            
            foreach (Car car in cars)
            {
                PrintOnPosition(car.x, car.y, car.symbol, car.Color);
            }

            PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
            PrintStringOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
            // Console.Beep();
            Thread.Sleep((int)(600 - speed));
        }
    }
}

//Car audi = new Car();   // направи обек от тип Cars с име audi и задели памет
//audi.Color = ConsoleColor.Red; // цвят на колата червен