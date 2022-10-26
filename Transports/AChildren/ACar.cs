using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transports.Children;

namespace Transports.AChildren
{
    public class ACar : ATransport
    {
        public bool IsMove { get; set; }
        /// <summary>
        /// Для каждого класса свой Move
        /// </summary>
        public override void Move()
        {
            IsMove = true;
        }
    }
}
