using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    public class Timer
    {
        private int time;
        public Timer()
        {
            time = 0;
        }

        public int Time { get => time; set => time = value; }
    }
}
