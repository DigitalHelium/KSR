using GMap.NET;
using System;
using System.Collections.Generic;

namespace KSR
{
    /*
     * 1.Тип транспорта 
     * 2.Скорость 
     * 3.Выбросы(в чем-то)
     * 4.
     * 
     * 
        private String name;
        private String number;
        private GMap.NET.PointLatLng position;
        private GMap.NET.PointLatLng oldPosition;
        private int ost = 1;
        public int h = 1000;
        private List<GMap.NET.PointLatLng> cords = new List<PointLatLng>();
        private GMarkerGoogle mapM;
     * 
     */


    // Виды трансопрта

    public enum TransportType { bus, car, motorcycle }
    public class Transport


    {

        private TransportType transportType;
        private bool isElectric;
        private double velocity;
        private double polution;
        private GMap.NET.PointLatLng position;
        private GMap.NET.PointLatLng oldPosition;
        private List<GMap.NET.PointLatLng> cords = new List<PointLatLng>();

        public double Velocity
        {
            get { return velocity; }
        }

        public double Polution
        {
            get { return polution; }
            set { polution = value; }
        }
        public bool IsElectric
        {
            get { return isElectric; }
            set { isElectric = value; }
        }




    }
}