using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports.Children
{
    public class Truck : Transport
    {
        private int _currentSpace;
        public int MaxSpace { private get; set; }
        public int CurrentSpace
        {
            get => _currentSpace;
            set
            {
                if (MoreThenFree(value) == true) throw new Exception("Мест не хватает на такое количество пассажиров");
                if (value < 0) throw new Exception("Текущее количество пассажиров не может быть равно 0");
                FreeSpace = MaxSpace - value;
                _currentSpace = value;
            }
        }
        public int FreeSpace { get; private set; }
        public Truck() : base() { }
        public Truck(int maxSpeed, int power, TransportControl control, string company) : base(maxSpeed, power, control, company) { }
        public Truck(int maxSpeed, int power, TransportControl control, string company, int maxSpace) : base(maxSpeed, power, control, company)
        {
            MaxSpace = maxSpace;
        }

        /// <summary>
        /// sealed - final ride
        /// can do 'new virtual and override with sealed override. Very Hard Logic Circuit'
        /// </summary>
        public override void DestroyTransport()
        {
            base.DestroyTransport();
        }
        public override void RestoreTransport()
        {
            base.RestoreTransport();
        }
        public int GetMaxSpace()
        {
            return MaxSpace;
        }
        private bool? MoreThenFree(int value)
        {
            return MaxSpace < value;
        }
        /// <summary>
        /// Прибавляет пассажиров в автобус
        /// </summary>
        /// <returns></returns>
        public static Truck operator +(Truck truck, int cargo)
        {
            truck.CurrentSpace += cargo;
            return truck;
        }/// <summary>
         /// Перемещает груз из одного грузовика в другой
         /// </summary>
         /// <returns></returns>
        public static Truck operator +(Truck truck, Truck crashedTruck)
        {
            truck.CurrentSpace += crashedTruck.CurrentSpace;
            return truck;
        }
        public static Truck operator ++(Truck truck)
        {
            return ++truck;
        }/// <summary>
         /// Уменьшает количество места
         /// </summary>
         /// <returns></returns>
        public static Truck operator -(Truck truck, int cargo)
        {
            truck.CurrentSpace -= cargo;
            return truck;
        }
        public static Truck operator --(Truck truck)
        {
            return --truck;
        }
    }
}
