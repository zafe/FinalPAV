using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Viaje
    {
        public int ViajeId { get; set; }
        public Persona Conductor { get; set; }
        public int ConductorId { get; set; }
        public Distancia Distancia { get; set; }
        public int DistanciaId { get; set; }
        public float Peso { get; set;}
        public ReglasNegocio Reglas { get; set; }
        public int ReglasNegocioId { get; set; }
        public float Monto { get; set; }
    }
}
