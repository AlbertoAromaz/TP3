<<<<<<< HEAD
﻿using System;
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
        /// <param name="cuotaACrear"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        Cuota GenerarCuotas(Cuota cuotaACrear);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService/{codigoCuota}", ResponseFormat = WebMessageFormat.Json)]
        Cuota ObtenerCuota(string codigoCuota);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuotaAModificar"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        Cuota RegistrarPago(Cuota cuotaAModificar);

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> BuscarPagos();

        
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
        [WebInvoke(Method = "POST", UriTemplate = "CuotaService/{codigoContrato}", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> GenerarCuotas(string codigoContrato);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoCuota"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService/{codigoCuota}", ResponseFormat = WebMessageFormat.Json)]
        Cuota ObtenerCuota(string codigoCuota);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoResidente"></param>
        /// <param name="codigoVivienda"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService/BuscarCuota?codigoContrato={codigoContrato}&codigoResidente={codigoResidente}&codigoVivienda={codigoVivienda}", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> BuscarCuota(string codigoContrato, string codigoResidente,string codigoVivienda);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CuotaService", ResponseFormat = WebMessageFormat.Json)]
        List<Cuota> ListarCuotas();

        

        

        
    }
}
>>>>>>> 52d0721f85254feaa743de4d58f4acfc0492816f
