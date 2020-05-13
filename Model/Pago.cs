using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Pago
    {
        public int PagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public float Monto { get; set; }
        public Persona Conductor { get; set; }
        public int ConductorId { get; set; }

    }
}
