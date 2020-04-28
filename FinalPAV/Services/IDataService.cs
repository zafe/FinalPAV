
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace FinalPAV.Services
{
    interface IDataService
    {

        void DeletePersonas(Persona persona);
        List<Persona> GetAllPersonas();
        Persona GetPersonaDetail(int CUIT);
        void UpdatePersonas(Persona persona);

    }
}
