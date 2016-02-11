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
    public Contrato GenerarContrato(Contrato contratoAgenerar)
        {
            Contrato contratoGenerado = null;
            //string sql = "INSERT INTO t_contrato VALUES (@codc, @codv, @codr, @fecc, @fecir, @cos, @per, @est, @usec, @feccr, @usem, @fecm)";
            string sql = "INSERT INTO t_contrato VALUES (@codv, @codr, @fecc, @cos, @per)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena)) 
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    //com.Parameters.Add(new SqlParameter("@codc", contratoAgenerar.CodigoContrato));
                    com.Parameters.Add(new SqlParameter("@codv", contratoAgenerar.CodigoVivienda));
                    com.Parameters.Add(new SqlParameter("@codr", contratoAgenerar.CodigoResidente));
                    com.Parameters.Add(new SqlParameter("@fecc", contratoAgenerar.FechaContrato.Date));
                    //com.Parameters.Add(new SqlParameter("@fecir", contratoAgenerar.FechaIniResidencia));
                    com.Parameters.Add(new SqlParameter("@cos", contratoAgenerar.CostoMensual));
                    com.Parameters.Add(new SqlParameter("@per",contratoAgenerar.Periodo));
                    //com.Parameters.Add(new SqlParameter("@est", contratoAgenerar.Estado));
                    //com.Parameters.Add(new SqlParameter("@usec",contratoAgenerar.UsuarioCreacion));
                    //com.Parameters.Add(new SqlParameter("@feccr", contratoAgenerar.FechaCreacion));
                    //com.Parameters.Add(new SqlParameter("@usem", contratoAgenerar.UsuarioModificacion));
                    //com.Parameters.Add(new SqlParameter("@fecm", contratoAgenerar.FechaModificacion));
                    com.ExecuteNonQuery();  
                }
 
            }
            contratoGenerado = ObtenerContrato(contratoAgenerar.CodigoContrato);
            return contratoGenerado;       
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
                            //FechaIniResidencia = (DateTime)resultado["fechainiresidencia"],
                            CostoMensual = (decimal)resultado["costomensual"],
                            Periodo = (int)resultado["periodo"] //,
                            //Estado = (string)resultado["estado"],
                            //UsuarioCreacion = (string)resultado["usuariocreacion"],
                            //FechaCreacion = (DateTime)resultado["fechacreacion"],
                            //UsuarioModificacion = (string)resultado["usuariomodificacion"],
                            //FechaModificacion = (DateTime)resultado["fechamodificacion"]                           

                        };
                    }
 
                }
            }        
        }

        return contratoObtenido;
    }
    public Contrato ModificarContrato(Contrato ContratoAModificar)
    {
        Contrato contratoModificado = null;
        string sql = "UPDATE t_contrato SET CostoMensual = @cos WHERE codigocontrato = @codc";
        using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena)) 
        {
            con.Open();
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                com.Parameters.Add(new SqlParameter("@codc", contratoModificado.CodigoContrato));
                com.Parameters.Add(new SqlParameter("@cos",contratoModificado.CostoMensual));
                com.ExecuteNonQuery();
            }
        }
        contratoModificado = ObtenerContrato(ContratoAModificar.CodigoContrato);
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
                                FechaModificacion = (DateTime)resultado["fechamodificacion"]
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