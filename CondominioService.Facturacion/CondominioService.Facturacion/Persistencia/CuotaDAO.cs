<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CondominioService.Facturacion.Dominio;

namespace CondominioService.Facturacion.Persistencia
{
    public class CuotaDAO:BaseDAO<Cuota, int>
    {
    }
=======
﻿using System;
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
                    com.ExecuteNonQuery();
                }
            }
            LstCuota = BuscarCuota(codigoContrato, 0, 0);
            return LstCuota;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="codigoVivienda"></param>
        /// <param name="codigoResidente"></param>
        /// <returns></returns>
        public List<Cuota> BuscarCuota(int codigoContrato, int codigoResidente,int codigoVivienda)
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
            objCuota.FechaVencimiento = DateTime.Parse(mysqlDataReader["FechaVencimiento"].ToString());
            if (mysqlDataReader["FechaPago"]!=null)
                objCuota.FechaPago = DateTime.Parse(mysqlDataReader["FechaPago"].ToString());
            objCuota.Estado_Cuota = mysqlDataReader["Estado_Cuota"].ToString();
            objCuota.Estado = Boolean.Parse(mysqlDataReader["Estado"].ToString());
            objCuota.UsuarioCreacion = mysqlDataReader["UsuarioCreacion"].ToString();
            objCuota.UsuarioModificacion = mysqlDataReader["UsuarioModificacion"].ToString();
            objCuota.CodigoResidente = int.Parse(mysqlDataReader["CodigoResidente"].ToString());
            objCuota.NombreCompletoResidente = mysqlDataReader["Residente"].ToString();
            objCuota.CodigoVivienda = int.Parse(mysqlDataReader["CodigoVivienda"].ToString());
            objCuota.NombreCompletoVivienda = mysqlDataReader["Vivienda"].ToString();
                        

            return objCuota;

        }

    }
>>>>>>> 52d0721f85254feaa743de4d58f4acfc0492816f
}