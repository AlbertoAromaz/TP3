using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.ContratoAquiler.Dominio;
using CondominioService.ContratoAquiler.Persistencia;

namespace CondominioService.ContratoAquiler
{
    public class ContratoService : IContratoService
    {
        #region properties
        private ContratoDAO contratoDAO = null;
        private ContratoDAO ContratoDAO
        {
            get
            {
                if (contratoDAO == null)
                    contratoDAO = new ContratoDAO();
                return contratoDAO;
            }
        }            
        #endregion

        public Dominio.Contrato GenerarContrato(Dominio.Contrato ContratoACrear)
        {
            // Generar Contrato 
            Contrato ContratoExiste = contratoDAO.ObtenerContrato(ContratoACrear.CodigoContrato);
            // Generar Cuotas            
            return contratoDAO.Crear(ContratoACrear);
        }
        public Dominio.Contrato Obtener(string codigocontrato)
        {
            return contratoDAO.ObtenerContrato(int.Parse(codigocontrato));
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
