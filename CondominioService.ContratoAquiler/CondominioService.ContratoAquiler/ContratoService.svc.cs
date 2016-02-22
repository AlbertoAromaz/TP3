using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
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

        /// <summary>
        ///  Este metodo permite crear un contrato de aquiler. Asi mismo genera la cuotas por el pago del aquiler automaticamente.
        ///  En caso que el servicio de generacion de cuotas no este activo, se envia a una cola para que cuando se restablesca genere la cuotas.
        /// </summary>
        /// <param name="contratoACrear"></param>
        /// <returns></returns>
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
                GenerarCuotas(objCont);
               
            }
            catch
            {
                throw;
            }
            
            return objCont;
        }
        

        /// <summary>
        /// Obtiene los datos del contrato
        /// </summary>
        /// <param name="codigocontrato"></param>
        /// <returns></returns>
        public Contrato Obtener(string codigocontrato)
        {
            return dao.ObtenerContrato(codigocontrato);                                
            
        }


        /// <summary>
        /// Este metodo permite actualizar los datos del contrato
        /// </summary>
        /// <param name="contratoAModificar"></param>
        /// <returns></returns>
        public Contrato ModificarContrato(Contrato contratoAModificar)
        {
            return dao.ModificarContrato(contratoAModificar);
        }

        /// <summary>
        /// Este metodo permite eliminar un contrato
        /// </summary>
        /// <param name="codigoContrato"></param>
        public void EliminarContrato(string codigoContrato)
        {
            dao.EliminarContrato(int.Parse(codigoContrato));    
        }


        /// <summary>
        ///  Este metodo permite listar los contratos creados
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ListarContratos()
        {
            return dao.ListarContrato();
        }

        /// <summary>
        /// Este metodo permite obtener el costo del aquiler mensual de una vivienda segun la fecha de contrato
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="fechaContrato"></param>
        /// <returns></returns>
        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return dao.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }

        /// <summary>
        /// Este metodo genera la cuotas si el servicio esta activo. Caso contrario, lo envia el contrato a una cola para que las cuotas sean generadas despues.
        /// </summary>
        /// <param name="objCont"></param>
        private void GenerarCuotas(Contrato objCont)
        {
            try
            {
                string postdata = "{\"CodigoContrato\":\"" + objCont.CodigoContrato.ToString() + "\"}"; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:7142/CuotaService.svc/CuotaService");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                req.GetResponse(); 
            }
            catch
            {
                EnviarContratoACola(objCont.CodigoContrato);
            }
        
        }

        /// <summary>
        /// Este metodo envia el contrato a una cola para que se pueda generar las cuotas
        /// </summary>
        /// <param name="codigoContrato"></param>
        private void EnviarContratoACola(int codigoContrato)
        {
            string ruta = @".\private$\CondominioTransaction";
            if (!MessageQueue.Exists(ruta))
                MessageQueue.Create(ruta);

            MessageQueue cola = new MessageQueue(ruta);
            Message mensaje = new Message();
            mensaje.Label = "Cuotas a Generar";
            mensaje.Body = new Cuota { CodigoContrato= codigoContrato };
            cola.Send(mensaje);
        }


    }
}
