using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class UsuarioService : AbstractService<UsuarioSet>
    {
        public override void addEntity(UsuarioSet entity)
        {
            em.UsuarioSet.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(object pk)
        {
            UsuarioSet usuario = em.UsuarioSet.Where(q => q.Id == (int)pk).First<UsuarioSet>();
            if (usuario == null)
            {
                throw new ArgumentException("Usuario no encontrado");
            }
            else
            {
                em.UsuarioSet.Remove(usuario);
                em.SaveChanges();
            }
        }

        public override List<UsuarioSet> getEntities()
        {
            return em.UsuarioSet.ToList<UsuarioSet>();
        }

        public override UsuarioSet getEntity(object pk)
        {
            UsuarioSet usuario = em.UsuarioSet.Where(q => q.Id == (int)pk).First<UsuarioSet>();
            return usuario ?? throw new ArgumentException("Usuario no encontrado");
        }

        public override void updEntity(UsuarioSet entity)
        {
            UsuarioSet usuario = em.UsuarioSet.Where(q => q.Id == entity.Id).First<UsuarioSet>();
            if (usuario == null)
            {
                throw new ArgumentException("Usuario no encontrado");
            }
            else
            {
                usuario.Nombre = entity.Nombre;
                usuario.Clave = entity.Clave;
                usuario.Administrador_Id = entity.Administrador_Id;
            }
        }
    }
}
