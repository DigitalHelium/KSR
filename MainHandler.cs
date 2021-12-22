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
            transports.Add(tr);
            markers.Markers.Add(tr.Marker);
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
                        i+=0.000005;
                        transport.CurrentPosition = getNewPos(transport, i);
                        //transport.CurrentPosition = new PointLatLng(transport.CurrentPosition.Lat + 0.00001, transport.CurrentPosition.Lng + 0.00001);
                        transport.updateMarker();
                    }
                }
                Thread.Sleep(1000);
            }
        }

    }
}
