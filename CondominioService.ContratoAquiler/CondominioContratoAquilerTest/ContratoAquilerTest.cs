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
        public void CrearContrato()
        {
            // Prueba de creacion de contrato via HTTP POST
            //string postdata = "{\"CodigoContrato\":\"24\",\"CodigoVivienda\":\"6\",\"CodigoResidente\":\"10\",\"FechaContrato\":\"02/12/2016\",\"FechaIniResidencia\":\"02/12/2016\",\"CostoMensual\":\"100.00\",\"Periodo\":\"2016\",\"Estado\":\"1\",\"UsuarioCreacion\":\"AZAMORA\",\"FechaCreacion\":\"02/12/2016\",\"AZAMORA\":\"02/12/2016\",\"FechaModificacion\":\"02/12/2016\"}";
            //string postdata = "{\"CodigoVivienda\":\"6\",\"CodigoResidente\":\"10\",\"FechaContrato\":\"02/12/2016\",\"FechaIniResidencia\":\"02/12/2016\",\"CostoMensual\":\"500.00\",\"Periodo\":\"2016\"}";
            
            //byte[] data = Encoding.UTF8.GetBytes(postdata);
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
            //req.Method = "POST";
            //req.ContentLength = data.Length;
            //req.ContentType = "application/json";
            //var reqStream = req.GetRequestStream();
            //reqStream.Write(data, 0, data.Length);
            //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //StreamReader reader = new StreamReader(res.GetResponseStream());
            //string contratoJson = reader.ReadToEnd();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);
            
            //Assert.AreEqual("24", contratoCreado.CodigoContrato);
            //Assert.AreEqual("6", contratoCreado.CodigoVivienda);
            //Assert.AreEqual("10", contratoCreado.CodigoResidente);
            //Assert.AreEqual("02/12/2016", contratoCreado.FechaContrato);
            //Assert.AreEqual("02/12/2016", contratoCreado.FechaIniResidencia);
            //Assert.AreEqual("500.00", contratoCreado.CostoMensual);
            //Assert.AreEqual("2016", contratoCreado.Periodo);
            //Assert.AreEqual("1", contratoCreado.Periodo);
            //Assert.AreEqual("AZAMORA", contratoCreado.UsuarioCreacion);
            //Assert.AreEqual("02/12/2016", contratoCreado.FechaCreacion);
            //Assert.AreEqual("AZAMORA", contratoCreado.UsuarioModificacion);
            //Assert.AreEqual("02/12/2016", contratoCreado.FechaModificacion);

                    }

        [TestMethod]
        public void ObtenerContrato()
        {
            // Prueba obtencion del contrato via HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:5364/ContratoService.svc/ContratoService/23");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string contratoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Contrato contratoObtenido = js2.Deserialize<Contrato>(contratoJson2);

            Assert.AreEqual("23", contratoObtenido.CodigoContrato.ToString());
            Assert.AreEqual("10", contratoObtenido.CodigoResidente.ToString());
            Assert.AreEqual("6", contratoObtenido.CodigoVivienda.ToString());
            Assert.AreEqual("500.00", contratoObtenido.CostoMensual.ToString());
            Assert.AreEqual("02/12/2016 05:00:00 a.m.", contratoObtenido.FechaContrato.ToString());
            Assert.AreEqual("201602", contratoObtenido.Periodo.ToString());
        }

        [TestMethod]
        public void ModificarContrato()
        {
            //string posdata = "{\"Codigocontrato\":\"23\",\"Codigoresidente\":\"10\",\"Codigovivienda\":\"6\",\"CostoMensual\":\"20.00\"}"; //JSON
            //byte[] data = Encoding.UTF8.GetBytes(posdata);
            //HttpWebRequest req = (HttpWebRequest)WebRequest
            //    .Create("http://localhost:5364/ContratoService.svc/ContratoService");
            //req.Method = "PUT";
            //req.ContentLength = data.Length;
            //req.ContentType = "application/json";
            //var reqStream = req.GetRequestStream();
            //reqStream.Write(data, 0, data.Length);
            //HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            //StreamReader reader = new StreamReader(res.GetResponseStream());
            //string contratoJson = reader.ReadToEnd();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);
            //Assert.AreEqual("23", contratoCreado.CodigoContrato);
            //Assert.AreEqual("10", contratoCreado.CodigoResidente);
            //Assert.AreEqual("6", contratoCreado.CodigoVivienda);
            //Assert.AreEqual("20.00", contratoCreado.CostoMensual);

            

        }

        [TestMethod]
        public void EliminarContrato()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:5364/ContratoService.svc/ContratoService/24");
            req2.Method = "DELETE";
            req2.GetResponse();

            // Obtener codigo eliminado
            HttpWebRequest req3 = (HttpWebRequest)WebRequest
                .Create("http://localhost:5364/ContratoService.svc/ContratoService/24");
            req3.Method = "GET";
            HttpWebResponse res3 = (HttpWebResponse)req3.GetResponse();
            StreamReader reader2 = new StreamReader(res3.GetResponseStream());
            string contratoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Contrato contratoObtenido = js2.Deserialize<Contrato>(contratoJson2);
            Assert.AreEqual(null, contratoObtenido);
        }

        [TestMethod]
        public void ListarContrato()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:5364/ContratoService.svc/ContratoService");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string contratoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Contrato[] contratosObt = js2.Deserialize<Contrato[]>(contratoJson2);

            Assert.AreEqual(1,contratosObt.Length);
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
