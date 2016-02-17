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

        [TestMethod]
        public void GenerarCuotasError()
        {
            string postdata = "{\"CodigoContrato\":\"3\"}"; //JSON
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
                Assert.AreEqual("Las cuotas para el contrato: 3 ya fueron generadas.", mensaje);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void BuscarCuota()
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:7141/CuotaService.svc/CuotaService/3,0,0");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cuotaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
                        
            List<Cuota> lstCuotas = js.Deserialize<List<Cuota>>(cuotaJson);
            Assert.AreEqual("6", lstCuotas.Count.ToString());
        }

        /// <summary>
        /// 
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





    }
}
