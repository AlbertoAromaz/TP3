using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace CondominioFacturacionTest
{
    /// <summary>
    /// Descripción resumida de FacturacionTest
    /// </summary>
    [TestClass]
    public class FacturacionTest
    {

        /// <summary>
        /// Este metodo prueba que el sistema no permita generar cuotas de aquiler que ya fueron generadas
        /// </summary>
        [TestMethod]
        public void GenerarCuotasError()
        {
            string postdata = "{\"CodigoContrato\":\"1008\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
           
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string cuotaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();

                List<Cuota> lstCuotas = js.Deserialize<List<Cuota>>(cuotaJson);
                Assert.AreEqual("6", lstCuotas.Count.ToString());
 
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Las cuotas para el contrato: 1003 ya fueron generadas.", mensaje);
            }
        }

        /// <summary>
        /// Este metodo que se pueda buscar una cuota segun los criterios ingresados
        /// </summary>
        [TestMethod]
        public void BuscarCuota()
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService/3,0,0,'','',''");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cuotaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
                        
            List<Cuota> lstCuotas = js.Deserialize<List<Cuota>>(cuotaJson);
            Assert.AreEqual("6", lstCuotas.Count.ToString());
        }

        /// <summary>
        /// Este metodo prueba que se puedan listar cuotas
        /// </summary>
        [TestMethod]
        public void ListarCuotas()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cuotaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            List<Cuota> lstCuotas = js.Deserialize<List<Cuota>>(cuotaJson);
            Assert.AreEqual("6", lstCuotas.Count.ToString());

        }

        /// <summary>
        /// Este metodo prueba que no se actualice el pago porque la cuota ingresada se encuentra cancelada
        /// </summary>
        [TestMethod]
        public void ActualizarPagoDeCuotas_Error()
        {
            string postdata = "{\"CodigoCuota\":\"1002\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
         
            try
            {
                req.GetResponse();
                
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("La cuota seleccionado se encuentra cancelada.", mensaje);
            }
        }

        /// <summary>
        /// Este metodo prueba que el pago de la cuota se realizo correctamente debido a ello actualiza el estado de la cuota a CANCELADO
        /// </summary>
        [TestMethod]
        public void ActualizarPagoDeCuotas_OK()
        {
            string postdata = "{\"CodigoCuota\":\"1\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;

            Cuota objCuota = new Cuota();

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string cuotaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();

               objCuota = js.Deserialize<Cuota>(cuotaJson);
                Assert.AreEqual("CANCELADO", objCuota.Estado_Cuota.ToString());

            }
            catch 
            {
                Assert.AreEqual("ERROR", objCuota.Resultado);
            }
        }


    }
}
