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
        private ContratoDAO dao = new ContratoDAO();

        private Contrato CrearContrato(Contrato contratoACrear)
        {
            //Contrato ContratoExiste = dao.Obtener(contratoACrear.CodigoContrato);

            //if (ContratoExiste != null)
            //{
            //    throw new WebFaultException<string>(
            //        "Contrato imposible", HttpStatusCode.InternalServerError);
            //}
            return dao.ContratoGenerar(contratoACrear);
        }


        public Contrato Obtener(string codigocontrato)
        {
            return dao.ObtenerContrato(int.Parse(codigocontrato));
        }


        public Contrato ModificarContrato(Contrato contratoAModificar)
        {
            return dao.ModificarContrato(contratoAModificar);
        }

        public void EliminarContrato(string codigoContrato)
        {
            dao.EliminarContrato(int.Parse(codigoContrato));    
        }


        public List<Contrato> ListarContratos()
        {
            return dao.ListarContrato();
        }

        public decimal ObtenerCostoAquilerMensual(string codigoVivienda, string fechaContrato)
        {
            return dao.ObtenerCostoAquilerMensual(int.Parse(codigoVivienda), DateTime.Parse(fechaContrato));
        }


    }
}
