using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CondominioService.Facturacion.Dominio;

namespace CondominioService.Facturacion.Persistencia
{
    public class CuotaDAO:BaseDAO<Cuota, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        public List<Cuota>GenerarCuotas(int codigoContrato)
        {
            List<Cuota> LstCuota = new List<Cuota>();
            string sql = "SP_CUOTAS_GENERAR";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@CodigoContrato", codigoContrato));
                    com.ExecuteNonQuery();
                }
            }
            LstCuota = BuscarCuota(codigoContrato, 0, 0, "0", "0", "0");
            return LstCuota;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoResidente"></param>
        /// <param name="codigoVivienda"></param>
        /// <param name="estadoCuota"></param>
        /// <param name="fecIni"></param>
        /// <param name="fecFin"></param>
        /// <returns></returns>
        public List<Cuota> BuscarCuota(int codigoContrato, int codigoResidente, int codigoVivienda, string estadoCuota, string fecIni, string fecFin)
        {
            List<Cuota> LstCuota = new List<Cuota>();
            Cuota objCuota;
            SqlDataReader rd;

            try
            {
                string sql = "SP_CUOTAS_BUSCAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@CodigoContrato", codigoContrato));
                        com.Parameters.Add(new SqlParameter("@CodigoResidente", codigoResidente));
                        com.Parameters.Add(new SqlParameter("@CodigoVivienda", codigoVivienda));
                        com.Parameters.Add(new SqlParameter("@Estado_Cuota", estadoCuota));
                        com.Parameters.Add(new SqlParameter("@FechaIni", fecIni));
                        com.Parameters.Add(new SqlParameter("@FechaFin", fecFin));
                        rd = com.ExecuteReader();
                        while (rd.Read())
                        {
                            objCuota = new Cuota();
                            AddCuotaToList(objCuota, rd);
                            LstCuota.Add(objCuota);
                        }
                    }
                }

            }
            catch
            {
                throw;            
            }
            
            return LstCuota;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cuota> ListarCuotas()
        {
            List<Cuota> LstCuota = new List<Cuota>();
            Cuota objCuota;
            SqlDataReader rd;

            try
            {
                string sql = "SP_CUOTAS_LISTAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        rd = com.ExecuteReader();
                        while (rd.Read())
                        {
                            objCuota = new Cuota();
                            AddCuotaToList(objCuota, rd);
                            LstCuota.Add(objCuota);
                        }
                    }
                }

            }
            catch
            {
                throw;
            }

            return LstCuota;
        }

        internal Cuota AddCuotaToList(Cuota objCuota, SqlDataReader mysqlDataReader)
        {
            objCuota.CodigoCuota = int.Parse(mysqlDataReader["CodigoCuota"].ToString());
            objCuota.NumSequencial = int.Parse(mysqlDataReader["NumSequencial"].ToString());
            objCuota.CodigoContrato=int.Parse(mysqlDataReader["CodigoContrato"].ToString());
            objCuota.Monto = decimal.Parse(mysqlDataReader["CostoMensual"].ToString());
            objCuota.FechaVencimiento = DateTime.Parse(mysqlDataReader["FechaVencimiento"].ToString());
            if ((mysqlDataReader["FechaPago"])!=DBNull.Value)
                objCuota.FechaPago = DateTime.Parse(mysqlDataReader["FechaPago"].ToString());
            objCuota.Estado_Cuota = mysqlDataReader["Estado_Cuota"].ToString();
            objCuota.Estado = (mysqlDataReader["Estado"].ToString()=="1")?true:false; 
            objCuota.UsuarioCreacion = mysqlDataReader["UsuarioCreacion"].ToString();
            objCuota.UsuarioModificacion = mysqlDataReader["UsuarioModificacion"].ToString();
            objCuota.CodigoResidente = int.Parse(mysqlDataReader["CodigoResidente"].ToString());
            objCuota.NombreCompletoResidente = mysqlDataReader["Residente"].ToString();
            objCuota.CodigoVivienda = int.Parse(mysqlDataReader["CodigoVivienda"].ToString());
            objCuota.NombreCompletoVivienda = mysqlDataReader["Vivienda"].ToString();
                        

            return objCuota;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoCuota"></param>
        /// <returns></returns>
        public Cuota ActualizarPagoDeCuotas(Cuota pagoDeCuotaAActualizar)
        {
            Cuota PagoDeCuotaActualizado = new Cuota();
            try
            {

                string sql = "SP_CUOTAS_ACTUALIZAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@codigoCuota", pagoDeCuotaAActualizar.CodigoCuota));
                        com.ExecuteNonQuery();

                        PagoDeCuotaActualizado = Obtener(pagoDeCuotaAActualizar.CodigoCuota);
                        PagoDeCuotaActualizado.Resultado = "OK";
                    }
                }
            }
            catch
            {
                PagoDeCuotaActualizado.Resultado = "ERROR";
            }

            return PagoDeCuotaActualizado;
            

        }
    }
}