using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CondominioService.MasterTables.Dominio
{
    [DataContract]
    public class Ubicacion
    {
        [DataMember]
        public int CodigoUbicacion { get; set; }

        [DataMember]
        public string NombreUbicacion { get; set; }
    }
}