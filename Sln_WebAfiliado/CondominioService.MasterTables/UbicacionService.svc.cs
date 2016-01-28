using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.MasterTables.Dominio;
using CondominioService.MasterTables.Persistencia;

namespace CondominioService.MasterTables
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Ubicacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Ubicacion.svc o Ubicacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UbicacionService : IUbicacionService
    {

        #region properties
        private UbicacionDAO ubicacionDAO = null;
        private UbicacionDAO UbicacionDAO
        {
            get
            {
                if (ubicacionDAO == null)
                    ubicacionDAO = new UbicacionDAO();
                return ubicacionDAO;
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Created By: Evelyn De La Cruz 
        /// Descruption: This nethod will show the list of ubication
        /// </summary>
        /// <returns></returns>
        public List<Ubicacion> ListarUbicacion()
        {

            return UbicacionDAO.ListarTodos().ToList();
        }

        #endregion
    }
}
