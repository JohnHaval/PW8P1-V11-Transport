using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports.Children
{
    public class Car : Transport
    {
        public string OldCompany { get; private set; }
        private ComfortClass _oldComfort = ComfortClass.Common;
        public bool HasOwner { get; private set; }
        public ComfortClass Comfort { get; set; } = ComfortClass.Common;        
        public enum ComfortClass
        {
            None,
            Common,
            Luxury
        }
        public Car() : base() { }
        public Car(int maxSpeed, int power, TransportControl control, string company, bool hasOwner) : base(maxSpeed, power, control, company)
        {
            HasOwner = hasOwner;
        }
        public Car(int maxSpeed, int power, TransportControl control, string company, bool isWinterTires, bool hasOwner) : base(maxSpeed, power, control, company, isWinterTires)
        {
            HasOwner = hasOwner;
        }
        public Car(int maxSpeed, int power, TransportControl control, string company, bool isWinterTires, ComfortClass comfort, bool hasOwner) : base(maxSpeed, power, control, company, isWinterTires)
        {
            Comfort = comfort;
            HasOwner = hasOwner;
        }
        public override void DestroyTransport() 
        {
            base.DestroyTransport();
            _oldComfort = Comfort;
            Comfort = ComfortClass.None;
        }
        public override void RestoreTransport()
        {
            base.RestoreTransport();
            Comfort = _oldComfort;
        }
        public void OwnerSetup(bool hasOwner)
        {
            HasOwner = hasOwner;
        }
        /// <summary>
        /// Is use for presentation oppotunities
        /// </summary>
        public void DeathCarSituation()
        {
            HasOwner = false;
            DestroyTransport();
        }
        public new void ChangeCompany(string newCompany)
        {
            OldCompany = Company;
            Company = newCompany;
        }
    }
}
