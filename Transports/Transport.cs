using System;

namespace Transports
{//Использование abstract позволит переезд для методов конкретного класса. Метод будет являться основой (имя и абстракция)
    //Для каждого будет выполняться по-разному. не будет base.YourMethod(), что актуально при использовании virtual
    public class Transport
    {
        protected TransportControl _control = TransportControl.Easy;
        protected TransportControl _oldControl = TransportControl.Easy;
        public int MaxSpeed { get; set; }
        public int Power { get; set; }
        public TransportControl Control { get => _control;
            set
            {
                if (IsCrashed) throw new Exception("Транспорт сломан. Необходим ремонт");
                _control = value;
            } 
        }
        public bool IsCrashed { get; set; }
        protected bool IsWinterTires { get; set; }//Задуманная ошибка доступа
        public string Company { get; protected set; }
        public enum TransportControl
        {
            Easy,
            Medium,
            Hard,
            Impossible
        }
        public Transport() { }
        ~Transport() { }// For example, destructor
        public Transport(int maxSpeed, int power, TransportControl control, string company)
        {
            MaxSpeed = maxSpeed;
            Power = power;
            Control = control;
            Company = company;            
        }
        public Transport(int maxSpeed, int power, TransportControl control, string company, bool isWinterTires)
        {
            MaxSpeed = maxSpeed;
            Power = power;
            Control = control;
            Company = company;
            IsWinterTires = isWinterTires;
        }
        /// <summary>
        /// Обновление характеристик транспорта
        /// </summary>
        public void UpdateTransportInfo(int newMaxSpeed)
        {
            MaxSpeed = newMaxSpeed;
        }
        /// <summary>
        /// Обновление характеристик транспорта
        /// </summary>
        public void UpdateTransportInfo(int newMaxSpeed, int newPower)
        {
            MaxSpeed = newMaxSpeed;
            Power = newPower;
        }
        /// <summary>
        /// Обновление характеристик транспорта
        /// </summary>
        public void UpdateTransportInfo(int newMaxSpeed, int newPower, TransportControl newControl)
        {
            MaxSpeed = newMaxSpeed;
            Power = newPower;
            Control = newControl;
        }
        /// <summary>
        /// Обновление характеристик транспорта
        /// </summary>
        public void UpdateTransportInfo(int newMaxSpeed, int newPower, TransportControl newControl, string newCompany)
        {
            MaxSpeed = newMaxSpeed;
            Power = newPower;
            Control = newControl;
            Company = newCompany;
        }
        /// <summary>
        /// Обновление характеристик транспорта
        /// </summary>
        public void UpdateTransportInfo(int newMaxSpeed, int newPower,  TransportControl newControl, string newCompany, bool isWinterTires)
        {
            MaxSpeed = newMaxSpeed;
            Power = newPower;
            Control = newControl;
            Company = newCompany;
            IsWinterTires = isWinterTires;
        }
        /// <summary>
        /// Используется для свидетельства поломки транспорта и его текущей невозможности управления
        /// </summary>
        public virtual void DestroyTransport()
        {
            _oldControl = Control;
            Control = TransportControl.Impossible;
            IsCrashed = true;
        }   
        /// <summary>
        /// Восстанавливает характеристики авто после ремонта
        /// </summary>
        public virtual void RestoreTransport()
        {
            IsCrashed = false;
            Control = _oldControl;
        }
        /// <summary>
        /// Снимает или надевает (дословно) зимнюю резину
        /// </summary>
        /// <param name="setValue"></param>
        public void WinterTiresSetup(bool setValue)
        {
            IsWinterTires = setValue;
        }
        /// <summary>
        /// Меняет имя компании
        /// </summary>
        /// <param name="newCompany"></param>
        public void ChangeCompany(string newCompany)
        {
            Company = newCompany;
        }
    }
}
