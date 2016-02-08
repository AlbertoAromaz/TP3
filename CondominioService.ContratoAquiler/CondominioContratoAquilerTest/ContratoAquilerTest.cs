using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace CondominioContratoAquilerTest
{

    [TestClass]
    public class ContratoAquilerTest
    {


        [TestMethod]
        public void CREARTest()
        {
            // Prueba de creacion de contrato via HTTP POST
            string postdata = "{\"CodigoContrato\":\"10\",\"CodigoResidente\":\"10\",\"CodigoVivienda\":\"6\",\"CostoMensual\":\"500.00\",\"FechaContrato\":\"2017-12-02\",\"Periodo\":\"201602\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:5364/ContratoService.svc/ContratoService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string contratoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);
            Assert.AreEqual("10", contratoCreado.CodigoContrato);
            Assert.AreEqual("10", contratoCreado.CodigoResidente);
            Assert.AreEqual("6", contratoCreado.CodigoVivienda);
            Assert.AreEqual("500.00", contratoCreado.CostoMensual);
            Assert.AreEqual("2017-12-02", contratoCreado.FechaContrato);
            Assert.AreEqual("201602", contratoCreado.Periodo);
        }

              

        [TestMethod]
        public void ObtenerCostoAquilerMensual()
        {
            // Prueba de Obtener Costo Aquiler Mensual  vía HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:5364/ContratoService.svc/ObtenerCostoAquilerMensual?codigoVivienda=1&fechaContrato=07/02/2016");
            req.Method = "GET";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string contratoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            decimal costo = js.Deserialize<decimal>(contratoJson);

            Assert.AreEqual("1100.00", costo.ToString());

        }
    }
}
