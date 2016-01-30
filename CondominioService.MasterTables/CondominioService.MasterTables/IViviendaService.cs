using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.MasterTables.Dominio;

namespace CondominioService.MasterTables
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IViviendaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IViviendaService
    {
        [OperationContract]
        Vivienda CrearVivienda(int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, Boolean tieneSalaComedor, int nroCuartos, int nroBanos);

        [OperationContract]
        Vivienda ObtenerVivienda(int codigoVivienda);

        [OperationContract]
        Vivienda ModificarVivienda(int codigoVivienda, int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, Boolean tieneSalaComedor, int nroCuartos, int nroBanos);

        [OperationContract]
        void EliminarVivienda(int codigoVivienda);

        [OperationContract]
        List<Vivienda> ListarViviendas();

        [OperationContract]
        List<Vivienda> BuscarVivienda(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda);

        [OperationContract]
        decimal ObtenerCostoDeVivienda(int codigoVivienda, DateTime fechaContrato);

    }
}
