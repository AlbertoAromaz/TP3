using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pecsa.WebAfiliado.Net4.Vivienda
{
    public partial class Vivienda_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            //if (txtCodigo.Text == string.Empty) 
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", "mostrarMensaje('Debe Ingresar los datos');", true);
            //}

            Response.Redirect("Vivienda_lst.aspx");
        }
    }
}