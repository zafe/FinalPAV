using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Usuario
    {
        public int UsuarioId {get;set;}
        public Persona Persona { get; set; }
        public int PersonaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
