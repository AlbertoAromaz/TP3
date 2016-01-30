using IU.WebCondominios.Net4.Entidad;
using IU.WebCondominios.Net4.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pecsa.WebAfiliado.Net4.Residentes
{
    public partial class Residente_lst : System.Web.UI.Page
    {
        ResidenteWS.ResidenteServiceClient proxyResidente = new ResidenteWS.ResidenteServiceClient();
        ResidenteWS.Residente[] lstResidente = null;
        List<Residente> lstRes = new List<Residente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                lstResidente =  proxyResidente.listarResidentes();
                if (lstResidente != null)
                {
                    foreach (var obj in lstResidente)
                    {
                        lstRes.Add(new Residente
                                    {
                                        Codigo = obj.Codigo,
                                        Nombres = obj.Nombres + " " + obj.ApellidoPaterno + " " + obj.ApellidoMaterno,
                                        TipoDocumento = (obj.TipoDocumento== "01"? "DNI" : "C.E"),
                                        NroDocumento = obj.NroDocumento,
                                        Telefono = obj.Telefono,
                                        Celular = obj.Celular,
                                        Correo = obj.Correo
                                    });
                    }
                }
               
                grdListaResidentes.DataSource = lstRes;
                grdListaResidentes.DataBind();
            } 
        }

        protected void grdListaResidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int index = gvr.RowIndex;
                if (grdListaResidentes.DataKeys[index] != null)
                {
                    int codigo = Validator.CInt32(grdListaResidentes.DataKeys[index]["Codigo"]);
                    if (e.CommandName == "Editar" || e.CommandName == "Ver")
                    {
                        Session["Residente"] = new Residente() { Codigo = codigo };
                        Response.Redirect("~/Residente/Residente_reg.aspx", true);
                        
                    }
                }
            }
        }

    }
}