using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPAV.Services
{
    interface IViajeDataService
    {

        void DeleteViaje(Viaje viaje);
        List<Viaje> GetAllViajes();
        Viaje GetViajeDetail(int id);
        void UpdateViaje(Viaje viaje);
        List<Viaje> GetViajesByConductorId(int id);

    }
}
