using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.MasterTables.Dominio;
using CondominioService.MasterTables.Persistencia;

namespace CondominioService.MasterTables
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ViviendaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ViviendaService.svc o ViviendaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ViviendaService : IViviendaService
    {

        #region properties
        private ViviendaDAO viviendaDAO = null;
        private ViviendaDAO ViviendaDAO
        {
            get
            {
                if (viviendaDAO == null)
                    viviendaDAO = new ViviendaDAO();
                return viviendaDAO;
            }
        }

        private UbicacionDAO ubicacionDAO = null;
        private UbicacionDAO UbicacionDAO
        {
            get
            {
                if (ubicacionDAO == null)
                    ubicacionDAO = new UbicacionDAO();
                return ubicacionDAO;
            }
        }

        private TipoViviendaDAO tipoViviendaDAO = null;
        private TipoViviendaDAO TipoViviendaDAO
        {
            get
            {
                if (tipoViviendaDAO == null)
                    tipoViviendaDAO = new TipoViviendaDAO();
                return tipoViviendaDAO;
            }
        }


        #endregion

        public Vivienda CrearVivienda(Vivienda objVivienda)
        {
            //try
            //{
            //    //Ubicacion ubicacionExistente = ubicacionDAO.Obtener(codigoTipoUbicacion);
            //    //TipoVivienda tipoViviendaExistente = TipoViviendaDAO.Obtener(codigoTipoVivienda);

            //    //Vivienda viviendaACrear = new Vivienda()
            //    //{
            //    //    Ubicacion.CodigoUbicacion = objVivienda.Ubicacion.CodigoUbicacion,
            //    //    TipoVivienda.CodigoTipoVivienda = objVivienda.TipoVivienda.CodigoTipoVivienda,
            //    //    Metraje = objVivienda.Metraje,
            //    //    NumeroVivienda = objVivienda.NumeroVivienda,
                   

            //    //};

            //}
            //catch {

            //    throw;
            //}


            ////return ViviendaDAO.Crear(viviendaACrear);
            throw new NotImplementedException();
        }

        public Vivienda ObtenerVivienda(int codigoVivienda)
        {
            throw new NotImplementedException();
        }

        public Vivienda ModificarVivienda(Vivienda objVivienda)
        {
            throw new NotImplementedException();
        }

        public void EliminarVivienda(int codigoVivienda)
        {
            throw new NotImplementedException();
        }

        public List<Vivienda> ListarViviendas()
        {
            throw new NotImplementedException();
        }

        public decimal ObtenerCostoDeVivienda(int codigoVivienda, DateTime fechaContrato)
        {
            throw new NotImplementedException();
        }
    }
}
