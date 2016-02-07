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
        public DateTime FechaContrato { get; set; }

       
    }
}