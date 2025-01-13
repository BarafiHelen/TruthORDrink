using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthORDrink.MVVM.Models
{
    public class Timer
    {
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }

        public Timer(int duration)
        {
            Duration = duration;
        }

        public Timer()
        {

        }

        public void StartTimer()
        {
            StartTime = DateTime.Now;
        }

        public void StopTimer()
        {
            var elapsedTime = DateTime.Now - StartTime;
            Console.WriteLine($"Timer gestopt na {elapsedTime.TotalSeconds} seconden.");
        }
    }
}
