using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioFacturacionTest
{
   public  class Cuota
    {
        
        public int CodigoCuota { get; set; }

        
        public int NumSequencial { get; set; }

        
        public int CodigoContrato { get; set; }

        
        public DateTime FechaVencimiento { get; set; }

        
        public DateTime? FechaPago { get; set; }

        
        public string Estado_Cuota { get; set; }

        
        public Boolean Estado { get; set; }

        
        public string UsuarioCreacion { get; set; }

        
        public DateTime FechaCreacion { get; set; }

        
        public string UsuarioModificacion { get; set; }

        
        public DateTime FechaModificacion { get; set; }

        
        public int CodigoResidente { get; set; }

        
        public string NombreCompletoResidente { get; set; }

        public int CodigoVivienda { get; set; }

        public string NombreCompletoVivienda { get; set; }
    }
}
