<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.Facturacion.Dominio;
using CondominioService.Facturacion.Persistencia;

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

        public Dominio.Cuota GenerarCuotas(Dominio.Cuota cuotaACrear)
        {
            throw new NotImplementedException();
        }

        public Dominio.Cuota ObtenerCuota(string codigoCuota)
        {
            throw new NotImplementedException();
        }

        public Dominio.Cuota RegistrarPago(Dominio.Cuota cuotaAModificar)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Cuota> BuscarPagos()
        {
            throw new NotImplementedException();
        }
    }
}
=======
﻿using System;
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
        public List<Cuota>GenerarCuotas(string codigoContrato)
        {
            List<Cuota> lstCuota = new List<Cuota>();
            try
            {
                if(existeCuota(codigoContrato))
                    throw new WebFaultException<string>(string.Format("Las cuotas para el contrato: {0} ya fueron generadas.", codigoContrato), HttpStatusCode.InternalServerError);

                lstCuota = CuotaDAO.GenerarCuotas(int.Parse(codigoContrato));
            }
            catch {
                throw;
            }

            return lstCuota;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoCuota"></param>
        /// <returns></returns>
        public Cuota ObtenerCuota(string codigoCuota)
        {
            return CuotaDAO.Obtener(int.Parse(codigoCuota));
        }

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
>>>>>>> 52d0721f85254feaa743de4d58f4acfc0492816f
