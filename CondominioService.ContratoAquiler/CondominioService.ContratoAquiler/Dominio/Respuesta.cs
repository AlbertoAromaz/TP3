using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominioService.ContratoAquiler.Dominio
{
    public class Respuesta
    {
        public int ExisteVivienda { get; set; }
        public int ExisteMoroso { get; set; }
    }
}