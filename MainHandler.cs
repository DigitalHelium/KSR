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
        private System.Windows.Forms.Timer timer; // секундомер
        private List<Transport> transports; // Тачки
        private GMapControl map;
        private GMapOverlay markers;
        private bool isFinish;

        public MainHandler(int FPS, System.Windows.Forms.Timer timer, GMapControl map, GMapOverlay markers)
        {
            this.FPS = FPS;
            this.timer = timer;
            this.map = map;
            this.markers = markers;
            isFinish = false;

            transports = new List<Transport>();
            Transport tr = new Transport(TransportType.car, false, 40, 1, new GMap.NET.PointLatLng(53.192646, 50.102724), new GMap.NET.PointLatLng(53.193212, 50.103055));
            Transport tr1 = new Transport(TransportType.bus, false, 20, 1, new GMap.NET.PointLatLng(53.193208, 50.103089), new GMap.NET.PointLatLng(53.192641, 50.102753));

            Transport tr2 = new Transport(TransportType.car, false, 25, 1, new GMap.NET.PointLatLng(53.192926, 50.102658), new GMap.NET.PointLatLng(53.192801, 50.103176));
            Transport tr3 = new Transport(TransportType.bus, false, 32, 1, new GMap.NET.PointLatLng(53.192828, 50.103191), new GMap.NET.PointLatLng(53.192953, 50.102672));
            transports.Add(tr);
            transports.Add(tr1);
            transports.Add(tr2);
            transports.Add(tr3);
            markers.Markers.Add(tr.Marker);
            markers.Markers.Add(tr1.Marker);
            markers.Markers.Add(tr2.Marker);
            markers.Markers.Add(tr3.Marker);
            map.Overlays.Add(markers);


        }

        public GMap.NET.PointLatLng getNewPos(Transport tr, double tc)
        {
            GMap.NET.PointLatLng pos = tr.CurrentPosition;
            pos.Lat += (tr.OldPosition.Lat - tr.NullPosition.Lat) * tc / tr.TimeSpeed;
            pos.Lng += (tr.OldPosition.Lng - tr.NullPosition.Lng) * tc / tr.TimeSpeed;
            return pos;
        }
        
        public void run()
        {
            double i = 0;
            for (; ;)
            {
                
                if (transports.Count != 0)
                {
                    foreach (Transport transport in transports)
                    {
                        Console.WriteLine(transport.CurrentPosition.Lat+" "+ transport.CurrentPosition.Lng);
                        i+=0.0000001;
                        transport.CurrentPosition = getNewPos(transport, i);
                        transport.updateMarker();
                        if (transport.NullPosition.Lng<transport.OldPosition.Lng) {
                            if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                            {
                                if (transport.CurrentPosition.Lng >= transport.OldPosition.Lng && transport.CurrentPosition.Lat >= transport.OldPosition.Lat)
                                {
                                    markers.Markers.Remove(transport.Marker);
                                    //transports.Remove(transport);
                                }
                                
                            }
                            else
                            {
                                if (transport.CurrentPosition.Lng >= transport.OldPosition.Lng && transport.CurrentPosition.Lat <= transport.NullPosition.Lat)
                                {
                                    markers.Markers.Remove(transport.Marker);
                                    //transports.Remove(transport);
                                }
                            }
                        }
                        else
                        {
                            if (transport.NullPosition.Lat < transport.OldPosition.Lat)
                            {
                                if (transport.CurrentPosition.Lng <= transport.OldPosition.Lng && transport.CurrentPosition.Lat >= transport.OldPosition.Lat)
                                {
                                    markers.Markers.Remove(transport.Marker);
                                    //transports.Remove(transport);
                                }

                            }
                            else
                            {
                                if (transport.CurrentPosition.Lng <= transport.OldPosition.Lng && transport.CurrentPosition.Lat <= transport.NullPosition.Lat)
                                {
                                    markers.Markers.Remove(transport.Marker);
                                    //transports.Remove(transport);
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

    }
}
