using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IU.WebCondominios.Net4.Entidad
{
    public class Residente
    {
        public int Codigo { get; set; }

        public string TipoDocumento { get; set; }

        public string NroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Correo { get; set; }

        public string Estado { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}