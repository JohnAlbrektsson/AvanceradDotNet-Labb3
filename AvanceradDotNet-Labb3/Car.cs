using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb3
{
    internal class Car
    {
        public string Name { get; set; }

        public int Speed { get; set; }
        public double Distance { get; set; }

        public static string Winner;

        public Car(string name)
        {
            Name = name;
            Speed = 120;
            Distance = 0;
        }
        public void Race()
        {
            Console.WriteLine($"{Name} har startat");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (Distance <= 10000)
            {
                Distance += Speed/3.6;
                Thread.Sleep(1000);
                if (sw.Elapsed.TotalSeconds > 29)
                {
                    TimedEvent();
                    sw.Restart();
                }
            }
            Console.WriteLine($"{Name} har nått målet");
            if (Winner == null)
            {
                Winner = Name;
                Console.WriteLine($"{Name} vann racet");
            }
        }
        public  void Refuel()
        {
            Console.WriteLine($"{Name} behöver tanka stannar 30 sek");
            Thread.Sleep(30000);
        }
        public  void BirdonWindow()
        {
            Console.WriteLine($"{Name} har en fågel på vindrutan, stannar 10 sek");
            Thread.Sleep(10000);
        }
        public  void EngineFailure()
        {
            Console.WriteLine($"{Name} har fått motorfel och kör nu {Speed}km/h");
            Speed -= 1; 
        }
        public  void Puncture()
        {
            Console.WriteLine($"{Name} har fått punktering, stannar 20 sek");
            Thread.Sleep(20000);
        }
        public void TimedEvent()
        {

            Random random = new Random();
            int rn = random.Next(0, 50);
            if (rn == 1)
            {
                Refuel();
            }
            else if (rn > 1 && rn < 4)
            {
                Puncture();
            }
            else if (rn > 3 && rn < 9)
            {
                BirdonWindow();
            }
            else if (rn > 8 && rn < 19)
            {
                EngineFailure();
            }
        }
    }
}
