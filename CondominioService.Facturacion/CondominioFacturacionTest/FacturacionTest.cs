<<<<<<< HEAD
﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CondominioFacturacionTest
{
    /// <summary>
    /// Descripción resumida de FacturacionTest
    /// </summary>
    [TestClass]
    public class FacturacionTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
    }
}
=======
﻿using System;
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

            try
            {

                HttpWebRequest reqDel = (HttpWebRequest)WebRequest
                .Create("http://localhost:7141/CuotaService.svc/CuotaService/3");
                reqDel.Method = "POST";
                HttpWebResponse res = (HttpWebResponse)reqDel.GetResponse();
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
    }
}
>>>>>>> 52d0721f85254feaa743de4d58f4acfc0492816f
