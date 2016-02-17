using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace CondominioService.ContratoAquiler
{
    public class ContratoService : IContratoService
    {
        private ContratoDAO dao = new ContratoDAO();

        public Contrato CrearContrato(Contrato contratoACrear)
        {
            Contrato objCont;
            try
            {
                Respuesta obj = dao.ValidarContrato(contratoACrear.CodigoVivienda, contratoACrear.CodigoResidente, Convert.ToDateTime(contratoACrear.FechaIniResidencia));

                if (obj != null)
                {
                    if (obj.ExisteVivienda == 0)
                    {
                        throw new WebFaultException<string>(
                       "La vivienda no se encuentra disponible para el periodo indicado", HttpStatusCode.InternalServerError);
                    }
                    else

                        if (obj.ExisteMoroso == 1)
                        {
                            throw new WebFaultException<string>(
                                "Residente con deuda pendiente", HttpStatusCode.InternalServerError);
                        }
                }

                objCont = dao.ContratoGenerar(contratoACrear);
                // Generacion de  Cuotas
                string postdata = "{\"CodigoContrato\":\"" + objCont.CodigoContrato.ToString() + "\"}"; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:7141/CuotaService.svc/CuotaService");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                req.GetResponse(); 
            }
            catch
            {
                throw;
            }
            
            return objCont;
        }
        

        public Contrato Obtener(string codigocontrato)
        {
            return dao.ObtenerContrato(codigocontrato);                                
            
        }


        public Contrato ModificarContrato(Contrato contratoAModificar)
        {
            return dao.ModificarContrato(contratoAModificar);
        }

        public void EliminarContrato(string codigoContrato)
        {
            dao.EliminarContrato(int.Parse(codigoContrato));    
        }


        public List<Contrato> ListarContratos()
        {
            return dao.ListarContrato();
        }

        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return dao.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }






    }
}
