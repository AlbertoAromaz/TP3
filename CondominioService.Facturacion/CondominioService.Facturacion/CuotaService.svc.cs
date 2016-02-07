using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CondominioService.Facturacion.Dominio;
using CondominioService.Facturacion.Persistencia;

namespace CondominioService.Facturacion
{
    
    public class CuotaService : ICuotaService
    {

        #region properties
        private CuotaDAO cuotaDAO = null;
        private CuotaDAO CuotaDAO
        {
            get
            {
                if (cuotaDAO == null)
                    cuotaDAO = new CuotaDAO();
                return cuotaDAO;
            }
        }




        #endregion

        public Dominio.Cuota GenerarCuotas(Dominio.Cuota cuotaACrear)
        {
            throw new NotImplementedException();
        }

        public Dominio.Cuota ObtenerCuota(string codigoCuota)
        {
            throw new NotImplementedException();
        }

        public Dominio.Cuota RegistrarPago(Dominio.Cuota cuotaAModificar)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Cuota> BuscarPagos()
        {
            throw new NotImplementedException();
        }
    }
}
