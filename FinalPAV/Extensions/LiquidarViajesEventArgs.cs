using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPAV.Extensions
{
    public class LiquidarViajesEventArgs : System.EventArgs
    {
        public LiquidarViajesEventArgs(Viaje v)
        {
            Viaje = v;
        }

        public Viaje Viaje { get; set; }
    }
}
