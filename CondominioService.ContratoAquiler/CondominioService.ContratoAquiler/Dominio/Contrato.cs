using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominioService.ContratoAquiler.Dominio
{
    [DataContract]
    public class Contrato
    {
        [DataMember(IsRequired = false)]
        public int CodigoContrato { get; set; }

        [DataMember(IsRequired = false)]
        public int CodigoVivienda { get; set; }

        [DataMember(IsRequired = false)]
        public int CodigoResidente { get; set; }

        [DataMember(IsRequired = false)]
        public string FechaContrato { get; set; }

        [DataMember(IsRequired = false)]
        public string FechaIniResidencia { get; set; }

        [DataMember(IsRequired = false)]
        public string CostoMensual { get; set; }

        [DataMember(IsRequired = false)]
        public int Periodo { get; set; }

        [DataMember(IsRequired = false)]
        public string Estado { get; set; }

        [DataMember(IsRequired = false)]
        public string UsuarioCreacion { get; set; }

        [DataMember(IsRequired = false)]
        public string FechaCreacion { get; set; }

        [DataMember(IsRequired = false)]
        public string UsuarioModificacion { get; set; }

        [DataMember(IsRequired = false)]
        public string FechaModificacion { get; set; }

    }
}