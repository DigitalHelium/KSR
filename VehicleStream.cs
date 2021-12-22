using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    class VehicleStream
    {
        private String type;
        private double polution;
        private static int[] velocities = {5,10,15,20,25,30,35,40,45,50,60,70,80,90,100,110,120};
        private static double[] rs = {1.40,1.35,1.30,1.20,1.10, 1, 0.9, 0.75, 0.6,0.5,0.3,0.4,0.5,0.65,0.75,0.9};
        private double velocity;
        private double r;
        private double lengthOfRoad;
        private int k;
        private int G;
        private double result;
        private int timeOfCycle;
        private int numberOfCycle;
        bool stopOrRun;

        static Random rnd = new Random();
        public VehicleStream(String type, double lengthOfRoad, int k, int G)
        {
            switch (type)
            {
                case "Hard":
                    this.polution = 8.4;
                    break;
                case "Light":
                    this.polution = 3.5;
                    break;
                case "OverHard":
                    this.polution = 6.8;
                    break;
            }
            stopOrRun = true;
            this.type = type;
            int i = rnd.Next(0, 15);
            this.velocity = velocities[i];
            this.r = rs[i];
            this.lengthOfRoad = lengthOfRoad;
            this.k = k;
            this.G = G;
        }

        public VehicleStream(String type, int timeOfCycle, int numberOfCycle, int k, int G)
        {
            stopOrRun = false;
            switch (type)
            {
                case "Hard":
                    this.polution = 2.0;
                    break;
                case "Light":
                    this.polution = 0.5;
                    break;
                case "OverHard":
                    this.polution = 2.5;
                    break;
            }
            this.type = type;
            this.timeOfCycle = timeOfCycle;
            this.numberOfCycle = numberOfCycle;
            this.k = k;
            this.G = G;
        }

        public double solvePolution()
        {
            if (stopOrRun == true)
            {
                double res = 0;
                for (int i = 1; i < k; i++)
                {
                    res += G * r * polution;
                }
                res = (lengthOfRoad / 1200) * res;
                result = res;
                return res;
            }
            else return 0;
        }

        public double solveStopPolution()
        {
            if (stopOrRun == false)
            {
                double res = 0;
                for (int i = 0; i < numberOfCycle; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        res += polution * G;
                    }
                }
                result = (double)timeOfCycle / 60 * res;
                return result;
            }
            else return 0;
        }
    }
}
