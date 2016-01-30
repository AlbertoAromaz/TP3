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

        #region Const
        private const string actionInsertar = "I";

        #endregion
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoTipoVivienda"></param>
        /// <param name="codigoUbicación"></param>
        /// <param name="numeroVivienda"></param>
        /// <param name="metraje"></param>
        /// <param name="tieneSalaComedor"></param>
        /// <param name="nroCuartos"></param>
        /// <param name="nroBanos"></param>
        /// <returns></returns>
        public Vivienda CrearVivienda(int codigoTipoVivienda, int codigoUbicación,int numeroVivienda, decimal metraje, Boolean tieneSalaComedor, int nroCuartos, int nroBanos)
        {
            Vivienda viviendaACrear;
            try
            {
                TipoVivienda tipoViviendaExistente = TipoViviendaDAO.Obtener(codigoTipoVivienda);
                Ubicacion ubicacionExistente = UbicacionDAO.Obtener(codigoUbicación);

                // Valida si la vivienda existe
                if(ExisteVivienda(Utility.Tables.Action.Insertar, 0,codigoUbicación,numeroVivienda))
                    throw new Exception(string.Format("Ya existe una vivienda para la ubicación ingresada: {0}-{1}", ubicacionExistente.NombreUbicacion, numeroVivienda.ToString()));
                                       
                viviendaACrear = new Vivienda()
                {
                    TipoVivienda = tipoViviendaExistente,
                    Ubicacion = ubicacionExistente,
                    NumeroVivienda =  numeroVivienda,
                    Metraje = metraje,
                    TieneSalaComedor= tieneSalaComedor,
                    NroCuartos = nroCuartos,
                    NroBano = nroBanos,
                    Estado = Boolean.Parse(Utility.Tables.Estado.Activo),
                    
                };

            }
            catch
            {

                throw;
            }
            
            return ViviendaDAO.Crear(viviendaACrear);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <returns></returns>
        public Vivienda ObtenerVivienda(int codigoVivienda)
        {
            return ViviendaDAO.Obtener(codigoVivienda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="codigoTipoVivienda"></param>
        /// <param name="codigoUbicación"></param>
        /// <param name="numeroVivienda"></param>
        /// <param name="metraje"></param>
        /// <param name="tieneSalaComedor"></param>
        /// <param name="nroCuartos"></param>
        /// <param name="nroBanos"></param>
        /// <returns></returns>
        public Vivienda ModificarVivienda(int codigoVivienda, int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, Boolean tieneSalaComedor, int nroCuartos, int nroBanos)
        {
            Vivienda viviendaAModificar;
            try
            {
                TipoVivienda tipoViviendaExistente = TipoViviendaDAO.Obtener(codigoTipoVivienda);
                Ubicacion ubicacionExistente = UbicacionDAO.Obtener(codigoUbicación);

                // Valida si la vivienda existe
                if (ExisteVivienda(Utility.Tables.Action.Actualizar, codigoVivienda, codigoUbicación, numeroVivienda))
                    throw new Exception(string.Format("Ya existe una vivienda para la ubicación ingresada: {0}-{1}", ubicacionExistente.NombreUbicacion, numeroVivienda.ToString()));

                viviendaAModificar = new Vivienda()
                {
                    CodigoVivienda = codigoVivienda,
                    TipoVivienda = tipoViviendaExistente,
                    Ubicacion = ubicacionExistente,
                    NumeroVivienda = numeroVivienda,
                    Metraje = metraje,
                    TieneSalaComedor = tieneSalaComedor,
                    NroCuartos = nroCuartos,
                    NroBano = nroBanos,

                };

            }
            catch
            {

                throw;
            }

            return ViviendaDAO.Modificar(viviendaAModificar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        public void EliminarVivienda(int codigoVivienda)
        {
            //Vivienda viviendaExistente = ViviendaDAO.Obtener(codigoVivienda);
            //ViviendaDAO.Eliminar(viviendaExistente);
            try
            {
                Vivienda viviendaAEliminar = ObtenerVivienda(codigoVivienda);
                viviendaAEliminar.Estado = Boolean.Parse(Utility.Tables.Estado.Inactivo);
                viviendaDAO.Modificar(viviendaAEliminar);

            }
            catch
            {
                throw;
            }
            

            
        }

        public List<Vivienda> ListarViviendas()
        {
            return ViviendaDAO.ListarTodos().ToList();
        }

        public decimal ObtenerCostoDeVivienda(int codigoVivienda, DateTime fechaContrato)
        {
            throw new NotImplementedException();
        }

        #region Validaciones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action">I: Insertar; U: Actualiza</param>
        /// <param name="codigoVivienda"></param>
        /// <param name="codigoUbicacion"></param>
        /// <param name="numeroVivienda"></param>
        /// <returns></returns>
        private bool ExisteVivienda(string action, int codigoVivienda, int codigoUbicacion, int numeroVivienda)
        {
            List<Vivienda> lstVivienda = new List<Vivienda>();
            lstVivienda = ListarViviendas();

            return lstVivienda.Any(r => (action == Utility.Tables.Action.Insertar && r.Ubicacion.CodigoUbicacion == codigoUbicacion && r.NumeroVivienda == numeroVivienda)
                                       || (action == Utility.Tables.Action.Actualizar && r.CodigoVivienda != codigoVivienda && r.Ubicacion.CodigoUbicacion == codigoUbicacion && r.NumeroVivienda == numeroVivienda));
        }
        #endregion


    }
}
