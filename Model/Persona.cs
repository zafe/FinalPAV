using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public long CUIT {get;set;}
        public string Nombre{ get;set;}
        public string Apellido{get;set;}

        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
