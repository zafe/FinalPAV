using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ViajeService : AbstractService<ViajeSet>
    {
        public override void addEntity(ViajeSet entity)
        {
            em.ViajeSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            ViajeSet viaje = em.ViajeSet.Where(q => q.Id == (int)pk).First<ViajeSet>();
            if (viaje == null)
            {
                throw new ArgumentException("Viaje no encontrado");
            }
            else
            {
                em.ViajeSet.Remove(viaje);
                em.SaveChanges();
            }
        }

        public override List<ViajeSet> getEntities()
        {
            return em.ViajeSet.ToList<ViajeSet>();
        }

        public override ViajeSet getEntity(object pk)
        {
            ViajeSet viaje = em.ViajeSet.Where(q => q.Id == (int)pk).First<ViajeSet>();
            return viaje ?? throw new ArgumentException("Viaje no encontrado");
        }

        public override void updEntity(ViajeSet entity)
        {
            ViajeSet viaje = em.ViajeSet.Where(q => q.Id == entity.Id).First<ViajeSet>();
            if(viaje == null)
            {
                throw new ArgumentException("Viaje no encontrado");
            }
            else
            {
                viaje.Peso = entity.Peso;
                viaje.Fecha = entity.Fecha;
                viaje.Estado = entity.Estado;
                viaje.Distancia_Id = entity.Distancia_Id;
                viaje.Conductor_Id = entity.Conductor_Id;
                em.SaveChanges();
            }
        }
    }
}
