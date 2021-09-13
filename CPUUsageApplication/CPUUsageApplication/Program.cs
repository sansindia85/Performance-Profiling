using System;
using System.Threading.Tasks;

namespace CPUUsageApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task[] timers = new Task[10];

            for (int index = 0; index < 10; index++)
            {
                int j = index;
                timers[index] = new Task(() => BadTimer(j + 1));
            }
            
            foreach (Task task in timers)
            {
                task.Start();
            }

            await Task.WhenAll(timers);
            Console.WriteLine("Timer has finished.");
        }

        private static void BadTimer(int seconds)
        {
            Console.WriteLine("Timer for {0} seconds started", seconds);
            
            TimeSpan AmountOfTime = new TimeSpan(0, 0, seconds);
            DateTime startTime = DateTime.Now;
            DateTime nowTime = DateTime.Now;
            
            while (nowTime - startTime < AmountOfTime)
            {
                nowTime = DateTime.Now;
            }

            Console.WriteLine("Timer for {0} seconds ended.", seconds);
        }
    }
}
