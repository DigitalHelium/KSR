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
        private int G1;
        private int G2;
        private int G3;
        private int G4;
        private int G5;
        private int G6;
        private int G7;
        private int G8;
        private int numberOfCycle;
        private int k1;
        private int k2;
        private int k3;
        private int k4;
        private int k5;
        private int k6;
        private int k7;
        private int k8;
        private int length;

        public Simulation(int n, int n1, int m, int m1, int timeOfCycle,
            int G1, int G2, int G3, int G4, int G5, int G6, int G7, int G8,
            int numberOfCycle,
            int k1, int k2, int k3, int k4, int length)
        {
            this.n = n;
            this.n1 = n1;
            this.m = m;
            this.m1 = m1;
            this.timeOfCycle = timeOfCycle;
            this.G1 = G1;
            this.G2 = G2;
            this.G3 = G3;
            this.G4 = G4;
            this.G5 = G5;
            this.G6 = G6;
            this.G7 = G7;
            this.G8 = G8;
            this.numberOfCycle = numberOfCycle;
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
            this.k4 = k4;
            this.length = length;

        }

        public double startModeling(string MP1type, string MP2type, string MP3type, string MP4type, string ML1type,
            string ML2type, string ML3type, string ML4type)
        {
            double res1 = 0;
            VehicleStream MP1 = new VehicleStream(MP1type, timeOfCycle, numberOfCycle, G1);
            VehicleStream MP2 = new VehicleStream(MP2type, timeOfCycle, numberOfCycle, G2);
            for (int i = 1; i < n; i++)
            {
                res1 = MP1.solveStopPolution() + MP2.solveStopPolution();
            }

            double res2 = 0;
            VehicleStream MP3 = new VehicleStream(MP3type, timeOfCycle, numberOfCycle, G3);
            VehicleStream MP4 = new VehicleStream(MP4type, timeOfCycle, numberOfCycle, G4);
            for (int i = 1; i < m; i++)
            {
                res2 = MP3.solveStopPolution() + MP4.solveStopPolution();
            }

            double res3 = 0;
            VehicleStream ML1 = new VehicleStream(ML1type, 1, k1, G5);
            VehicleStream ML2 = new VehicleStream(ML2type, 1, k2, G6);
            for (int i = 1; i < n1; i++)
            {
                res3 = MP1.solvePolution() + MP2.solvePolution();
            }

            double res4 = 0;
            VehicleStream ML3 = new VehicleStream(ML3type, length, k3, G7);
            VehicleStream ML4 = new VehicleStream(ML4type, length, k4, G8);
            for (int i = 1; i < m1; i++)
            {
                res4 = MP1.solvePolution() + MP2.solvePolution();
            }
            return res1 + res2 + res3 + res4;
        }
    }
}
