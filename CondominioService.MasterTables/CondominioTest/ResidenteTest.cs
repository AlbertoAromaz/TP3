using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
                NroDocumento = "70517584",
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
            Assert.AreEqual("2", resultResidente.Codigo.ToString());  // compara que devuelva el codigo del nuevo registro  de residente creado

        }

        [TestMethod]
        public void Test_Crear_Repetido()
        {
            ResidenteWS.ResidenteServiceClient proxy = new ResidenteWS.ResidenteServiceClient();
            //OBJETO ENTIDAD QUE SE pasa al metodo
            ResidenteWS.Residente objResidente = new ResidenteWS.Residente()
            {
                TipoDocumento = "01",
                NroDocumento = "70517084",
                Nombres = "Lisseth",
                ApellidoMaterno = "Funes",
                ApellidoPaterno = "Tasayco",
                Estado = "1",
                FechaNacimiento = Convert.ToDateTime("13/04/1991"),
                Correo = "liz@gmail.com",
                Celular = "949777777",
                Sexo = "F"
            };

            // Objeto entidad resultante
            ResidenteWS.Residente resultResidente = new ResidenteWS.Residente();
            // Probando...
            try
            {
                resultResidente = proxy.CrearResidente(objResidente);
            }
            catch (FaultException<ResidenteWS.RepetidoException> fe)
            {
                Assert.AreEqual("01", fe.Detail.Codigo);
                Assert.AreEqual("Residente ya existe", fe.Detail.Mensaje);
                Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
            }
        }

        [TestMethod]
        public void Test_Eliminar()
        {
            ResidenteWS.ResidenteServiceClient proxy = new ResidenteWS.ResidenteServiceClient();
            proxy.EliminarResidente(1);

            ResidenteWS.Residente[] lst = proxy.listarResidentes();
            Assert.AreEqual(0, lst.Length);
        }
        [TestMethod]
        public void Test_Listar()
        {
            ResidenteWS.ResidenteServiceClient proxy = new ResidenteWS.ResidenteServiceClient();
            ResidenteWS.Residente[] lst = proxy.listarResidentes();
            Assert.AreEqual(2, lst.Length);
        }

    }
}
