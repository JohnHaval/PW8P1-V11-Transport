using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports.AChildren
{
    public class ATruckExample : Children.Bus
    {
        public new virtual void DestroyTransport()
        {
            base.DestroyTransport();//Использование локнутого Destroy и новый virtual для последующих возможных действий в наследуемых классах
        }
    }
}
