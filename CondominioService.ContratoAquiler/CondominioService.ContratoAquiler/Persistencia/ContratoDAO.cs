using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CondominioService.ContratoAquiler.Dominio;

namespace CondominioService.ContratoAquiler.Persistencia
{
    public class ContratoDAO:BaseDAO<Contrato, int>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratoAgenerar"></param>
        /// <returns></returns>
        public Contrato GenerarContrato(Contrato contratoAgenerar)
        {

            Contrato contratoGenerado = null;
            // crear contrato


            return contratoGenerado;
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="fechaContrato"></param>
        /// <returns></returns>
        public decimal ObtenerCostoAquilerMensual(int codigoVivienda, DateTime fechaContrato)
        {
            decimal costo = 0;
            try
            {
                string sql = "SP_COSTOXVIVIENDA_OBTENER_COSTO_MENSUAL";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@codigoVivienda", codigoVivienda));
                        com.Parameters.Add(new SqlParameter("@fechaContrato", fechaContrato));
                        costo= (decimal)com.ExecuteScalar();
                    }
                }
            }
            catch 
            {
                throw;
            }

            return costo;
        
        }
    }
}