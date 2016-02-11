using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominioService.MasterTables.Dominio
{
    [DataContract]
    public class Residente
    {
        [DataMember]
        public int Codigo {get;set;}
        [DataMember]
        public string TipoDocumento {get;set;}
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public string Nombres {get;set;}
        [DataMember]
        public string ApellidoPaterno {get;set;}
        [DataMember]
        public string ApellidoMaterno {get;set;}
        [DataMember]
        public string Sexo {get;set;}
        [DataMember]
        public DateTime FechaNacimiento {get ;set;}
        [DataMember]
        public string Telefono {get ;set;}
        [DataMember]
        public string Celular {get ;set;}
        [DataMember]
        public string Correo {get ;set;}
        [DataMember]
        public string Estado {get ;set;}
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