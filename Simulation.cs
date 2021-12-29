using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    internal class Simulation
    {
        private int n;
        private int n1;
        private int m;
        private int m1;
        private double M;
        private int timeOfCycle;
        private int G;
        private int numberOfCycle;
        private int k;

        public Simulation(int n, int n1, int m, int m1, int timeOfCycle, int G, int numberOfCycle, int k)
        {
            this.n = n;
            this.n1 = n1;
            this.m = m;
            this.m1 = m1;
            this.timeOfCycle = timeOfCycle;
            this.G = G;
            this.numberOfCycle = numberOfCycle;
            this.k = k;
        }

        public double startModeling()
        {
            double res1 = 0;
            VehicleStream MP1 = new VehicleStream("Light", timeOfCycle, numberOfCycle, G);
            VehicleStream MP2 = new VehicleStream("Light", timeOfCycle, numberOfCycle, G);
            for (int i = 1; i < n; i++)
            {
                res1 = MP1.solveStopPolution() + MP2.solveStopPolution();
            }

            double res2 = 0;
            VehicleStream MP3 = new VehicleStream("Light", timeOfCycle, numberOfCycle, G);
            VehicleStream MP4 = new VehicleStream("Light", timeOfCycle, numberOfCycle, G);
            for (int i = 1; i < m; i++)
            {
                res2 = MP3.solveStopPolution() + MP4.solveStopPolution();
            }

            double res3 = 0;
            VehicleStream ML1 = new VehicleStream("Light", 1, k, G);
            VehicleStream ML2 = new VehicleStream("Light", 1, k, G);
            for (int i = 1; i < n1; i++)
            {
                res3 = MP1.solvePolution() + MP2.solvePolution();
            }

            double res4 = 0;
            VehicleStream ML3 = new VehicleStream("Light", 1, k, G);
            VehicleStream ML4 = new VehicleStream("Light", 1, k, G);
            for (int i = 1; i < m1; i++)
            {
                res4 = MP1.solvePolution() + MP2.solvePolution();
            }
            return res1 + res2 + res3 + res4;
        }
    }
}
