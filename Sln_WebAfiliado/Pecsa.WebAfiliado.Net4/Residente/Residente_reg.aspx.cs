using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pecsa.WebAfiliado.Net4;
using IU.WebCondominios.Net4.Util;
using IU.WebCondominios.Net4.Entidad;

namespace IU.WebCondominios.Net4.Residentes 
{
    public partial class Residente_reg : System.Web.UI.Page
    {

        Pecsa.WebAfiliado.Net4.ResidenteWS.ResidenteServiceClient proxy = new Pecsa.WebAfiliado.Net4.ResidenteWS.ResidenteServiceClient();
        Pecsa.WebAfiliado.Net4.ResidenteWS.Residente resultResidente = new Pecsa.WebAfiliado.Net4.ResidenteWS.Residente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                
                if (!Validator.IsNull(Session["Residente"]))
                {
                    Residente objRes = (Residente)Session["Residente"];
                    hddCodigoResidente.Value = Convert.ToString(objRes.Codigo);
                    this.Editar();
                }
                else
                {
                    txtFechaRegistro.Text = DateTime.Now.ToShortDateString();
                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Grabar();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogMensaje", "mostrarMensaje('Exito al grabar');", true);
                //Response.Redirect("~/Residente/Residente_lst.aspx", true);
            }
            catch (Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogMensaje", "mostrarMensaje('" + ex.Message + "');", true);
            }
        }

        private void Editar()
        {
            Pecsa.WebAfiliado.Net4.ResidenteWS.Residente objResidente = proxy.ObtenerResidente(Convert.ToInt32(hddCodigoResidente.Value));
            if (objResidente != null)
            {
                txtCodigo.Text = Validator.Cstr(objResidente.Codigo);
                txtNombres.Text = Validator.Cstr(objResidente.Nombres);
                txtApellidoM.Text = Validator.Cstr(objResidente.ApellidoMaterno);
                txtApellidoP.Text = Validator.Cstr(objResidente.ApellidoPaterno);
                txtCelular.Text = Validator.Cstr(objResidente.Celular);
                txtTelefono.Text = Validator.Cstr(objResidente.Telefono);
                ddlTipoDocumento.Text = Validator.Cstr(objResidente.TipoDocumento)=="01"?"DNI":"C.E.";
                txtNroDoc.Text = Validator.Cstr(objResidente.NroDocumento);
                chkEstado.Checked = Validator.CBool(objResidente.Estado);
                txtCorreo.Text = Validator.Cstr(objResidente.Correo);
                txtFechaRegistro.Text = DateTime.Now.ToShortDateString();//objResidente.FechaCreacion.ToShortDateString();
                txtFechaNac.Text = objResidente.FechaNacimiento.ToShortDateString();
                ddlSexo.Text = Validator.Cstr(objResidente.Sexo) == "Femenino" ? "F":"M";

            }


        }

        private void Grabar() 
        {
            
            Pecsa.WebAfiliado.Net4.ResidenteWS.Residente objResidente = new Pecsa.WebAfiliado.Net4.ResidenteWS.Residente()
            {
                TipoDocumento = ddlTipoDocumento.SelectedValue=="DNI"? "01": "02",
                NroDocumento = txtNroDoc.Text,
                Nombres = txtNombres.Text,
                ApellidoMaterno = txtApellidoM.Text,
                ApellidoPaterno = txtApellidoP.Text,
                Estado = (chkEstado.Checked?"1":"0"),
                FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text),
                FechaModificacion = DateTime.Now,
                FechaCreacion = Convert.ToDateTime(txtFechaRegistro.Text),
                Correo = txtCorreo.Text,
                Celular = txtCelular.Text,
                Telefono = txtTelefono.Text,
                Sexo = (ddlSexo.SelectedValue == "Femenino" ? "F":"M")
            };

            if (Validator.IsEmpty(hddCodigoResidente.Value))
            {
                resultResidente = proxy.CrearResidente(objResidente);
    
            }
            else
            {
                resultResidente = proxy.ModificarResidente(objResidente);                
            }
            
            txtCodigo.Text = resultResidente.Codigo.ToString();
            //LimpiarControles();
        
        }

        private void LimpiarControles() 
        {
            Session["Residente"] = null;
            //txtCodigo.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            ddlTipoDocumento.Text = "DNI";
            txtNroDoc.Text = string.Empty;
            chkEstado.Checked = true;
            txtCorreo.Text = string.Empty;
            txtFechaRegistro.Text = DateTime.Now.ToShortDateString();//objResidente.FechaCreacion.ToShortDateString();
            txtFechaNac.Text = string.Empty;
            ddlSexo.Text = "F" ;
        
        }

    }
}