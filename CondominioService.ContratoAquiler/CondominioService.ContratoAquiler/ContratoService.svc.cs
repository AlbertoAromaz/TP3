using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CondominioService.ContratoAquiler
{
    public class ContratoService : IContratoService
    {
        private ContratoDAO contratoDAO = new ContratoDAO();
        private ContratoDAO ContratoDAO
        {
            get
            {
                if (contratoDAO == null)
                  contratoDAO = new ContratoDAO();
                  return contratoDAO;                
            }

        }

        
        public Dominio.Contrato GenerarContrato(Dominio.Contrato contrato)
        {
            Contrato contratoACrear = new Contrato()
            {
                CodigoResidente = contrato.CodigoResidente,
                CodigoVivienda = contrato.CodigoVivienda,
                FechaContrato = contrato.FechaContrato,
                //FechaIniResidencia = contrato.FechaIniResidencia,
                CostoMensual = contrato.CostoMensual,
                Periodo = contrato.Periodo,
                //Estado = contrato.Estado,
                //UsuarioCreacion = contrato.UsuarioCreacion,
                //FechaCreacion = contrato.FechaCreacion,
                //UsuarioModificacion = contrato.UsuarioModificacion,
                //FechaModificacion = contrato.FechaModificacion

            };
            return ContratoDAO.Crear(contratoACrear);
        }


        public Dominio.Contrato Obtener(string codigocontrato)
        {
            return contratoDAO.ObtenerContrato(int.Parse(codigocontrato));
        }


        public Dominio.Contrato ModificarContrato(Dominio.Contrato contratoAModificar)
        {
            return contratoDAO.ModificarContrato(contratoAModificar);
        }

        public void EliminarContrato(string codigoContrato)
        {
            contratoDAO.EliminarContrato(int.Parse(codigoContrato));    

        }


        public List<Dominio.Contrato> ListarContratos()
        {
            return contratoDAO.ListarContrato();
        }

        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return contratoDAO.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }
    }
}
