using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class FincaService : AbstractService<FincaSet>
    {
        public override void addEntity(FincaSet entity)
        {
            em.FincaSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            FincaSet finca = em.FincaSet.Where(q => q.Id == (int) pk).First<FincaSet>();
            if (finca == null)
            {
                throw new ArgumentException("Finca no encontrada");
            }
            else
            {
                em.FincaSet.Remove(finca);
                em.SaveChanges();
            }
        }

        public override List<FincaSet> getEntities()
        {
            return em.FincaSet.ToList<FincaSet>();
        }

        public override FincaSet getEntity(object pk)
        {
            FincaSet finca = em.FincaSet.Where(q => q.Id == (int)pk).First<FincaSet>(); 
            return finca ?? throw new ArgumentException("Finca no encontrada");
        }

        public override void updEntity(FincaSet entity)
        {
            FincaSet finca = em.FincaSet.Where(q => q.Id == (int) entity.Id).First<FincaSet>();
            if (finca == null)
            {
                throw new ArgumentException("Finca no encontrada");
            }
            else
            {
                finca.Nombre = entity.Nombre;
                em.SaveChanges();
            }
        }
    }
}
