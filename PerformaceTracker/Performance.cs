using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PerformaceTracker
{
    public static class Performance
    {
        public static async Task<TResult> TrackAsync<TResult>(Func<Task<TResult>> method)
        {
            var sw = Stopwatch.StartNew();
            var result = await method();
            sw.Stop();
            LogToKinesis($"TT='{sw.ElapsedMilliseconds}ms'");

            return result;
        }

        public static void LogToKinesis(string log)
        {
            Console.WriteLine($"PL: {log}");
        }
    }
}
