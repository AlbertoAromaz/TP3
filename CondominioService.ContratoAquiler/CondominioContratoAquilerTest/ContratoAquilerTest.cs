using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;


namespace CondominioContratoAquilerTest
{
    /// <summary>
    /// Descripción resumida de ContratoAquilerTest
    /// </summary>
    [TestClass]
    public class ContratoAquilerTest
    {
              

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

            Assert.AreEqual("1100,00", costo.ToString());

        }
    }
}
