using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PagoService : AbstractService<PagoSet>
    {
        public override void addEntity(PagoSet entity)
        {
            em.PagoSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            PagoSet pago = em.PagoSet.Where(q => q.Id == (int)pk).First<PagoSet>();
            if (pago == null)
            {
                throw new ArgumentException("Pago no encontrado");
            }
            else
            {
                em.PagoSet.Remove(pago);
                em.SaveChanges();
            }
        }

        public override List<PagoSet> getEntities()
        {
            return em.PagoSet.ToList<PagoSet>();
        }

        public override PagoSet getEntity(object pk)
        {
            PagoSet pago = em.PagoSet.Where(q => q.Id == (int)pk).First<PagoSet>();
            return pago ?? throw new ArgumentException("Pago no encontrado");
        }

        public override void updEntity(PagoSet entity)
        {
            PagoSet pago = em.PagoSet.Where(q => q.Id == entity.Id).First<PagoSet>();
            if (pago == null)
            {
                throw new ArgumentException("Pago no encontrado");
            }
            else
            {
                pago.Monto = entity.Monto;
                pago.Fecha = entity.Fecha;
                pago.Conductor_Id = entity.Conductor_Id;
                em.SaveChanges();
            }
        }
    }
}
