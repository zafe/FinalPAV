using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CamionService : AbstractService<CamionSet>
    {
        public override void addEntity(CamionSet entity)
        {
            em.CamionSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            CamionSet camion = em.CamionSet.Where(q => q.Id == (int)pk).First<CamionSet>();
            if (camion == null)
            {
                throw new ArgumentException("No se encontro el camion");
            }
            else
            {
                em.CamionSet.Remove(camion);
                em.SaveChanges();
            }
         }

        public override List<CamionSet> getEntities()
        {
            return em.CamionSet.ToList<CamionSet>();
        }

        public override CamionSet getEntity(object pk)
        {
            CamionSet camion = em.CamionSet.Where(q => q.Id == (int)pk).First<CamionSet>();
            return camion ?? throw new ArgumentException("Camion no encontrado");
;        }

        public override void updEntity(CamionSet entity)
        {
            CamionSet camion = em.CamionSet.Where(q => q.Id == entity.Id).First<CamionSet>();
            if (camion == null)
            {
                throw new ArgumentException("Camion no encontrado");
            }
            else
            {
                camion.Marca = entity.Marca;
                camion.Modelo = entity.Modelo;
                camion.Patente = entity.Patente;
                em.SaveChanges();
            }
        }
    }
}
