using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.MasterTables.Dominio;

namespace CondominioService.MasterTables
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITipoVivienda" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITipoViviendaService
    {
        [OperationContract]
        List<TipoVivienda> ListarTipoVivienda();
    }
}
