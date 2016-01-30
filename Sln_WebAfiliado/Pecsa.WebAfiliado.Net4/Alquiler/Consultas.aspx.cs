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
                    ItemGrid = "1",
                    Ubicacion = "Zona A",
                    Numero = "104",
                    Residente = "Jose Perez Ramos",
                    Concepto = "Alquiler Cuota",
                    FechaAdeudo = "30/01/2016",
                    Moneda = "Soles",
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
        public string ItemGrid {get; set;}
        public string Ubicacion { get; set; }
        public string Numero { get; set; }
        public string Residente { get; set; }
        public string Concepto { get; set; }
        public string FechaAdeudo { get; set; }
        public string Moneda { get; set; }
        public string Importe { get; set; }  
    
    }
}