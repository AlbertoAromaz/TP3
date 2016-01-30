using IU.WebCondominios.Net4.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IU.WebCondominios.Net4
{
    public partial class Alquiler_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarResidente_Click(object sender, EventArgs e)
        {
            List<Residente> lstRes = new List<Residente>();
            Residente objR = new Residente()
            {
                ItemGrid = "1",
                TipoDoc = "DNI",
                NroDocumento = "70517084",
                Telefono = "44444",
                Celular = "999222122",
                Nombres = "Juan Perez Ramos",
                Correo = "Juan@gmail.com"
            };

            lstRes.Add(objR);


            grdListaResidentes.DataSource = lstRes;
            grdListaResidentes.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogMensajeResidente", "openAsociarResidente();", true);
        }

        public class Residente
        {
            public string ItemGrid { get; set; }
            public string TipoDoc { get; set; }
            public string NroDocumento { get; set; }
            public string Telefono { get; set; }
            public string Celular { get; set; }
            public string Nombres { get; set; }
            public string Correo { get; set; }

        }

        protected void grdListaResidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = gvr.RowIndex;
            if (grdListaResidentes.DataKeys != null)
            {

                string codigo = Validator.Cstr(grdListaResidentes.DataKeys[index]["ItemGrid"]);
                string nombre = Validator.Cstr(grdListaResidentes.DataKeys[index]["Nombres"]);
               
                if (e.CommandName == "SelectCC")
                {
                    hddCodigo.Value = codigo;
                    txtResidente.Text = nombre;

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogcc", "successResidente();", true);
                }
            }
        }
    }
}