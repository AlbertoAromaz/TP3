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
using System.Messaging;

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
        /// Este metodo genera la cuotas mensuales de aquiler segun el contrato
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
        /// Este metodo actualiza la fecha de pago y el estado de la cuota a cancelado.
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

       

        /// <summary>
        /// Este metodo busca las cuotas segun el criterio seleccionado
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

        /// <summary>
        /// Este metodo sincroniza la generación de cuotas que no fueron creadas debido a disponibilidad del servicio. Asi  mismo, lista las cuotas generadas.
        /// </summary>
        /// <returns></returns>
        public List<Cuota> ListarCuotas()
        {
            SincronizarGeneracionCuotas();
            return CuotaDAO.ListarCuotas();
        }


        /// <summary>
        /// Sincroniza la cuotas que no se hayan generado
        /// </summary>
        internal void SincronizarGeneracionCuotas()
        {

            string ruta = @".\private$\CondominioTransaction";
            if (!MessageQueue.Exists(ruta))
                MessageQueue.Create(ruta);

            MessageQueue cola = new MessageQueue(ruta);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Cuota) });

            int cantidad = cola.GetAllMessages().Count();
            int n = 0;
            while (n < cantidad)
            {

                Message mensaje = cola.Receive();
                Cuota cuotaACrear = (Cuota)mensaje.Body;

                GenerarCuotas(cuotaACrear);
                n++;
            }
        }

        /// <summary>
        /// Este metodo verifica si la cuota ya existe
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        internal bool existeCuota(string codigoContrato)
        {
            List<Cuota> lstCuota = BuscarCuota(codigoContrato, string.Empty, string.Empty);
            return lstCuota.Count > 0;

        }

        public List<Cuota> ConsultarCuota(string codigoContrato, string codigoResidente, string codigoVivienda, string estado, DateTime FechaIni, DateTime FechaFIn)
        {
            int iCodigoContrato = (codigoContrato == "") ? 0 : int.Parse(codigoContrato);
            int iCodigoResidente = (codigoResidente == "") ? 0 : int.Parse(codigoResidente);
            int iCodigoVivienda = (codigoVivienda == "") ? 0 : int.Parse(codigoVivienda);
            //int iestado = (estado == "") ? 0 : int.Parse(estado);
            //int iFechaIni = (codigoVivienda == "") ? 0 : int.Parse(codigoVivienda);
            //int iFechaFin = (codigoVivienda == "") ? 0 : int.Parse(codigoVivienda);
            //return CuotaDAO.ConsultarCuota(iCodigoContrato, iCodigoResidente, iCodigoVivienda, estado, DateTime.Parse(FechaIni), DateTime.Parse(FechaFIn));
            return CuotaDAO.ConsultarCuota(iCodigoContrato, iCodigoResidente, iCodigoVivienda, estado, FechaIni, FechaFIn);
        }
    }
}
