using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.ContratoAquiler.Dominio;
using System.ServiceModel.Web;


namespace CondominioService.ContratoAquiler
{
    
    [ServiceContract]
    public interface IContratoService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContratoACrear"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        Contrato GenerarContrato(Contrato ContratoACrear);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ContratoService/{codigoContrato}", ResponseFormat = WebMessageFormat.Json)]
        Contrato ObtenerContrato(string codigoContrato);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratoAModificar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        Contrato ModificarContrato(Contrato contratoAModificar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "ContratoService/{codigoContrato}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarAlumno(string codigoContrato);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        List<Contrato> ListarContratos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="fechaContrato"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ObtenerCostoAquilerMensual?codigoVivienda={codigoVivienda}&fechaContrato={fechaContrato}", ResponseFormat = WebMessageFormat.Json)]
        decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato);
       
        
    }
}
