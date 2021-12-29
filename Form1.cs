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
        private GMap.NET.WindowsForms.GMapOverlay markersOverlayMap2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // map1Init();
            map2Init();
        }
        /*public void map1Init()
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
            markersOverlayMap1 = new GMap.NET.WindowsForms.GMapOverlay( "marker");

            gMapControl1.Position = new GMap.NET.PointLatLng(53.192875, 50.102905);
            //Инициализация нового ЗЕЛЕНОГО маркера, с указанием его координат
            GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(53.192875, 50.102905),GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            //Текст отображаемый при наведении на маркер
            marker.ToolTipText = "ул. Красноармейская х ул. Галактионовская";
            //Добавляем маркер в список маркеров
            markersOverlayMap1.Markers.Add(marker);
            //Добавляем в компонент, список маркеров
            gMapControl1.Overlays.Add(markersOverlayMap1);
            

 
        }*/
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
            markersOverlayMap2 = new GMap.NET.WindowsForms.GMapOverlay("marker");
            /*
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(53.192875, 50.102905));
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = "ул.Красно-\nармейская х\n ул.Галакти-\nоновская";
            markersOverlayMap2.Markers.Add(marker);
            gMapControl2.Overlays.Add(markersOverlayMap2);*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Time = timer.Time + timer1.Interval;
            Console.WriteLine(timer.Time);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer1.Start();
            //Console.WriteLine("Start!");
            MainHandler handler = new MainHandler(24, timer, gMapControl2, markersOverlayMap2);
            Thread handlerThread = new Thread(new ThreadStart(handler.run));
            handlerThread.Start();
            //timer1.Start();
            int n = Int32.Parse(textBox1.Text);
            int n1 = Int32.Parse(textBox2.Text);
            int m = Int32.Parse(textBox3.Text);
            int m1 = Int32.Parse(textBox4.Text);
            int G1 = Int32.Parse(textBox5.Text);
            int G2 = Int32.Parse(textBox17.Text);
            int G3 = Int32.Parse(textBox18.Text);
            int G4 = Int32.Parse(textBox19.Text);
            int G5 = Int32.Parse(textBox20.Text);
            int G6 = Int32.Parse(textBox21.Text);
            int G7 = Int32.Parse(textBox22.Text);
            int G8 = Int32.Parse(textBox23.Text);
            int Cycle = Int32.Parse(textBox1.Text);
            int countCycle = Int32.Parse(textBox9.Text);
            int length = Int32.Parse(textBox14.Text);
            int k1 = Int32.Parse(textBox8.Text);
            int k2 = Int32.Parse(textBox7.Text);
            int k3 = Int32.Parse(textBox11.Text);
            int k4 = Int32.Parse(textBox12.Text);
            string[] threads = textBox13.Text.Split(' ');
            Simulation s = new Simulation(n,n1,m,m1,Cycle,G1,G2,G3,G4,G5,G6,G7,G8,countCycle,k1,k2,k3,k4,length);
            textBox6.Text = s.startModeling(threads[0], threads[1], threads[2], threads[3], threads[4], threads[5], threads[6], threads[7]).ToString();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
