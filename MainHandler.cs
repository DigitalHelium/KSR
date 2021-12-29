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

        public MainHandler(int FPS, Timer timer, GMapControl map, GMapOverlay markers)
        {
            this.FPS = FPS;
            this.timer = timer;
            this.map = map;
            this.markers = markers;
            generation = new Generation();
            transports = new List<Transport>();
            isFinish = false;
        }
        
        public void run()
        {
            while (!isFinish)
            {
                // Обрабатываем существующие машины
                if (transports.Count != 0)
                {
                    for (int i=0; i < transports.Count; i++)
                    {
                        // Обновляем координаты существующих машин
                        Transport transport = transports.ElementAt(i);
                        transport.updatePosition(FPS);

                        // Удаление транспорта при преодоление дистанции
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
                }

                // Создаем новые машины
                if(generation.canNewTransport(timer.Time)) 
                {
                    int rand = random.Next(15, 40);
                    //Console.WriteLine(rand);
                    
                    Transport tr = new Transport(generation.getTransportType(), false, rand, 1, new GMap.NET.PointLatLng(53.192646, 50.102724), new GMap.NET.PointLatLng(53.193212, 50.103055));
                    transports.Add(tr);
                    markers.Markers.Add(tr.Marker);
                    map.Overlays.Add(markers);
                }

                Thread.Sleep(1000/FPS);
            }
        }

        private void delTransport(Transport transport)
        {
            markers.Markers.Remove(transport.Marker);
            transports.Remove(transport);
        }
    }
}
