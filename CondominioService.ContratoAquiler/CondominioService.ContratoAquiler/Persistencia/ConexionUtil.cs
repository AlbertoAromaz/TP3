using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominioService.ContratoAquiler.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena
        {
            get{
               return "Data Source=(local);Initial Catalog=DBCondominio;Integrated Security=SSPI;";
            }
        }
    }
}