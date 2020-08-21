using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class PersonaRepository : IPersonaRepository
    {

        private static List<Persona> personas;

        public PersonaRepository()
        {
        }

        public Persona GetAPersona()
        {
            if (personas == null)
                LoadPersonas();
            return personas.FirstOrDefault();
        }
       

        public List<Persona> GetPersonas()
        {
            if (personas == null)
                LoadPersonas();
            return personas;
        }

        public Persona GetPersonaById(int id)
        {
            if (personas == null)
                LoadPersonas();
            return personas.Where(c => c.PersonaId == id).FirstOrDefault();
        }

        public void DeletePersona(Persona persona)
        {
            personas.Remove(persona);
        }

        public void UpdatePersona(Persona persona)
        {
            Persona personaToUpdate = personas.Where(c => c.CUIT == persona.CUIT).FirstOrDefault();
            personaToUpdate = persona;
        }

        private void LoadPersonas()
        {
            personas = new List<Persona>()
            {
                new Persona(){
                    CUIT = "1",
                    Nombre = "Fernando",
                    Apellido = "Zafe"
                },
                new Persona(){
                    CUIT = "2",
                    Nombre = "Alvaro",
                    Apellido = "Zafinsky"
                },
                new Persona(){
                    CUIT = "3",
                    Nombre = "Ivana",
                    Apellido = "Zafinovich"
                },
                new Persona(){
                    CUIT = "4",
                    Nombre = "Jose",
                    Apellido = "Zafernandez"
                },
                new Persona(){
                    CUIT = "5",
                    Nombre = "Maria",
                    Apellido = "Zafarova"
                },
                new Persona(){
                    CUIT = "6",
                    Nombre = "Alicia",
                    Apellido = "Zafati"
                },


            };
        }

    }
}
