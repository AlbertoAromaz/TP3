using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.Facturacion.Dominio;
using System.ServiceModel.Web;

namespace CondominioService.Facturacion
{
    
    [ServiceContract]
    public interface ICuotaService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> GenerarCuotas(Cuota objCuota);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCuota"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        Cuota ActualizarPagoDeCuotas(Cuota objCuota);


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="codigoCuota"></param>
        ///// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "CuotaService/{codigoCuota}", ResponseFormat = WebMessageFormat.Json)]
        //Cuota ObtenerCuota(string codigoCuota);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoResidente"></param>
        /// <param name="codigoVivienda"></param>
        /// <param name="estadoCuota"></param>
        /// <param name="fecIni"></param>
        /// <param name="fecFin"></param>
        /// <returns></returns>
        [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "CuotaService/BuscarCuota?codigoContrato={codigoContrato}&codigoResidente={codigoResidente}&codigoVivienda={codigoVivienda}", ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService/{codigoContrato},{codigoResidente},{codigoVivienda},{estadoCuota},{fecIni},{fecFin}", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> BuscarCuota(string codigoContrato, string codigoResidente, string codigoVivienda, string estadoCuota, string fecIni, string fecFin);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> ListarCuotas();

        

        

        
    }
}
