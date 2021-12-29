using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KSR
{
    public class MainHandler
    {
        private int FPS; // Кадров в секунду
        private Timer timer; // Таймер
        private Generation generation; // Генератор транспорта
        private List<Transport> transports; // Весь транспорт
        private GMapControl map;
        private GMapOverlay markers;
        private bool isFinish;
        private Random random = new Random();
        private GMap.NET.PointLatLng nullpos;
        private GMap.NET.PointLatLng oldpos;
        private StateLight trafficType;
        private TrafficLight trafficLight;
        private GMap.NET.PointLatLng stopPos;

        public MainHandler(int seed,int FPS, Timer timer, GMapControl map, GMapOverlay markers, GMap.NET.PointLatLng nullpos, GMap.NET.PointLatLng oldpos, StateLight trafficType, TrafficLight trafficLight, GMap.NET.PointLatLng stopPos)
        {
            this.FPS = FPS;
            this.timer = timer;
            this.map = map;
            this.markers = markers;
            this.oldpos = oldpos;
            this.nullpos = nullpos;
            generation = new Generation(seed);
            transports = new List<Transport>();
            isFinish = false;
            this.trafficLight = trafficLight;
            this.trafficType = trafficType;
            this.stopPos = stopPos;
        }
        
        public void run()
        {
            while (!isFinish)
            {

                // Обрабатываем существующие машины
                if (transports.Count != 0)
                {
                    for (int i = 0; i < transports.Count; i++)
                    {
                            // Обновляем координаты существующих машин
                        Transport transport = transports.ElementAt(i);
                        if (trafficLight.CurruntState == trafficType )
                        {
                            transport.updatePosition(FPS);

                            // Удаление транспорта при преодоление дистанции
                            delTransportMarker(transport);
                        }
                        else
                        {
                            transportAfterLight(transport);
                        }
                        
                    }
                }
            
            

                // Создаем новые машины
                if(generation.canNewTransport(timer.Time)) 
                {
                    int rand = random.Next(15, 40);
                    //Console.WriteLine(rand);
                    //Thread.Sleep(100);
                    Transport tr = new Transport(generation.getTransportType(), false, rand, 1,nullpos,oldpos);
                    transports.Add(tr);
                    markers.Markers.Add(tr.Marker);
                    map.Overlays.Add(markers);
                }

                Thread.Sleep(1000/FPS);
            }
        }
        public void transportAfterLight(Transport transport)
        {
            if (transport.NullPosition.Lng < transport.OldPosition.Lng)
            {
                if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                {
                    if (transport.CurrentPosition.Lng >= stopPos.Lng && transport.CurrentPosition.Lat >= stopPos.Lat)
                    {
                        transport.updatePosition(FPS);
                        delTransportMarker(transport);
                    }

                }
                else
                {
                    if (transport.CurrentPosition.Lng >= stopPos.Lng && transport.CurrentPosition.Lat <= stopPos.Lat)
                    {
                        transport.updatePosition(FPS);
                        delTransportMarker(transport);
                    }
                }
            }
            else
            {
                if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                {
                    if (transport.CurrentPosition.Lng <= stopPos.Lng && transport.CurrentPosition.Lat >= stopPos.Lat)
                    {
                        transport.updatePosition(FPS);
                        delTransportMarker(transport);
                    }

                }
                else
                {
                    if (transport.CurrentPosition.Lng <= stopPos.Lng && transport.CurrentPosition.Lat >= stopPos.Lat)
                    {
                        transport.updatePosition(FPS);
                        delTransportMarker(transport);
                    }
                }
            }
        }

    
    
        public void delTransportMarker(Transport transport)
        {
            {
                if (transport.NullPosition.Lng < transport.OldPosition.Lng)
                {
                    if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                    {
                        if (transport.CurrentPosition.Lng >= transport.OldPosition.Lng && transport.CurrentPosition.Lat >= transport.OldPosition.Lat)
                            delTransport(transport);

                    }
                    else
                    {
                        if (transport.CurrentPosition.Lng >= transport.OldPosition.Lng && transport.CurrentPosition.Lat <= transport.NullPosition.Lat)
                            delTransport(transport);
                    }
                }
                else
                {
                    if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                    {
                        if (transport.CurrentPosition.Lng <= transport.OldPosition.Lng && transport.CurrentPosition.Lat >= transport.OldPosition.Lat)
                            delTransport(transport);

                    }
                    else
                    {
                        if (transport.CurrentPosition.Lng <= transport.OldPosition.Lng && transport.CurrentPosition.Lat <= transport.NullPosition.Lat)
                            delTransport(transport);
                    }
                }
            }
        }
        public int getTransportLength()
        {
            return transports.Count();
        }
        private void delTransport(Transport transport)
        {
            markers.Markers.Remove(transport.Marker);
            map.Overlays.Remove(markers);
            transports.Remove(transport);
        }
    }
}
