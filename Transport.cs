using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Device.Location;

namespace KSR
{

    public enum TransportType { bus, car,truck,NaN }
    public class Transport
    {
        private TransportType transportType; // Тип транспорта (Мотоцикл или Автомобиль)
        private bool isElectric; // Тип двигателя
        private double speed; // Скорость (км/ч)
        private double polution; // Выбросы
        private PointLatLng nullPosition; // Начальные координаты
        private PointLatLng oldPosition; // Конечные координаты

        private PointLatLng currentPosition; // Текущие координаты
        private double distanse; // Длина пути (м)
        private double timeDistanse; // Время прохождения пути (с)
        private GMapMarker marker; // Эксемляр транспорта на карте

        public Transport(TransportType transportType, bool isElectric, double speed, double polution, PointLatLng nullPosition, PointLatLng oldPosition)
        {
            this.transportType = transportType;
            this.isElectric = isElectric;
            this.speed = speed;
            this.polution = polution;
            this.nullPosition = nullPosition;
            this.oldPosition = oldPosition;

            this.currentPosition = nullPosition;
            // Расчет дистанции прохождения авто
            GeoCoordinate c1 = new GeoCoordinate(nullPosition.Lat, nullPosition.Lng);
            GeoCoordinate c2 = new GeoCoordinate(oldPosition.Lat, oldPosition.Lng);
            distanse = c1.GetDistanceTo(c2);
            // Расчет времени прохождения авто
            timeDistanse = distanse * 3600 / (speed * 1000);
            switch (transportType)
            {
                case TransportType.bus:
                    {
                        if(!isElectric)
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("bus.png"));
                        else
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("busEco.png"));
                    }
                    break;
                case TransportType.car:
                    {
                        if (!isElectric)
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("car.png"));
                        else
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("carEco.png"));
                    }
                    break;
                case TransportType.truck:
                    {
                        if (!isElectric)
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("truck.png"));
                        else
                            marker = new GMarkerGoogle(currentPosition, new Bitmap("truckEco.png"));
                    }
                    break;
            }


        }

        public GMapMarker Marker { get => marker; set => marker = value; }
        public TransportType TransportType { get => transportType; set => transportType = value; }
        public bool IsElectric { get => isElectric; set => isElectric = value; }
        public double Speed { get => speed; set => speed = value; }
        public double Polution { get => polution; set => polution = value; }
        public PointLatLng NullPosition { get => nullPosition; set => nullPosition = value; }
        public PointLatLng CurrentPosition { get => currentPosition; set => currentPosition = value; }
        public PointLatLng OldPosition { get => oldPosition; set => oldPosition = value; }
        public double Distanse { get => distanse; set => distanse = value; }
        public double TimeDistanse { get => timeDistanse; set => timeDistanse = value; }

        public void updatePosition(int FPS)
        {
            currentPosition.Lat += (OldPosition.Lat - NullPosition.Lat) /(FPS*timeDistanse);
            currentPosition.Lng += (OldPosition.Lng - NullPosition.Lng) / (FPS * timeDistanse);
            
            if(marker != null)
            marker.Position = currentPosition;
        }
    }
}