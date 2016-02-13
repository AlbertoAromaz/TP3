using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioContratoAquilerTest
{
    public class Contrato
    {
        public int CodigoContrato { get; set; }
        public int CodigoResidente { get; set; }
        public int CodigoVivienda { get; set; }
        public string CostoMensual { get; set; }
        public string Estado { get; set; }
        public string FechaContrato { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaIniResidencia { get; set; }
        public string FechaModificacion { get; set; }
        public int Periodo { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }


}
