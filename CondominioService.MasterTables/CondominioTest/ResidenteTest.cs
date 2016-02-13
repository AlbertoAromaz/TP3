using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioTest
{
    [TestClass]
    public class ResidenteTest
    {

        [TestMethod]
        public void Test_Crear_OK()
        {
            //1. Instanciar el objeto a probar
            ResidenteWS.ResidenteServiceClient proxy = new ResidenteWS.ResidenteServiceClient();
            ResidenteWS.Residente resultResidente = new ResidenteWS.Residente();

            ResidenteWS.Residente objResidente = new ResidenteWS.Residente()
            {
                TipoDocumento = "01",
                NroDocumento = "70517084",
                Nombres = "Lisseth",
                ApellidoMaterno = "Funes",
                ApellidoPaterno = "Tasayco",
                Estado = "1",
                FechaNacimiento = Convert.ToDateTime("13/04/1991"),
                FechaCreacion = Convert.ToDateTime("23/01/2016"),
                FechaModificacion = DateTime.Now,
                Correo = "liz@gmail.com",
                Celular = "949777777",
                Sexo = "F"
            };

            resultResidente = proxy.CrearResidente(objResidente);
            Assert.AreEqual("5", resultResidente.Codigo);  // compara que devuelva el codigo del nuevo registro  de residente creado

        }

    }
}
