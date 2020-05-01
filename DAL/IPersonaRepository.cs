using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface IPersonaRepository
    {
        void DeletePersona(Persona persona);
        Persona GetAPersona();
        Persona GetPersonaById(int cuit);
        List<Persona> GetPersonas();
        void UpdatePersona(Persona persona);
    }

   
}
