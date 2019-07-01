using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Conductor : AbstractService<ConductorSet>
    {
        public override void addEntity(ConductorSet entity)
        {
            em.ConductorSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            ConductorSet conductor = em.ConductorSet.Where(q => q.Id == (int)pk).First<ConductorSet>();
            if (conductor == null)
            {
                throw new ArgumentException("Conductor no encontrado");
            }
            else
            {
                em.ConductorSet.Remove(conductor);
                em.SaveChanges();
            }        
        }

        public override List<ConductorSet> getEntities()
        {
            return em.ConductorSet.ToList<ConductorSet>();
        }

        public override ConductorSet getEntity(object pk)
        {
            ConductorSet conductor = em.ConductorSet.Where(q => q.Id == (int)pk).First<ConductorSet>();
            return conductor ?? throw new ArgumentException("Conductor no encontrado");
        }

        public override void updEntity(ConductorSet entity)
        {
            ConductorSet conductor = em.ConductorSet.Where(q => q.Id == entity.Id).First<ConductorSet>();
            if (conductor == null)
            {
                throw new ArgumentException("Conductor no econtrado");

            }
            else
            {
                conductor.Nombre = entity.Nombre;
                conductor.Apellido = entity.Apellido;
                conductor.FechaNacimiento = entity.FechaNacimiento;
                em.SaveChanges();
            }
        }
    }
}
