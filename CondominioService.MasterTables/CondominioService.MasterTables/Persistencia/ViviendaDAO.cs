using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CondominioService.MasterTables.Dominio;
namespace CondominioService.MasterTables.Persistencia
{
    public class ViviendaDAO:BaseDAO<Vivienda, int>
    {


        public Vivienda Modificar(Vivienda objViviendaAModificar)
        {
            Vivienda viviendaModificado = null;
            string sql = "SP_VIVIENDA_ACTUALIZAR";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@codigoVivienda", objViviendaAModificar.CodigoVivienda));
                    com.Parameters.Add(new SqlParameter("@codigoTipoVivienda", objViviendaAModificar.TipoVivienda.CodigoTipoVivienda));
                    com.Parameters.Add(new SqlParameter("@codigoUbicacion", objViviendaAModificar.Ubicacion.CodigoUbicacion));
                    com.Parameters.Add(new SqlParameter("@numeroVivienda", objViviendaAModificar.NumeroVivienda));
                    com.Parameters.Add(new SqlParameter("@metraje", objViviendaAModificar.Metraje));
                    com.Parameters.Add(new SqlParameter("@tieneSalaComedor", objViviendaAModificar.TieneSalaComedor));
                    com.Parameters.Add(new SqlParameter("@nroCuartos", objViviendaAModificar.NroCuartos));
                    com.Parameters.Add(new SqlParameter("@nroBano", objViviendaAModificar.NroBano));
                    com.Parameters.Add(new SqlParameter("@estado", objViviendaAModificar.Estado));
                    com.Parameters.Add(new SqlParameter("@usuarioModificacion", objViviendaAModificar.UsuarioModificacion));
                    com.Parameters.Add(new SqlParameter("@fechaModificacion", objViviendaAModificar.FechaModificacion));
                    com.ExecuteNonQuery();
                }
            }
            viviendaModificado = Obtener(objViviendaAModificar.CodigoVivienda);
            return viviendaModificado;
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoTipoVivienda"></param>
        /// <param name="codigoUbicacion"></param>
        /// <param name="numeroVivienda"></param>
        /// <returns></returns>
        public List<Vivienda> BuscarVivienda(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda)
        {
            List<Vivienda> lstVivienda = new List<Vivienda>();
            Vivienda objVivienda;
            SqlDataReader rd;

            try
            {

                string sql = "SP_VIVIENDA_BUSCAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@codigoTipoVivienda", codigoTipoVivienda));
                        com.Parameters.Add(new SqlParameter("@codigoUbicacion", codigoUbicacion));
                        com.Parameters.Add(new SqlParameter("@numeroVivienda", numeroVivienda));
                        rd = com.ExecuteReader();
                        while (rd.Read())
                        {
                            objVivienda = new Vivienda();
                            objVivienda.TipoVivienda = new TipoVivienda();
                            objVivienda.Ubicacion = new Ubicacion();
                            AddViviendaToList(objVivienda, rd);
                            lstVivienda.Add(objVivienda);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }


           
            return lstVivienda;
        }

        public List<Vivienda> ListarVivienda()
        {
            List<Vivienda> lstVivienda = new List<Vivienda>();
            Vivienda objVivienda;
            SqlDataReader rd;

            try
            {

                string sql = "SP_VIVIENDA_LISTAR";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        rd = com.ExecuteReader();
                        while (rd.Read())
                        {
                            objVivienda = new Vivienda();
                            objVivienda.TipoVivienda = new TipoVivienda();
                            objVivienda.Ubicacion = new Ubicacion();
                            AddViviendaToList(objVivienda, rd);
                            lstVivienda.Add(objVivienda);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return lstVivienda;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objVivienda"></param>
        /// <param name="mysqlDataReader"></param>
        /// <returns></returns>
        internal Vivienda AddViviendaToList(Vivienda objVivienda,  SqlDataReader mysqlDataReader)
        {
            objVivienda.CodigoVivienda = int.Parse(mysqlDataReader["CodigoVivienda"].ToString());
            objVivienda.TipoVivienda.CodigoTipoVivienda = int.Parse(mysqlDataReader["CodigoTipoVivienda"].ToString());
            objVivienda.TipoVivienda.NombreTipoVivienda = mysqlDataReader["NombreTipoVivienda"].ToString();
            objVivienda.Ubicacion.CodigoUbicacion = int.Parse(mysqlDataReader["CodigoUbicacion"].ToString());
            objVivienda.Ubicacion.NombreUbicacion = mysqlDataReader["NombreUbicacion"].ToString();
            objVivienda.NumeroVivienda = int.Parse(mysqlDataReader["NumeroVivienda"].ToString());
            objVivienda.Metraje = decimal.Parse(mysqlDataReader["Metraje"].ToString());
            objVivienda.TieneSalaComedor = Boolean.Parse(mysqlDataReader["TieneSalaComedor"].ToString());
            objVivienda.NroCuartos = int.Parse(mysqlDataReader["NroCuartos"].ToString());
            objVivienda.NroBano = int.Parse(mysqlDataReader["NroBano"].ToString());
            objVivienda.NombreVivienda = string.Format("{0} - {1}", objVivienda.Ubicacion.NombreUbicacion, objVivienda.NumeroVivienda);
            objVivienda.Estado = Boolean.Parse(mysqlDataReader["Estado"].ToString());
            objVivienda.UsuarioCreacion = mysqlDataReader["UsuarioCreacion"].ToString();
            objVivienda.UsuarioModificacion = mysqlDataReader["UsuarioModificacion"].ToString();

            return objVivienda;
        
        }

    }
}