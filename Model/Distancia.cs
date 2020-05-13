using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Distancia
    {
        public int DistanciaId { get;set; }
        public float DistanciaKM { get;set;}
        public Ingenio Ingenio { get; set; }
        public long IngenioId { get; set; }
        public Finca Finca { get; set; }
        public long FincaId { get; set; }
    }
}
