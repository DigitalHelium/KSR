using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace KSR
{

    public enum TransportType { bus, car }
    public class Transport
    {
        private GMapMarker marker; // Эксемляр транспорта на карте
        private TransportType transportType; // Тип транспорта (Мотоцикл или Автомобиль)
        private bool isElectric; // Тип двигателя
        private double speed; // Скорость (км/ч)
        private double polution; // Выбросы
        private double timeSpeed;
        private PointLatLng nullPosition; // Начальные координаты
        private PointLatLng currentPosition; // Текущие координаты
        private PointLatLng oldPosition; // Конечные координаты
        private DateTime dateNull = new DateTime();

        public Transport (TransportType transportType, bool isElectric, double speed, double polution, PointLatLng nullPosition, PointLatLng oldPosition)
        {
            this.transportType = transportType;
            this.isElectric = isElectric;
            this.speed = speed;
            this.polution = polution;
            this.nullPosition = nullPosition;
            this.oldPosition = oldPosition;
            this.currentPosition = nullPosition;
            double x = oldPosition.Lat - nullPosition.Lat;
            double y = oldPosition.Lng - nullPosition.Lng;
            this.timeSpeed = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2)) / speed;
            //this.timeSpeed= cordsToMeters(OldPosition.Lat, OldPosition.Lng, NullPosition.Lat, NullPosition.Lng)/(speed*1000/3600);
            Console.WriteLine(timeSpeed);
            currentPosition = nullPosition;
            marker = new GMarkerGoogle(currentPosition,new Bitmap("bus.png"));
            //marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(currentPosition);
        }

        public GMapMarker Marker { get => marker; set => marker = value; }
        public TransportType TransportType { get => transportType; set => transportType = value; }
        public bool IsElectric { get => isElectric; set => isElectric = value; }
        public double Speed { get => speed; set => speed = value; }
        public double TimeSpeed { get => timeSpeed; set => speed = value; }
        public double Polution { get => polution; set => polution = value; }
        public PointLatLng NullPosition { get => nullPosition; set => nullPosition = value; }
        public PointLatLng CurrentPosition { get => currentPosition; set => currentPosition = value; }
        public PointLatLng OldPosition { get => oldPosition; set => oldPosition = value; }

        public void updateMarker()
        {
            marker.Position = currentPosition;
        }
    }
}