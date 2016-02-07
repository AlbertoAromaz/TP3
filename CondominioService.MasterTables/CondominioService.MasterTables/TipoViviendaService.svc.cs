using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.Contrato.Dominio;
using CondominioService.Contrato.Persistencia;

namespace CondominioService.Contrato
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "TipoVivienda" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione TipoVivienda.svc o TipoVivienda.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class TipoViviendaService : ITipoViviendaService
    {

        #region properties
        private TipoViviendaDAO tipoViviendaDAO = null;
        private TipoViviendaDAO TipoViviendaDAO
        {
            get
            {
                if (tipoViviendaDAO == null)
                    tipoViviendaDAO = new TipoViviendaDAO();
                return tipoViviendaDAO;
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Created By: Evelyn De La Cruz 
        /// Descruption: This nethod will show the list of type of vivienda
        /// </summary>
        /// <returns></returns>
        public List<TipoVivienda> ListarTipoVivienda()
        {

            return TipoViviendaDAO.ListarTodos().ToList();
        }

        #endregion
    }
}
