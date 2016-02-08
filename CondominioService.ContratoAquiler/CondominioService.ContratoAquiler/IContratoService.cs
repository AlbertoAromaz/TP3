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
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        Contrato GenerarContrato(Contrato ContratoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ContratoService/{codigoContrato}", ResponseFormat = WebMessageFormat.Json)]
        Contrato Obtener(string codigocontrato);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        Contrato ModificarContrato(Contrato contratoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "ContratoService/{codigoContrato}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarContrato(string codigocontrato);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ContratoService", ResponseFormat = WebMessageFormat.Json)]
        List<Contrato> ListarContratos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ObtenerCostoAquilerMensual?codigoVivienda={codigoVivienda}&fechaContrato={fechaContrato}", ResponseFormat = WebMessageFormat.Json)]
        decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato);
       
        
    }
}
