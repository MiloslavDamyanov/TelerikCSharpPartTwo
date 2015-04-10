using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {

        Thread t = new Thread(PlayMarioForEver);
        t.Start();

        while (true)
        {
            String test = Console.ReadLine();
            if ("exit".Equals((test ?? "").Trim()))
                return;
        }
    }

    public static void PlayMarioForEver()
    {
        while (true)
        {
            PlayMario();
        }
    }

    public static void PlayMario()
    {
        Console.Beep(510, 100);
        Thread.Sleep(450);
        Console.Beep(380, 100);
        Thread.Sleep(400);
        Console.Beep(320, 100);
        Thread.Sleep(500);
        Console.Beep(440, 100);
        Thread.Sleep(300);
        Console.Beep(480, 80);
        Thread.Sleep(330);
        Console.Beep(450, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(200);
        Console.Beep(660, 80);
        Thread.Sleep(200);
        Console.Beep(760, 50);
        Thread.Sleep(150);
        Console.Beep(860, 100);
        Thread.Sleep(300);
        Console.Beep(700, 80);
        Thread.Sleep(150);
        Console.Beep(760, 50);
        Thread.Sleep(350);
        Console.Beep(660, 80);
        Thread.Sleep(300);
        Console.Beep(520, 80);
        Thread.Sleep(150);
        Console.Beep(580, 80);
        Thread.Sleep(150);
        Console.Beep(480, 80);
        Thread.Sleep(500);

        Console.Beep(510, 100);
        Thread.Sleep(450);
        Console.Beep(380, 100);
        Thread.Sleep(400);
        Console.Beep(320, 100);
        Thread.Sleep(500);
        Console.Beep(440, 100);
        Thread.Sleep(300);
        Console.Beep(480, 80);
        Thread.Sleep(330);
        Console.Beep(450, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(200);
        Console.Beep(660, 80);
        Thread.Sleep(200);
        Console.Beep(760, 50);
        Thread.Sleep(150);
        Console.Beep(860, 100);
        Thread.Sleep(300);
        Console.Beep(700, 80);
        Thread.Sleep(150);
        Console.Beep(760, 50);
        Thread.Sleep(350);
        Console.Beep(660, 80);
        Thread.Sleep(300);
        Console.Beep(520, 80);
        Thread.Sleep(150);
        Console.Beep(580, 80);
        Thread.Sleep(150);
        Console.Beep(480, 80);
        Thread.Sleep(500);

        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 150);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(150);

        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(430, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(100);
        Console.Beep(570, 100);
        Thread.Sleep(220);

        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 200);
        Thread.Sleep(300);

        Console.Beep(1020, 80);
        Thread.Sleep(300);
        Console.Beep(1020, 80);
        Thread.Sleep(150);
        Console.Beep(1020, 80);
        Thread.Sleep(300);

        Console.Beep(380, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 150);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(150);

        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(430, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(100);
        Console.Beep(570, 100);
        Thread.Sleep(420);

        Console.Beep(585, 100);
        Thread.Sleep(450);

        Console.Beep(550, 100);
        Thread.Sleep(420);

        Console.Beep(500, 100);
        Thread.Sleep(360);

        Console.Beep(380, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 150);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(150);

        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(430, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(100);
        Console.Beep(570, 100);
        Thread.Sleep(220);

        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 200);
        Thread.Sleep(300);

        Console.Beep(1020, 80);
        Thread.Sleep(300);
        Console.Beep(1020, 80);
        Thread.Sleep(150);
        Console.Beep(1020, 80);
        Thread.Sleep(300);

        Console.Beep(380, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(760, 100);
        Thread.Sleep(100);
        Console.Beep(720, 100);
        Thread.Sleep(150);
        Console.Beep(680, 100);
        Thread.Sleep(150);
        Console.Beep(620, 150);
        Thread.Sleep(300);

        Console.Beep(650, 150);
        Thread.Sleep(300);
        Console.Beep(380, 100);
        Thread.Sleep(150);
        Console.Beep(430, 100);
        Thread.Sleep(150);

        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(430, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(100);
        Console.Beep(570, 100);
        Thread.Sleep(420);

        Console.Beep(585, 100);
        Thread.Sleep(450);

        Console.Beep(550, 100);
        Thread.Sleep(420);

        Console.Beep(500, 100);
        Thread.Sleep(360);

        Console.Beep(380, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(300);
        Console.Beep(500, 100);
        Thread.Sleep(150);
        Console.Beep(500, 100);
        Thread.Sleep(300);

        Console.Beep(500, 60);
        Thread.Sleep(150);
        Console.Beep(500, 80);
        Thread.Sleep(300);
        Console.Beep(500, 60);
        Thread.Sleep(350);
        Console.Beep(500, 80);
        Thread.Sleep(150);
        Console.Beep(580, 80);
        Thread.Sleep(350);
        Console.Beep(660, 80);
        Thread.Sleep(150);
        Console.Beep(500, 80);
        Thread.Sleep(300);
        Console.Beep(430, 80);
        Thread.Sleep(150);
        Console.Beep(380, 80);
        Thread.Sleep(600);

        Console.Beep(500, 60);
        Thread.Sleep(150);
        Console.Beep(500, 80);
        Thread.Sleep(300);
        Console.Beep(500, 60);
        Thread.Sleep(350);
        Console.Beep(500, 80);
        Thread.Sleep(150);
        Console.Beep(580, 80);
        Thread.Sleep(150);
        Console.Beep(660, 80);
        Thread.Sleep(550);

        Console.Beep(870, 80);
        Thread.Sleep(325);
        Console.Beep(760, 80);
        Thread.Sleep(600);

        Console.Beep(500, 60);
        Thread.Sleep(150);
        Console.Beep(500, 80);
        Thread.Sleep(300);
        Console.Beep(500, 60);
        Thread.Sleep(350);
        Console.Beep(500, 80);
        Thread.Sleep(150);
        Console.Beep(580, 80);
        Thread.Sleep(350);
        Console.Beep(660, 80);
        Thread.Sleep(150);
        Console.Beep(500, 80);
        Thread.Sleep(300);
        Console.Beep(430, 80);
        Thread.Sleep(150);
        Console.Beep(380, 80);
        Thread.Sleep(600);

        Console.Beep(660, 100);
        Thread.Sleep(150);
        Console.Beep(660, 100);
        Thread.Sleep(300);
        Console.Beep(660, 100);
        Thread.Sleep(300);
        Console.Beep(510, 100);
        Thread.Sleep(100);
        Console.Beep(660, 100);
        Thread.Sleep(300);
        Console.Beep(770, 100);
        Thread.Sleep(550);
        Console.Beep(380, 100);
        Thread.Sleep(575);



    }
}