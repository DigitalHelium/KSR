using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    public enum StateLight { red,green, yellow }
    public class TrafficLight
    {
        private StateLight curruntState; // Текущий цвет
        private int nullTime; // Время последней смены сфетофора
        private int calldown; // Время смены цвета с зеленого и красного
        private int calldownYellow; // Время смены цвета с желтого
        private PointLatLng nullPosition; // Начальные координаты перекрестка
        private PointLatLng oldPosition; // Конечные координаты Перекрестка

        public TrafficLight(int calldown, int calldownYellow, PointLatLng nullPosition, PointLatLng oldPosition)
        {
            this.calldown = calldown;
            this.calldownYellow = calldownYellow;
            this.nullPosition = nullPosition;
            this.oldPosition = oldPosition;

            curruntState = StateLight.green;
            
        }

        public void update(int time)
        {


            if (curruntState == StateLight.yellow)
            {
                if (time - nullTime > calldownYellow)
                {
                    curruntState = StateLight.red;
                    nullTime = time;
                    
                }
            }
            else if (curruntState == StateLight.red)
            {
                if(time - nullTime > calldown)
                {
                    curruntState = StateLight.green;
                    nullTime = time;
                }
            }
            else if (curruntState == StateLight.green)
            {
                if (time - nullTime > calldown)
                {
                    curruntState = StateLight.yellow;
                    nullTime = time;
                }
            }
        }

        public StateLight CurruntState { get => curruntState; set => curruntState = value; }
        public int Calldown { get => calldown; set => calldown = value; }
        public int CalldownYellow { get => calldownYellow; set => calldownYellow = value; }
        public int NullTime { get => nullTime; set => nullTime = value; }
        public PointLatLng NullPosition { get => nullPosition; set => nullPosition = value; }
        public PointLatLng OldPosition { get => oldPosition; set => oldPosition = value; }
    }
}
