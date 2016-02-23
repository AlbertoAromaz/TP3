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

        /// <summary>
        /// Esta prueba valida que el contrato sea creado y las cuotas sen generadas automaticamente
        /// </summary>
        [TestMethod]
        public void CrearContrato_ConCuotasOnLine_OK()
        {
             //Prueba de creacion de contrato via HTTP POST
            string postdata = "{\"CodigoVivienda\":\"4\",\"CodigoResidente\":\"4\",\"FechaContrato\":\"21/02/2016\",\"FechaIniResidencia\":\"21/02/2016\",\"CostoMensual\":\"1100.00\",\"Periodo\":\"6\",\"Estado\":\"1\",\"UsuarioCreacion\":\"AZAMORA\",\"FechaCreacion\":\"21/02/2016\"}";

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
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
           // Assert.AreEqual(4, contratoCreado.CodigoContrato);

            string uri = String.Format("http://localhost:7141/CuotaService.svc/CuotaService/{0},{1},{2},{3},{4},{5}", contratoCreado.CodigoContrato, "0", "0", "0", "0", "0");
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
           .Create(uri);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string cuotaJson = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();

            List<Cuota> lstCuotas = js2.Deserialize<List<Cuota>>(cuotaJson);
            Assert.AreEqual("6", lstCuotas.Count.ToString());

        }

        /// <summary>
        /// Este metodo crea el contrato con las cuotas off line.
        /// Luego se invoca al metodo listar para que sincronize las cuotas y finalmente se ejecuta el metodo buscar para validar que las cuotas hayan sido generadas para el contrato creado
        /// </summary>
        [TestMethod]
        public void CrearContrato_ConCuotasOffLine_OK()
        {
            //Prueba de creacion de contrato via HTTP POST
            string postdata = "{\"CodigoVivienda\":\"3\",\"CodigoResidente\":\"3\",\"FechaContrato\":\"21/02/2016\",\"FechaIniResidencia\":\"21/02/2016\",\"CostoMensual\":\"1100.00\",\"Periodo\":\"6\",\"Estado\":\"1\",\"UsuarioCreacion\":\"AZAMORA\",\"FechaCreacion\":\"21/02/2016\"}";

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest reqCrearContrato = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
            reqCrearContrato.Method = "POST";
            reqCrearContrato.ContentLength = data.Length;
            reqCrearContrato.ContentType = "application/json";
            var reqStream = reqCrearContrato.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse resCrearContrato = (HttpWebResponse)reqCrearContrato.GetResponse();
            StreamReader reader = new StreamReader(resCrearContrato.GetResponseStream());
            string contratoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);
            
            
            // Ejecuto el metodo listar para sincronizar las cuotas
            string uriListarCuotas = String.Format("http://localhost:7141/CuotaService.svc/CuotaService");
            HttpWebRequest reqListarCuotas = (HttpWebRequest)WebRequest
           .Create(uriListarCuotas);
            reqListarCuotas.Method = "GET";
            reqListarCuotas.GetResponse();
            

            // Resultado: valido con el metodo buscar que se hayan creado las cuotas para el contrato creado
            string uriBuscarCuotas = string.Format("http://localhost:7141/CuotaService.svc/CuotaService/{0},{1},{2},{3},{4},{5}", contratoCreado.CodigoContrato.ToString(), 0, 0, 0, 0, 0);
            HttpWebRequest reqBuscarCuotas = (HttpWebRequest)WebRequest
           .Create(uriBuscarCuotas);
            reqBuscarCuotas.Method = "GET";
            HttpWebResponse resBuscarCuotas = (HttpWebResponse)reqBuscarCuotas.GetResponse();
            StreamReader readerBuscarCuotas = new StreamReader(resBuscarCuotas.GetResponseStream());
            string cuotaJson = readerBuscarCuotas.ReadToEnd();
            JavaScriptSerializer jsBuscarCuotas = new JavaScriptSerializer();

            List<Cuota> lstCuotas = jsBuscarCuotas.Deserialize<List<Cuota>>(cuotaJson);
            Assert.AreEqual(6, lstCuotas.Count);
            
        }



        /// <summary>
        /// Este prueba que no se pueda generar un contrato para una vivienda no disponible
        /// </summary>
        [TestMethod]
        public void CrearContrato_Vivienda_NoDisponible()
        {
            //Prueba de creacion de contrato via HTTP POST
            string postdata = "{\"CodigoVivienda\":\"1\",\"CodigoResidente\":\"1\",\"FechaContrato\":\"02/12/2016\",\"FechaIniResidencia\":\"02/12/2016\",\"CostoMensual\":\"100.00\",\"Periodo\":\"2016\",\"Estado\":\"1\",\"UsuarioCreacion\":\"AZAMORA\",\"FechaCreacion\":\"02/12/2016\"}";

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res ;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string contratoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);

                Assert.AreEqual(5, contratoCreado.CodigoContrato);
                Assert.AreEqual(1, contratoCreado.CodigoVivienda);
                Assert.AreEqual(1, contratoCreado.CodigoResidente);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaContrato);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaIniResidencia);
                Assert.AreEqual("100.00", contratoCreado.CostoMensual);
                Assert.AreEqual(2016, contratoCreado.Periodo);
                Assert.AreEqual("1", contratoCreado.Estado);
                Assert.AreEqual("AZAMORA", contratoCreado.UsuarioCreacion);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaCreacion);
            }
            catch (WebException e) 
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("La vivienda no se encuentra disponible para el periodo indicado", mensaje);
            }
        }

        /// <summary>
        /// Este metodo prueba que no se pueda generar un contrato para un residente moroso
        /// </summary>
        [TestMethod]
        public void CrearContrato_Residente_Moroso()
        {
            //Prueba de creacion de contrato via HTTP POST
            string postdata = "{\"CodigoVivienda\":\"1\",\"CodigoResidente\":\"1\",\"FechaContrato\":\"02/12/2016\",\"FechaIniResidencia\":\"12/02/2016\",\"CostoMensual\":\"100.00\",\"Periodo\":\"2016\",\"Estado\":\"1\",\"UsuarioCreacion\":\"AZAMORA\",\"FechaCreacion\":\"02/12/2016\"}";

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string contratoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);

                Assert.AreEqual(5, contratoCreado.CodigoContrato);
                Assert.AreEqual(1, contratoCreado.CodigoVivienda);
                Assert.AreEqual(1, contratoCreado.CodigoResidente);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaContrato);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaIniResidencia);
                Assert.AreEqual("100.00", contratoCreado.CostoMensual);
                Assert.AreEqual(2016, contratoCreado.Periodo);
                Assert.AreEqual("1", contratoCreado.Estado);
                Assert.AreEqual("AZAMORA", contratoCreado.UsuarioCreacion);
                Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoCreado.FechaCreacion);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Residente con deuda pendiente", mensaje);
            }

        }

        /// <summary>
        /// Este metodo prueba obtener los datos del contrato
        /// </summary>
        [TestMethod]
        public void ObtenerContrato()
        {
            // Prueba obtencion del contrato via HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService/5");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string contratoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Contrato contratoObtenido = js2.Deserialize<Contrato>(contratoJson2);


            Assert.AreEqual(5, contratoObtenido.CodigoContrato);
            Assert.AreEqual(1, contratoObtenido.CodigoVivienda);
            Assert.AreEqual(1, contratoObtenido.CodigoResidente);
            Assert.AreEqual("100.00", contratoObtenido.CostoMensual);
            Assert.AreEqual("02/12/2016 12:00:00 a.m.", contratoObtenido.FechaContrato);
            Assert.AreEqual(2016, contratoObtenido.Periodo);
        }

        #region Por Construir

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

        #endregion
       

        /// <summary>
        ///  Este metodo prueba listar los contratos listados
        /// </summary>
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

            Assert.AreEqual(5,contratosObt.Length);
        }

        /// <summary>
        /// Este metodo prueba obtener el costo mensual del aquiler
        /// </summary>
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
