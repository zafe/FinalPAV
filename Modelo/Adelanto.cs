using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Adelanto : AbstractService<AdelantoSet>
    {
        public override void addEntity(AdelantoSet entity)
        {
            em.AdelantoSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            AdelantoSet adelanto = em.AdelantoSet.Where(q => q.Id == (int)pk).First<AdelantoSet>();
            if(adelanto == null)
            {
                throw new ArgumentException("Adelanto no encontrado");        
            }
            else
            {
                em.AdelantoSet.Remove(adelanto);
                em.SaveChanges();
            }
        }

        public override List<AdelantoSet> getEntities()
        {
            return em.AdelantoSet.ToList<AdelantoSet>();
        }

        public override AdelantoSet getEntity(object pk)
        {
            AdelantoSet adelanto = em.AdelantoSet.Where(q => q.Id == (int)pk).First<AdelantoSet>();
            return adelanto ?? throw new ArgumentException("Adelanto no encontrado");
        }

        public override void updEntity(AdelantoSet entity)
        {
            AdelantoSet adelanto = em.AdelantoSet.Where(q => q.Id == entity.Id).First<AdelantoSet>();
            if(adelanto == null)
            {
                throw new ArgumentException("Adelanto no encontrado");
            }
            else
            {
                adelanto.Monto = entity.Monto;
                adelanto.Fecha = entity.Fecha;
                adelanto.Conductor_Id = entity.Conductor_Id;
                em.SaveChanges();
            }
        }
    }
}
