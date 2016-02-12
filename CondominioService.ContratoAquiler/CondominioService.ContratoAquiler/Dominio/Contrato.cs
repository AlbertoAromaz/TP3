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
        [DataMember]
        public int CodigoContrato { get; set; }

        [DataMember]
        public int CodigoVivienda { get; set; }

        [DataMember]
        public int CodigoResidente { get; set; }

        [DataMember]
        public DateTime FechaContrato { get; set; }

        [DataMember]
        public DateTime FechaIniResidencia { get; set; }

        [DataMember]
        public decimal CostoMensual { get; set; }

        [DataMember]
        public int Periodo { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string UsuarioCreacion { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public string UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }     
  
    }
}