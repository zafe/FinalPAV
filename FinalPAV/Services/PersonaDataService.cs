using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace FinalPAV.Services
{
    class PersonaDataService : IPersonaDataService
    {
        IPersonaRepository repository;

        public PersonaDataService(IPersonaRepository repository) 
        {
            this.repository = repository;
        }
        public void DeletePersonas(Persona persona)
        {
            repository.DeletePersona(persona);
        }

        public List<Persona> GetAllPersonas()
        {
            return repository.GetPersonas();
        }

        public Persona GetPersonaDetail(int CUIT)
        {
            return repository.GetPersonaById(CUIT);
        }

        public void UpdatePersonas(Persona persona)
        {
            repository.UpdatePersona(persona);
        }
    }
}
