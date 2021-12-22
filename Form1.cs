using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace KSR
{
    public partial class Form1 : Form
    {
        private GMap.NET.WindowsForms.GMapOverlay markersOverlayMap1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map1Init();
            map2Init();
        }
        public void map1Init()
        {
            //Настройки для компонента GMap.
            gMapControl1.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту
            ///с помощью правой кнопки мыши.
            gMapControl1.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl1.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl1.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl1.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl1.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl1.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMapControl1.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl1.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться
            //18ти кратное приближение.
            gMapControl1.Zoom = 15;

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются
            //соответствующим образом.
            gMapControl1.Dock = DockStyle.Fill;

            //Указываем что будем использовать карты Google.
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode =
            GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy = System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            markersOverlayMap1 = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "marker");

            gMapControl1.Position = new GMap.NET.PointLatLng(53.192875, 50.102905);
            //Инициализация нового ЗЕЛЕНОГО маркера, с указанием его координат
            //GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(53.192875, 50.102905));
            //marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            //Текст отображаемый при наведении на маркер
            //marker.ToolTipText = "ул. Красноармейская х ул. Галактионовская";
            //Добавляем маркер в список маркеров
            //markersOverlay.Markers.Add(marker);
            //Добавляем в компонент, список маркеров
            //gMapControl1.Overlays.Add(markersOverlay);
            

 
        }
        public void map2Init()
        {
            //gMapControl2.Location = new System.Drawing.Point(538, 12);
            
            gMapControl2.Position = new GMap.NET.PointLatLng(53.192875, 50.102905);
            gMapControl2.Bearing = 0;
            gMapControl2.CanDragMap = true;
            gMapControl2.DragButton = MouseButtons.Left;
            gMapControl2.GrayScaleMode = true;
            gMapControl2.MarkersEnabled = true;
            gMapControl2.MaxZoom = 20;
            gMapControl2.MinZoom = 16;
            gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl2.NegativeMode = false;
            gMapControl2.PolygonsEnabled = true;
            gMapControl2.RoutesEnabled = true;
            gMapControl2.ShowTileGridLines = false;
            gMapControl2.Zoom = 18;
            gMapControl2.Dock = DockStyle.Fill;
            gMapControl2.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode =GMap.NET.AccessMode.ServerOnly;
            GMap.NET.MapProviders.GMapProvider.WebProxy = System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMap.NET.WindowsForms.GMapOverlay(gMapControl2, "marker");

            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(53.192875, 50.102905));
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = "ул.Красно-\nармейская х\n ул.Галакти-\nоновская";
            markersOverlay.Markers.Add(marker);
            gMapControl2.Overlays.Add(markersOverlay);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hi!");
            MainHandler handler = new MainHandler(24, timer1, gMapControl1, markersOverlayMap1);
            Thread handlerThread = new Thread(new ThreadStart(handler.run));
            handlerThread.Start();
            //timer1.Start();
        }
    }
}
