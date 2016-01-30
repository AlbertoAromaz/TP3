using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CondominioService.MasterTables.Dominio;
namespace CondominioService.MasterTables.Persistencia
{
    public class ViviendaDAO:BaseDAO<Vivienda, int>
    {
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
            //Vivienda objVivienda;


            //MySqlConnection mysqlConnection = new MySqlConnection(ConexionUtil.ObtenerCadena);
            //MySqlCommand mysqlCommand;
            //MySqlDataReader mysqlDataReader;

            //mysqlConnection.Open();
            //try
            //{
            //    //mysqlCommand = mysqlConnection.CreateCommand();
            //    mysqlCommand = new MySqlCommand("SP_VIVIENDA_BUSCAR", mysqlConnection);
            //   // mysqlCommand.CommandText = "SP_VIVIENDA_BUSCAR";
            //    mysqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //    mysqlCommand.Parameters.AddWithValue("@codigoTipoVivienda", codigoTipoVivienda);
            //    mysqlCommand.Parameters.AddWithValue("@codigoUbicacion", codigoUbicacion);
            //    mysqlCommand.Parameters.AddWithValue("@numeroVivienda", numeroVivienda);

            //    mysqlDataReader = mysqlCommand.ExecuteReader();
            //    while (mysqlDataReader.Read())
            //    {
            //        objVivienda = new Vivienda();
            //        objVivienda.TipoVivienda = new TipoVivienda();
            //        objVivienda.Ubicacion = new Ubicacion();
            //        AddViviendaToList(objVivienda, mysqlDataReader);
            //        lstVivienda.Add(objVivienda);

            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            return lstVivienda;
        }

        public List<Vivienda> ListarVivienda()
        {
            List<Vivienda> lstVivienda = new List<Vivienda>();
            //Vivienda objVivienda;


            //MySqlConnection mysqlConnection = new MySqlConnection(ConexionUtil.ObtenerCadena);
            //MySqlCommand mysqlCommand;
            //MySqlDataReader mysqlDataReader;

            //mysqlConnection.Open();
            //try
            //{
            //    //mysqlCommand = mysqlConnection.CreateCommand();
            //    //mysqlCommand.CommandText = "SP_VIVIENDA_LISTAR";
            //    mysqlCommand = new MySqlCommand("SP_VIVIENDA_LISTAR", mysqlConnection);
            //    mysqlCommand.CommandType = System.Data.CommandType.StoredProcedure;


            //    mysqlDataReader = mysqlCommand.ExecuteReader();
            //    while (mysqlDataReader.Read())
            //    {
            //        objVivienda = new Vivienda();
            //        objVivienda.TipoVivienda = new TipoVivienda();
            //        objVivienda.Ubicacion = new Ubicacion();
            //        AddViviendaToList(objVivienda, mysqlDataReader);
            //        lstVivienda.Add(objVivienda);

            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            return lstVivienda;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objVivienda"></param>
        /// <param name="mysqlDataReader"></param>
        /// <returns></returns>
        internal Vivienda AddViviendaToList(Vivienda objVivienda,  MySqlDataReader mysqlDataReader)
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