using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pecsa.WebAfiliado.Net4.Entidad
{
    public class Vivienda
    {
        public int CodigoVivienda { get; set; }

        public string UbicacionComp { get; set; }
               
        public string NumeroVivienda { get; set; }

        public string tipoVivienda { get; set; }

        public decimal Metraje { get; set; }

        public string Caracteristicas { get; set; }

    }
}