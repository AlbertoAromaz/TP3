using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;

namespace CondominioService.ContratoAquiler
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ContratoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ContratoService.svc o ContratoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ContratoService : IContratoService
    {

        #region properties
        private ContratoDAO contratoDAO = null;
        private ContratoDAO ContratoDAO
        {
            get
            {
                if (contratoDAO == null)
                    contratoDAO = new ContratoDAO();
                return contratoDAO;
            }
        }

             


        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContratoACrear"></param>
        /// <returns></returns>
        public Dominio.Contrato GenerarContrato(Dominio.Contrato ContratoACrear)
        {

            // Generar Contrato

            // Generar Cuotas
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        public Dominio.Contrato ObtenerContrato(string codigoContrato)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratoAModificar"></param>
        /// <returns></returns>
        public Dominio.Contrato ModificarContrato(Dominio.Contrato contratoAModificar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        public void EliminarAlumno(string codigoContrato)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dominio.Contrato> ListarContratos()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="fechaContrato"></param>
        /// <returns></returns>
        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return ContratoDAO.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }
    }
}
