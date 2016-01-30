using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pecsa.WebAfiliado.Net4.Residentes
{
    public partial class Residente_reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                txtFechaRegistro.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Grabar();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void Grabar() 
        {
            
            ResidenteWS.ResidenteServiceClient proxy = new ResidenteWS.ResidenteServiceClient();
            ResidenteWS.Residente resultResidente = new ResidenteWS.Residente();

            ResidenteWS.Residente objResidente = new ResidenteWS.Residente()
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
                Correo = "liz@gmail.com",
                Celular = txtCelular.Text,
                Telefono = txtTelefono.Text,
                Sexo = (ddlSexo.SelectedValue == "Femenino" ? "F":"M")
            };

            resultResidente = proxy.CrearResidente(objResidente);

            txtCodigo.Text = resultResidente.Codigo.ToString();
        
        }

    }
}