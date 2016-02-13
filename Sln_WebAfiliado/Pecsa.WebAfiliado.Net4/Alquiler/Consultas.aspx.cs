using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IU.WebCondominios.Net4
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                List<CuotasxCobrar> lstCuotasxCobrar = new List<CuotasxCobrar>();
                CuotasxCobrar obj = new CuotasxCobrar 
                {
                    NroCuota = "1",
                    Vivienda = "Zona A - 104",
                    Residente = "Jose Perez Ramos",
                    FechaPago = "30/01/2016",
                    FechaVencimiento = "30/01/2016",
                    Estado = "Cancelado",
                    Importe = "1,200.00"
                
                };
                lstCuotasxCobrar.Add(obj);
                grdListaCuotasxCobrar.DataSource = lstCuotasxCobrar;
                grdListaCuotasxCobrar.DataBind();
            
            }
        }
    }

    public class CuotasxCobrar
    {
        public string NroCuota { get; set; }
        public string Vivienda { get; set; }
        public string Residente { get; set; }
        public string Importe { get; set; }
        public string Estado { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaPago { get; set; }
        
    
    }
}