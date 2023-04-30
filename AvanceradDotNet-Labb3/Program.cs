namespace AvanceradDotNet_Labb3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("BMW");
            Car car2 = new Car("Toyota");
            Car car3 = new Car("Audi");

            Thread thread1 = new Thread(()=>car1.Race());
            Thread thread2 = new Thread(()=>car2.Race());
            Thread thread3 = new Thread(()=>car3.Race());

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.WriteLine("Racet startar");

            Thread thread4 = new Thread(()=>Status(car1,car2,car3));
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
        }
        public static void Status(Car car1,Car car2,Car car3)
        {
            while (true)
            {
                if (Console.ReadLine().ToLower() == "status")
                {
                    Console.WriteLine($"{car1.Name} har kommit {(int)car1.Distance}m och har en hastighet på {car1.Speed}km/h");
                    Console.WriteLine($"{car2.Name} har kommit {(int)car2.Distance}m och har en hastighet på {car2.Speed}km/h");
                    Console.WriteLine($"{car3.Name} har kommit {(int)car3.Distance}m och har en hastighet på {car3.Speed}km/h");
                }
            }
        }
    }
}