using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports.AChildren
{/// <summary>
/// Демонстрация возможностей абстрактного класса
/// </summary>
    public abstract class ATransport : Transport
    {
        public abstract void Move();
        public void Ind()
        {
            ATransport a = new ACar();
            a.Ind();
        }        
    }
}
