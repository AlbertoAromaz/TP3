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
        /// <returns></returns>
        [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "CuotaService/BuscarCuota?codigoContrato={codigoContrato}&codigoResidente={codigoResidente}&codigoVivienda={codigoVivienda}", ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService/{codigoContrato},{codigoResidente},{codigoVivienda}", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota>BuscarCuota(string codigoContrato, string codigoResidente,string codigoVivienda);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> ListarCuotas();

        

        

        
    }
}
