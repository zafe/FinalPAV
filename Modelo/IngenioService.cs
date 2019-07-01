using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class IngenioService : AbstractService<IngenioSet>
    {
        public override void addEntity(IngenioSet entity)
        {
            em.IngenioSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            IngenioSet ingenio = em.IngenioSet.Where(q => q.Id == (int)pk).First<IngenioSet>();
            if (ingenio == null)
            {
                throw new ArgumentException("Ingenio no encontrado");
            }
            else
            {
                em.IngenioSet.Remove(ingenio);
                em.SaveChanges();
            }
        }

        public override List<IngenioSet> getEntities()
        {
            return em.IngenioSet.ToList<IngenioSet>();
        }

        public override IngenioSet getEntity(object pk)
        {
            IngenioSet ingenio = em.IngenioSet.Where(q => q.Id == (int) pk).First<IngenioSet>();
            return ingenio ?? throw new ArgumentException("Ingenio no encontrado");
        }

        public override void updEntity(IngenioSet entity)
        {
            IngenioSet ingenio = em.IngenioSet.Where(q => q.Id == entity.Id).First<IngenioSet>();
            if (ingenio == null)
            {
                throw new ArgumentException("Ingenio no encontrado");
            }
            else
            {
                ingenio.Nombre = entity.Nombre;
                ingenio.PrecioKm = entity.PrecioKm;
                ingenio.PrecioKm = entity.Tarifa;
                em.SaveChanges();
            }
        }
    }
}
