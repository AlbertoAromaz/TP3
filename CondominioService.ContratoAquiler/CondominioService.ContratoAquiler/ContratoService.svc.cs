using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;
using System.Net;
using System.ServiceModel.Web;

namespace CondominioService.ContratoAquiler
{
    public class ContratoService : IContratoService
    {
        private ContratoDAO ContratoDAO = new ContratoDAO();
        public Dominio.Contrato GenerarContrato(Dominio.Contrato ContratoACrear)
        {
            Contrato ContratoExiste = ContratoDAO.ObtenerContrato(ContratoACrear.CodigoContrato);
            if (ContratoExiste != null)  // si es nulo no existe
            {
                throw new WebFaultException<string>(
                    "no se pudo", HttpStatusCode.InternalServerError);
            }

            return ContratoDAO.Crear(ContratoACrear);
        }

        public Dominio.Contrato Obtener(string codigocontrato)
        {
            return ContratoDAO.ObtenerContrato(int.Parse(codigocontrato));
        }
        public Dominio.Contrato ModificarContrato(Dominio.Contrato contratoAModificar)
        {
            throw new NotImplementedException();
        }

        public void EliminarContrato(string codigoContrato)
        {
            ContratoDAO.ObtenerContrato(int.Parse(codigoContrato));    

        }

        public List<Dominio.Contrato> ListarContratos()
        {
            return ContratoDAO.ListarContrato();
        }

        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return ContratoDAO.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }
    }
}
