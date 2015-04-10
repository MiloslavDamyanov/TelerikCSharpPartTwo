using System;
using System.Globalization;
using System.Threading;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int tomatoSeedsAmount = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());

        int cucumberSeedsAmount = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());

        int potatoSeedsAmount = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());

        int carrotSeedsAmount = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());

        int cabbageSeedsAmount = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());

        int beansSeedsAmount = int.Parse(Console.ReadLine());


        //cost per seed

        double tomatoPerSeed = 0.5;
        double cucumberPerSeed = 0.4;
        double potatoPerSeed = 0.25;
        double carrotPerSeed = 0.6;
        double cabbagePerSeed = 0.3;
        double beansPerSeed = 0.4;
        //total cost
        double totalCosts = 0;
        totalCosts = (tomatoSeedsAmount * tomatoPerSeed) + (cucumberSeedsAmount * cucumberPerSeed) +
                     (potatoSeedsAmount * potatoPerSeed) + (carrotSeedsAmount * carrotPerSeed) +
                     (cabbageSeedsAmount * cabbagePerSeed) + (beansSeedsAmount * beansPerSeed);




        //calculate are
        int area = 250;
        int sumOfAreas = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
        int beansArea = area - sumOfAreas;


        if (beansArea < 0)
        {
            Console.WriteLine("Total costs: {0:F2}", totalCosts);
            Console.WriteLine("Insufficient area");
        }
        else if (beansArea == 0)
        {
            Console.WriteLine("Total costs: {0:F2}", totalCosts);
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Total costs: {0:F2}", totalCosts);
            Console.WriteLine("Beans area: {0}", beansArea);
        }

    }
}

