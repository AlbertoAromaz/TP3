using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominioService.ContratoAquiler.Dominio
{
    [DataContract]
    public class Cuota
    {
        [DataMember(IsRequired = false)]
        public int CodigoCuota { get; set; }

        [DataMember(IsRequired = false)]
        public int NumSequencial { get; set; }

        [DataMember]
        public int CodigoContrato { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime FechaVencimiento { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime? FechaPago { get; set; }

        [DataMember(IsRequired = false)]
        public string Estado_Cuota { get; set; }

        [DataMember(IsRequired = false)]
        public Boolean Estado { get; set; }

        [DataMember(IsRequired = false)]
        public string UsuarioCreacion { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime FechaCreacion { get; set; }

        [DataMember(IsRequired = false)]
        public string UsuarioModificacion { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime FechaModificacion { get; set; }

        [DataMember(IsRequired = false)]
        public int CodigoResidente { get; set; }

        [DataMember(IsRequired = false)]
        public string NombreCompletoResidente { get; set; }

        [DataMember(IsRequired = false)]
        public int CodigoVivienda { get; set; }

        [DataMember(IsRequired = false)]
        public string NombreCompletoVivienda { get; set; }

        [DataMember(IsRequired = false)]
        public string Resultado { get; set; }

        [DataMember(IsRequired = false)]
        public decimal Monto { get; set; }
    }
}