using System;
using System.Timers;

namespace ClassesDemoTesting
{
    class Car
    {
        private ushort year;
        public ushort minYear = 1896;
        public ushort Year
        {
            // public ushort getYear() { } - като този метод 
            get
            {
                return (ushort)(year - 10);
            }
            // public void setYear( ushort value) { }
            set
            {
                if (value < minYear)
                {
                    Console.WriteLine("Sorry, invalid year for year");
                }
                else
                {
                    year = value;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Car car = new Car();
            car.Year = 1890;
            car.Year = 2009;
            Console.WriteLine(car.Year);
        }
    }
}

// Sorry, invalid year for year
// 1999
// Press any key to continue . . .