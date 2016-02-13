<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominioService.Facturacion.Dominio
{
    [DataContract]
    public class Cuota
    {
        [DataMember]
        public int CodigoCuota { get; set; }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominioService.Facturacion.Dominio
{
    [DataContract]
    public class Cuota
    {
        [DataMember]
        public int CodigoCuota { get; set; }

        [DataMember]
        public int NumSequencial { get; set; }

        [DataMember]
        public int CodigoContrato { get; set; }

        [DataMember]
        public DateTime FechaVencimiento { get; set; }

        [DataMember]
        public DateTime? FechaPago { get; set; }

        [DataMember]
        public string Estado_Cuota { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public string UsuarioCreacion { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public string UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        [DataMember]
        public int CodigoResidente { get; set; }

        [DataMember]
        public string NombreCompletoResidente { get; set; }

        [DataMember]
        public int CodigoVivienda { get; set; }

        [DataMember]
        public string NombreCompletoVivienda { get; set; }

    }
>>>>>>> 52d0721f85254feaa743de4d58f4acfc0492816f
}