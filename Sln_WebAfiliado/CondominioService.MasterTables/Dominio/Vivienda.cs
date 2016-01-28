using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CondominioService.MasterTables.Dominio
{
    [DataContract]
    public class Vivienda
    {
        [DataMember]
        public int CodigoVivienda { get; set; }

        [DataMember]
        public TipoVivienda TipoVivienda { get; set; }

        [DataMember]
        public Ubicacion Ubicacion { get; set; }

        [DataMember]
        public int NumeroVivienda { get; set; }

        [DataMember]
        public decimal Metraje { get; set; }

        [DataMember]
        public Boolean TieneSalaComedor { get; set; }

        [DataMember]
        public int NroCuartos { get; set; }

        [DataMember]
        public int NroBano { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public string Message { get; set; }


    }
}