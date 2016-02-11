using CondominioService.MasterTables.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CondominioService.MasterTables
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResidenteService" in both code and config file together.
    [ServiceContract]
    public interface IResidenteService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Residente CrearResidente(Residente residente);
        [OperationContract]
        Residente ObtenerResidente(int codigo);
        [OperationContract]
        Residente ModificarResidente(Residente residente);
        [OperationContract]
        void EliminarResidente(int codigo);
        [OperationContract]
        List<Residente> listarResidentes();
    }
}
