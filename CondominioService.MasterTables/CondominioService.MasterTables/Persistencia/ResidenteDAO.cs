using CondominioService.MasterTables.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CondominioService.MasterTables.Persistencia
{
    public class ResidenteDAO : BaseDAO<Residente , int>
    {

        public List<Residente> ListarResidente(string nombres , string nroDocumento)
        {
            List<Residente> lstResidente = new List<Residente>();
            Residente objResidente;
            SqlDataReader rd;

            try
            {

                string sql = "SP_RESIDENTE_LISTAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@NroDoc", SqlDbType.VarChar)).Value = nroDocumento;
                        cmd.Parameters.Add(new SqlParameter("@Nombres", SqlDbType.VarChar)).Value = nombres;                
                        
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            objResidente = new Residente();
                            AddResidenteToList(objResidente, rd);
                            lstResidente.Add(objResidente);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return lstResidente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objResidente"></param>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        internal Residente AddResidenteToList(Residente objResidente, SqlDataReader sqlDataReader)
        {
            objResidente.Codigo = Convert.ToInt32(sqlDataReader["Codigo"]);
            objResidente.TipoDocumento = sqlDataReader["TipoDoc"].ToString();
            objResidente.NroDocumento = sqlDataReader["NroDoc"].ToString();
            objResidente.Nombres = sqlDataReader["Nombres"].ToString();
            objResidente.Sexo = sqlDataReader["Sexo"].ToString();
            objResidente.FechaNacimiento = Convert.ToDateTime(sqlDataReader["Fecha_Nacimiento"]);
            objResidente.Telefono = (sqlDataReader["Telefono"].ToString());
            objResidente.Celular =(sqlDataReader["Celular"].ToString());
            objResidente.Correo = (sqlDataReader["Correo"].ToString());
          
            
            return objResidente;

        }
    }
}