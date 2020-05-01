using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Usuario
    {
        public long UsuarioId {get;set;}
        public Persona Persona { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
