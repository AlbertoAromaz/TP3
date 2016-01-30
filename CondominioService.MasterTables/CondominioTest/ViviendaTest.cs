using System;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CondominioTest
{
    /// <summary>
    /// Descripción resumida de ViviendaTest
    /// </summary>
    [TestClass]
    public class ViviendaTest
    {
        public ViviendaTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test1_MetrajeValido()
        {
            //1.Instanciar
            ViviendaWS.ViviendaServiceClient proxy = new ViviendaWS.ViviendaServiceClient();
            ViviendaWS.Vivienda viviendaResultado = new ViviendaWS.Vivienda();

            try
            {

                // 2. Invoca el método a probar
                viviendaResultado = proxy.CrearVivienda(1,1,100,0,true,4,1);
            }
            catch (FaultException<ViviendaWS.RepetidoException> fe)
            {
                // 3. Verificar/validar el resultado esperado
                Assert.AreEqual("Ingrese un metraje de vivienda válido", fe.Detail.Mensaje);
            }


        }

        [TestMethod]
        public void Test2_ViviendaDuplicada()
        {
            //1.Instanciar
            ViviendaWS.ViviendaServiceClient proxy = new ViviendaWS.ViviendaServiceClient();
            ViviendaWS.Vivienda viviendaResultado = new ViviendaWS.Vivienda();

            try
            {

                // 2. Invoca el método a probar
                viviendaResultado = proxy.CrearVivienda(1, 1, 112, (decimal)120.00, true, 4, 1);
            }
            catch (FaultException<ViviendaWS.RepetidoException> fe)
            {
                // 3. Verificar/validar el resultado esperado
                Assert.AreEqual("Ya existe una vivienda para la ubicación ingresada: Zona A - 112", fe.Detail.Mensaje);
            }


        }

        [TestMethod]
        public void Test3_CrearVivienda_OK()
        {
            //1.Instanciar
            ViviendaWS.ViviendaServiceClient proxy = new ViviendaWS.ViviendaServiceClient();
            ViviendaWS.Vivienda viviendaResultado = new ViviendaWS.Vivienda();

            try
            {
                // 2. Invoca el método a probar
                viviendaResultado = proxy.CrearVivienda(1, 1, 113, (decimal)120.00, true, 4, 1);

                // 3. Verificar/validar el resultado esperado
                Assert.AreEqual("4", viviendaResultado.CodigoVivienda.ToString()); // Compara 
            }
            catch (FaultException<ViviendaWS.RepetidoException> fe)
            { 
            
            
            }
           


        }
    }
}
