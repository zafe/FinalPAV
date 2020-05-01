using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Pago
    {
        public long PagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public float Monto { get; set; }

    }
}
