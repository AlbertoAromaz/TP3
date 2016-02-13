using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CondominioService.ContratoAquiler.Dominio;
using System.Data;

namespace CondominioService.ContratoAquiler.Persistencia
{
    public class ContratoDAO
    {

        public Contrato ContratoGenerar(Contrato contratoACrear)
        {
            Contrato contratoCreado = null;
            int codigo = 0;
            string sql = "SP_CONTRATO_INSERTAR"; // nombres de tu stored
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    com.Parameters.Add(new SqlParameter("@CodigoVivienda", contratoACrear.CodigoVivienda));
                    com.Parameters.Add(new SqlParameter("@CodigoResidente", contratoACrear.CodigoResidente));
                    com.Parameters.Add(new SqlParameter("@FechaContrato", Convert.ToDateTime(contratoACrear.FechaContrato)));
                    com.Parameters.Add(new SqlParameter("@FechaIniResidencia", Convert.ToDateTime(contratoACrear.FechaIniResidencia)));
                    com.Parameters.Add(new SqlParameter("@CostoMensual", Convert.ToDecimal(contratoACrear.CostoMensual)));
                    com.Parameters.Add(new SqlParameter("@Periodo", contratoACrear.Periodo));
                    com.Parameters.Add(new SqlParameter("@Estado", contratoACrear.Estado));
                    com.Parameters.Add(new SqlParameter("@UsuarioCreacion", contratoACrear.UsuarioCreacion));
                    com.Parameters.Add(new SqlParameter("@FechaCreacion", Convert.ToDateTime(contratoACrear.FechaCreacion)));

                    com.Parameters.Add(new SqlParameter("@CodigoContrato", SqlDbType.Int, 20)).Direction = ParameterDirection.Output;

                    com.ExecuteNonQuery();

                    codigo = Convert.ToInt32(com.Parameters["@CodigoContrato"].Value);
                }

            }
            contratoCreado = ObtenerContrato(codigo.ToString());
            return contratoCreado;
        }

        public Contrato ObtenerContrato(string codigocontrato)
        {
            Contrato contratoObtenido = null;

            string sql = "SELECT * FROM t_contrato WHERE codigocontrato=@CodigoContrato";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@CodigoContrato", codigocontrato));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            contratoObtenido = new Contrato()
                            {

                                CodigoContrato = Convert.ToInt32(resultado["CodigoContrato"]),
                                CodigoVivienda = Convert.ToInt32(resultado["CodigoVivienda"]),
                                CodigoResidente = Convert.ToInt32(resultado["CodigoResidente"]),
                                FechaContrato = Convert.ToString(resultado["FechaContrato"]),
                                FechaIniResidencia = Convert.ToString(resultado["FechaIniResidencia"]),
                                CostoMensual = Convert.ToString(resultado["CostoMensual"]),
                                Periodo = Convert.ToInt32(resultado["Periodo"]),
                                Estado = Convert.ToString(resultado["Estado"]),
                                UsuarioCreacion = Convert.ToString(resultado["UsuarioCreacion"]),
                                FechaCreacion = Convert.ToString(resultado["FechaCreacion"]),
                                UsuarioModificacion = Convert.ToString(resultado["usuariomodificacion"]),
                                FechaModificacion = Convert.ToString(resultado["fechamodificacion"])


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
            contratoModificado = ObtenerContrato(contratoAModificar.CodigoContrato.ToString());
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
                                    FechaContrato = resultado["fechacontrato"].ToString(),
                                    FechaIniResidencia = resultado["fechainiresidencia"].ToString(),
                                    CostoMensual = resultado["costomensual"].ToString(),
                                    Periodo = (int)resultado["periodo"],
                                    Estado = resultado["estado"].ToString()
                                    //UsuarioCreacion = (string)resultado["usuariocreacion"],
                                    //FechaCreacion = (string)resultado["fechacreacion"],
                                    //UsuarioModificacion = (string)resultado["usuariomodificacion"],
                                    //FechaModificacion =  (string)resultado["fechamodificacion"]
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
                        costo = (decimal)com.ExecuteScalar();
                    }
                }
            }
            catch
            {
                throw;
            }

            return costo;

        }

        public Respuesta ValidarContrato(int codigoVivienda, int codigoResidente, DateTime fechaIniResidencia)
        {           
            Respuesta objRespuesta = new Respuesta();
            try
            {
                string sql = "SP_CONTRATO_VALIDACIONES";
                using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add(new SqlParameter("@codigoVivienda", codigoVivienda));
                        com.Parameters.Add(new SqlParameter("@CodigoResidente", codigoResidente));
                        com.Parameters.Add(new SqlParameter("@FechaIniResidencia", fechaIniResidencia));

                        SqlDataReader rd = com.ExecuteReader(CommandBehavior.CloseConnection);

                        if (rd.HasRows)
                        {
                            if (rd.Read())
                            {

                                objRespuesta = new Respuesta()
                                {
                                    ExisteVivienda = rd.GetInt32(rd.GetOrdinal("EXIST_VIVIENDA_DISPONIBLE")),
                                    ExisteMoroso = rd.GetInt32(rd.GetOrdinal("EXIST_RESIDENTE_MOROSO"))
                                };
                            }
                        }

                    }
                }
                return objRespuesta;
            }
            catch
            {
                throw;
            }
        }

    }
}