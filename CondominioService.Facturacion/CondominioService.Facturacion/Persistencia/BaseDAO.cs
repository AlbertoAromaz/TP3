using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace CondominioService.Facturacion.Persistencia
{
    public class BaseDAO<Entidad, Id>
    {
        public Entidad Crear(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                sesion.Save(entidad);
                sesion.Flush();
            }
            return entidad;
        }
        public Entidad Obtener(Id id)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                return sesion.Get<Entidad>(id);
            }
        }
        public Entidad Modificar(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                sesion.Update(entidad);
                sesion.Flush();
            }
            return entidad;
        }
        public void Eliminar(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                sesion.Delete(entidad);
                sesion.Flush();
            }
        }
        public ICollection<Entidad> ListarTodos()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Entidad));
                return busqueda.List<Entidad>();
            }
        }

        public ICollection<Entidad> ListarTodosStatusActive(string table)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                string query = "from " + table + " where estado=1";
                IQuery busqueda = sesion.CreateQuery(query);
                return busqueda.List<Entidad>();
            }
        }
    }
}