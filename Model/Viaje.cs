using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Viaje
    {
        public long ViajeId { get; set; }
        public Persona Conductor { get; set; }
        public Distancia Distancia { get; set; }
        public float Peso { get; set;}
        public ReglasNegocio Reglas { get; set; }
        public float Monto { get; set; }
    }
}
