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

        public Contrato ContratoGenerar(Contrato contratoACrear)
        {
            Contrato contratoCreado = null;
            //string sql = "INSERT INTO t_contrato VALUES (@codcontrato, @codvivienda, @codresidente, @fecccontrato, @fecirresidente, @costo, @periodo, @estado, @usercreador, @feccreacion, @usem, @fecm)";
            //using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
            //{
            //    con.Open();
            //    using (SqlCommand com = new SqlCommand(sql, con))
            //    {
            //        com.Parameters.Add(new SqlParameter("@codcontrato", contratoACrear.CodigoContrato));
            //        com.Parameters.Add(new SqlParameter("@codvivienda", contratoACrear.CodigoVivienda));
            //        com.Parameters.Add(new SqlParameter("@codresidente", contratoACrear.CodigoResidente));
            //        com.Parameters.Add(new SqlParameter("@fecccontrato", contratoACrear.FechaContrato.Date));
            //        com.Parameters.Add(new SqlParameter("@fecirresidente", contratoACrear.FechaIniResidencia));
            //        com.Parameters.Add(new SqlParameter("@costo", contratoACrear.CostoMensual));
            //        com.Parameters.Add(new SqlParameter("@periodo", contratoACrear.Periodo));
            //        com.Parameters.Add(new SqlParameter("@estado", contratoACrear.Estado));
            //        com.Parameters.Add(new SqlParameter("@usercreador", contratoACrear.UsuarioCreacion));
            //        com.Parameters.Add(new SqlParameter("@feccreacion", contratoACrear.FechaCreacion));
            //        com.Parameters.Add(new SqlParameter("@usem", contratoACrear.UsuarioModificacion));
            //        com.Parameters.Add(new SqlParameter("@fecm", contratoACrear.FechaModificacion));
            //        com.ExecuteNonQuery();
            //    }

            //}
            //contratoCreado = Obtener(contratoACrear.CodigoContrato);
            return contratoCreado;
        }

    public Contrato ObtenerContrato(int codigocontrato)
    {
        Contrato contratoObtenido = null;

        string sql = "SELECT * FROM t_contrato WHERE codigocontrato=@codc";
        using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                com.Parameters.Add(new SqlParameter("codc", codigocontrato));
                using (SqlDataReader resultado = com.ExecuteReader())
                {
                    if (resultado.Read())
                    {
                        contratoObtenido = new Contrato()
                        {
                            CodigoContrato = (int)resultado["codigocontrato"],
                            CodigoVivienda = (int)resultado["codigovivienda"],
                            CodigoResidente = (int)resultado["codigoresidente"],
                            FechaContrato = (DateTime)resultado["fechacontrato"],
                            FechaIniResidencia = (DateTime)resultado["fechainiresidencia"],
                            CostoMensual = (decimal)resultado["costomensual"],
                            Periodo = (int)resultado["periodo"] ,
                            Estado = (string)resultado["estado"],
                            UsuarioCreacion = (string)resultado["usuariocreacion"],
                            FechaCreacion = (DateTime)resultado["fechacreacion"],
                            UsuarioModificacion = (string)resultado["usuariomodificacion"],
                            FechaModificacion = (DateTime)resultado["fechamodificacion"]                           

                        };
                    }
 
                }
            }        
        }

        return contratoObtenido;
    }

    public Contrato ModificarContrato(Contrato contratoAModificar)
    {
        Contrato contratoModificado = null;
        string sql = "UPDATE t_contrato SET CostoMensual = @cos WHERE codigocontrato = @codc and codigovivienda = @codv and codigoresidente = @codr";
        using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena)) 
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                com.Parameters.Add(new SqlParameter("@codc", contratoAModificar.CodigoContrato));
                com.Parameters.Add(new SqlParameter("@codv", contratoAModificar.CodigoVivienda));
                com.Parameters.Add(new SqlParameter("@codr", contratoAModificar.CodigoResidente));
                com.Parameters.Add(new SqlParameter("@cos", contratoAModificar.CostoMensual));
                com.ExecuteNonQuery();
            }
        }
        contratoModificado = ObtenerContrato(contratoAModificar.CodigoContrato);
        return contratoModificado;
    }

    public void EliminarContrato(int codigocontrato)
    {
        string sql = "DELETE FROM t_contrato WHERE codigocontrato = @codc";
        using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                com.Parameters.Add(new SqlParameter("@codc", codigocontrato));
                com.ExecuteNonQuery();
            }
        }
    }

    public List<Contrato> ListarContrato()
    {
        List<Contrato> contrato = new List<Contrato>();
        string sql = "SELECT * FROM t_contrato";
        using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                using (SqlDataReader resultado = com.ExecuteReader())
                {
                    if (resultado.HasRows)
                    {
                        while (resultado.Read())
                        {
                            contrato.Add(new Contrato()
                            {
                                CodigoContrato = (int)resultado["codigocontrato"],
                                CodigoVivienda = (int)resultado["codigovivienda"],
                                CodigoResidente = (int)resultado["codigoresidente"],
                                FechaContrato = (DateTime)resultado["fechacontrato"],
                                FechaIniResidencia = (DateTime)resultado["fechainiresidencia"],
                                CostoMensual = (decimal)resultado["costomensual"],
                                Periodo = (int)resultado["periodo"],
                                Estado = (string)resultado["estado"],
                                UsuarioCreacion = (string)resultado["usuariocreacion"],
                                FechaCreacion = (DateTime)resultado["fechacreacion"],
                                UsuarioModificacion = (string)resultado["usuariomodificacion"],
                                FechaModificacion =  (DateTime)resultado["fechamodificacion"]
                            });
                        }
                    }
                }
                return contrato; 
            }
        }
    }

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