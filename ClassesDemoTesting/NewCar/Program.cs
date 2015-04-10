using System;
namespace ClassesDemoTesting
{
    class Car
    {
        public int Year { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }

        public Car(int year)
        {
            Year = year;
            Color = "Black";
            Model = "Trabant";
        }

    }
    class Program
    {
        static void Main()
        {
            Car car = new Car(2013);
            Console.WriteLine(car.Year);
            Console.WriteLine(car.Model);
        }
    }
}
