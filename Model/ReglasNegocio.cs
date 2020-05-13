using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReglasNegocio
    {
        public int ReglasNegocioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public float Tarifa { get; set; }
        public float PrecioKM { get; set; }
    }
}
