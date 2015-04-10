using System;

class AreaOfATriangle
{
    static double Heron(double a, double b, double c)
    {
        double perimeter = (a + b + c) / 2;
        double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
        return area;
    }

    static double Altitude(double side, double h)
    {
        double area = (side * h) / 2;
        return area;
    }

    static double TwoSidesAndAngle(double a, double b, double angle)
    {
        double area = (a * b * Math.Sin(Math.PI * angle / 180)) / 2;
        return area;
    }

    static void Main()
    {
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("h: ");
        double h = double.Parse(Console.ReadLine());
        Console.Write("angle: ");
        double angle = double.Parse(Console.ReadLine());
        Console.WriteLine(Heron(a, b, c));
        Console.WriteLine(Altitude(a, h));
        Console.WriteLine(TwoSidesAndAngle(a, b, angle));
    }
}