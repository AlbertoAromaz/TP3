using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominioService.MasterTables.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena
        {
            get{
                return "Data Source=LP-EDELACRUZ\\SQLEXPRESS;Initial Catalog=DBCondominio; User ID=sa;Password=123456";
            }
        }
    }
}