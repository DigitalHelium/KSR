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
            Transport tr = new Transport(TransportType.car, false, 40, 1, new GMap.NET.PointLatLng(53.192875, 50.102905), new GMap.NET.PointLatLng(53.192875, 50.102905));
            transports.Add(tr);
            markers.Markers.Add(tr.Marker);
            map.Overlays.Add(markers);


        }

        public void run()
        {
            for (; ;)
            {
                Console.WriteLine("work!");
                if (transports.Count != 0)
                {
                    foreach (Transport transport in transports)
                    {
                        transport.CurrentPosition = new PointLatLng(transport.CurrentPosition.Lat + 0.00001, transport.CurrentPosition.Lng + 0.00001);
                        transport.updateMarker();
                    }
                }
                Thread.Sleep(1000 / FPS);
            }
        }

    }
}
