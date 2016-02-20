using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.Facturacion.Dominio;
using CondominioService.Facturacion.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace CondominioService.Facturacion
{
    
    public class CuotaService : ICuotaService
    {

        #region properties
        private CuotaDAO cuotaDAO = null;
        private CuotaDAO CuotaDAO
        {
            get
            {
                if (cuotaDAO == null)
                    cuotaDAO = new CuotaDAO();
                return cuotaDAO;
            }
        }




        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        public List<Cuota>GenerarCuotas(Cuota objCuota)
        {
            List<Cuota> lstCuota = new List<Cuota>();
            try
            {
                if(existeCuota(objCuota.CodigoContrato.ToString()))
                    throw new WebFaultException<string>(string.Format("Las cuotas para el contrato: {0} ya fueron generadas.", objCuota.CodigoContrato.ToString()), HttpStatusCode.InternalServerError);

                lstCuota = CuotaDAO.GenerarCuotas(objCuota.CodigoContrato);
            }
            catch {
                throw;
            }

            return lstCuota;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodigoContrato"></param>
        /// <param name="CodigoCuota"></param>
        /// <returns></returns>
        public List<Cuota> ActualizarCancelacionCuotas(Cuota objCuota)
        {
            List<Cuota> lstCuota = new List<Cuota>();
            try
            {
                // if (existeCuota(objCuota.CodigoContrato.ToString()))
                //     throw new WebFaultException<string>(string.Format("Las cuotas para el contrato: {0} ya fueron generadas.", objCuota.CodigoContrato.ToString()), HttpStatusCode.InternalServerError);

                lstCuota = CuotaDAO.
                    ActualizarCancelacionCuota(objCuota.CodigoContrato, objCuota.CodigoCuota);
            }
            catch
            {
                throw;
            }

            return lstCuota;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="codigoCuota"></param>
        ///// <returns></returns>
        //public Cuota ObtenerCuota(string codigoCuota)
        //{
        //    return CuotaDAO.Obtener(int.Parse(codigoCuota));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoResidente"></param>
        /// <param name="codigoVivienda"></param>
        /// <returns></returns>
        public List<Cuota> BuscarCuota(string codigoContrato, string codigoResidente, string codigoVivienda)
        {
            int iCodigoContrato=(codigoContrato=="")? 0: int.Parse(codigoContrato);
            int iCodigoResidente=(codigoResidente=="")? 0: int.Parse(codigoResidente);
            int iCodigoVivienda=(codigoVivienda=="")? 0: int.Parse(codigoVivienda);
            return CuotaDAO.BuscarCuota(iCodigoContrato, iCodigoResidente, iCodigoVivienda);
        }

        public List<Cuota> ListarCuotas()
        {
            return CuotaDAO.ListarCuotas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        internal bool existeCuota(string codigoContrato)
        {
            List<Cuota> lstCuota = BuscarCuota(codigoContrato, string.Empty, string.Empty);
            return lstCuota.Count > 0;

        }
    }
}
