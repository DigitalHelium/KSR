using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    class Generation
    {
        private int N;
        public void Method()
        {
            Random rnd = new Random();
            double countOfRequests = 0;
            int countFrequencies = 0;
            List<int> requests = new List<int>();
            List<double> timeOfRequests = new List<double>();
            double countTime = 0;
            double[] intervals = new double[N];
            for (int i = 0; i < N; i++)
            {
                //intervals[i] = Math.Round((-1 / lambda) * Math.Log(1 - rnd.NextDouble()) + q / 2, 4);
                countOfRequests += intervals[i];
                countTime += intervals[i];
                timeOfRequests.Add(Math.Round(countTime, 4));
                countFrequencies++;
                //if (countOfRequests > t)
                {
                    requests.Add(countFrequencies);
                    countOfRequests = 0;
                    countFrequencies = 0;
                }
                //intervalsListBox.Items.Add(intervals[i]);
            }
            requests.Add(countFrequencies); // добавление "хвоста" в последний интервал
            double averageOfRequests = Math.Round(requests.Average(), 4);
            //countOfRequestsBox.Text = averageOfRequests.ToString();
           
        }
    }
}
