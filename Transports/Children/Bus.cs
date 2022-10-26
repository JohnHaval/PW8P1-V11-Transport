using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports.Children
{
    public class Bus : Transport
    {
        private int _currentPassengers;
        public int MaxPassengers { get; set; }
        public int CurrentPassengers { get => _currentPassengers; 
            set
            {
                if (MoreThenFree(value) == true) throw new Exception("Мест не хватает на такое количество пассажиров");
                if (value < 0) throw new Exception("Текущее количество пассажиров не может быть равно 0");
                FreePlaces = MaxPassengers - _currentPassengers;
                _currentPassengers = value;
            }
        }
        public int FreePlaces { get; private set; }
        public bool IsElectroBus { get; private set; }
        public Bus() : base() { }
        public Bus(int maxSpeed, int power, TransportControl control, string company) : base(maxSpeed, power, control, company) { }
        public Bus(int maxSpeed, int power, TransportControl control, string company, int maxPassengers) : base(maxSpeed, power, control, company)
        {
            MaxPassengers = maxPassengers;
        }
        public Bus(int maxSpeed, int power, TransportControl control, string company, int maxPassengers, bool isElectroBus) : base(maxSpeed, power, control, company)
        {
            MaxPassengers = maxPassengers;
            IsElectroBus = isElectroBus;
        }
        /// <summary>
        /// sealed - final ride
        /// can do 'new virtual and override with sealed override. Very Hard Logic Circuit'
        /// </summary>
        public sealed override void DestroyTransport()
        {
            base.DestroyTransport();            
        }
        public sealed override void RestoreTransport()
        {
            base.RestoreTransport();
        }        
        public void ElectroBusSetup(bool isElectroBus)
        {
            IsElectroBus = isElectroBus;
        }
        private bool? MoreThenFree(int value)
        {
            return MaxPassengers < value;
        }
        /// <summary>
        /// Прибавляет пассажиров в автобус
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="passengers"></param>
        /// <returns></returns>
        public static Bus operator +(Bus bus, int passengers)
        {
            bus.CurrentPassengers += passengers;
            return bus;
        }/// <summary>
        /// Перемещает пассажиров из сломанного автобуса в другой
        /// (Пример разностного использования взаимодействия операторов)
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="crashedBus"></param>
        /// <returns></returns>
        public static Bus operator +(Bus bus, Bus crashedBus)
        {
            bus.CurrentPassengers += crashedBus.CurrentPassengers;
            return bus;
        }
        public static Bus operator ++(Bus bus)
        {            
            return ++bus;
        }/// <summary>
        /// Уменьшает количество пассажиров в автобусе
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="passengers"></param>
        /// <returns></returns>
        public static Bus operator -(Bus bus, int passengers)
        {
            bus.CurrentPassengers -= passengers;
            return bus;
        }
        public static Bus operator --(Bus bus)
        {
            return --bus;
        }    
    }
}
