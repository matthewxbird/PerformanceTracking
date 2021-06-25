using PerformaceTracker;
using System;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Started");

            for (int i = 0; i < 100; i++)
            {
                var result = Performance.TrackAsync(SimulateWork).Result;

                Console.WriteLine($"Returned Result='{result}'");
            }

            Console.WriteLine("Stopped - Press a key to exit");
            Console.ReadKey();
        }

        public static async Task<string> SimulateWork()
        {
            var r = new Random();

            await Task.Delay(r.Next(1, 1000));

            return $"Test String: {Guid.NewGuid()}";
        }
    }
}
