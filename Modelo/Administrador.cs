using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Administrador : AbstractService<AdministradorSet>
    {
        public override void addEntity(AdministradorSet entity)
        {
            em.AdministradorSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            AdministradorSet administrador = em.AdministradorSet.Where(q => q.Id == (int) pk).First<AdministradorSet>();
            if (administrador == null)
            {
                throw new ArgumentException("Administrador no encontrado");
            }
            else
            {
                em.AdministradorSet.Remove(administrador);
                em.SaveChanges();
            }
        }

        public override List<AdministradorSet> getEntities()
        {
            return em.AdministradorSet.ToList<AdministradorSet>();
        }

        public override AdministradorSet getEntity(object pk)
        {
            AdministradorSet administrador = em.AdministradorSet.Where(q => q.Id == (int)pk).First<AdministradorSet>();
            return administrador ?? throw new ArgumentException("Administrador no encontrado");
        }

        public override void updEntity(AdministradorSet entity)
        {
            AdministradorSet administrador = em.AdministradorSet.Where(q => q.Id == entity.Id).First<AdministradorSet>();
            if (administrador == null)
            {
                throw new ArgumentException("Administrador no encontrado");
            }
            else
            {
                administrador.Nombre = entity.Nombre;
                administrador.Apellido = entity.Apellido;
                administrador.FechaNacimiento = entity.FechaNacimiento;
                em.SaveChanges();
            }
        }
    }
}
