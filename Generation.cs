using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    class Generation
    {
        Random random;
        private int nullTime; // время появления последнего транспорта
        private bool isFree; // Доступен ли генератор для генерации задержки нового авто
        private int nextTime; // сколько должно пройти времени для появления следующего транспорта
        public Generation()
        {
            random = new Random();
            isFree = true;
            nextTime = -1;
        }

        public int NullTime { get => nullTime; set => nullTime = value; }
        public bool IsFree { get => isFree; set => isFree = value; }
        public int NextTime { get => nextTime; set => nextTime = value; }

        public bool canNewTransport(int time)
        {
            bool answ = false;
            if (isFree)
            {
                nullTime = time;
                nextTime = random.Next(1, 6) * 1000;
                isFree = false;
            }
            else
            {
                if ((time - nullTime)>=nextTime) 
                {
                    answ = true;
                    isFree = true;
                }
            }
            return answ;
        }
        public TransportType getTransportType()
        {
            int type = random.Next(1, 10);
            Console.WriteLine(type);
            if (type == 1 || type == 2 || type == 3 || type == 4 || type == 5)
                return TransportType.car;
            if (type == 6 || type == 7 || type == 8 )
                return TransportType.bus;
            if (type == 9 || type == 10 )
                return TransportType.truck;
            return TransportType.NaN;
        }


    }
}
