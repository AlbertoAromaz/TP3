using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominioService.MasterTables.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=LP-EDELACRUZ\\SQLEXPRESS;Initial Catalog=DBCondominio;Integrated Security=SSPI;";
        }
    }
}