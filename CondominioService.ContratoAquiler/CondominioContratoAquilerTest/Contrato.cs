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
        public decimal CostoMensual { get; set; }
        public string Estado { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaIniResidencia { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Periodo { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }


}
