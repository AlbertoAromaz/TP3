using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IU.WebCondominios.Net4
{
    public partial class Pagos_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Cuotas> lstCuotas = new List<Cuotas>();

                grdListaCuotas.DataSource = lstCuotas;
                grdListaCuotas.DataBind();

            }
        }

        protected void ddlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlFormaPago.SelectedItem.Text == "Efectivo")
            //{
            //    idCuenta.Visible = false;
            //}
            //else
            //{
            //    idCuenta.Visible = true;
            //}
        }
    }

    public class Cuotas
    {
        public string ItemGrid { get; set; }
        public string FechaPago { get; set; }
        public string Concepto { get; set; }
        public string Pagado { get; set; }
        public string Moneda { get; set; }
        public string Importe { get; set; }

    }
}