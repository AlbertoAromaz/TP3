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
        #region Variables
        private ViviendaWS.ViviendaServiceClient proxyVivienda = new ViviendaWS.ViviendaServiceClient();
        private TipoViviendaWS.TipoViviendaServiceClient proxyTipoVivienda = new TipoViviendaWS.TipoViviendaServiceClient();
        private UbicacionWS.UbicacionServiceClient proxyUbicacion = new UbicacionWS.UbicacionServiceClient();
        #endregion

        #region Form Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarVivienda();
                LLenarCombos();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            GrabarVivienda();
        }
        #endregion

        #region private methods
        private void GrabarVivienda()
        {
            try
            {
                int codigoVivienda = int.Parse(txtCodigoVivienda.Text);
                int codigoTipoVivienda = int.Parse(ddlTipoVivienda.SelectedValue);
                int codigoUbicacion = int.Parse(ddlUbicacion.SelectedValue);
                int numeroVivienda = int.Parse(txtNúmeroVivienda.Text);
                decimal metraje = decimal.Parse(txtMetraje.Text);
                Boolean tieneSalaComedor = chkSalaComedor.Checked;
                int nroCuartos = int.Parse(txtNroCuartos.Text);
                int nroBanos = int.Parse(txtNroBanos.Text);

                if(codigoVivienda.Equals(0))
                    proxyVivienda.CrearVivienda(codigoTipoVivienda,codigoUbicacion,numeroVivienda,metraje,tieneSalaComedor,nroCuartos,nroBanos);
                else
                    proxyVivienda.ModificarVivienda(codigoTipoVivienda,codigoTipoVivienda, codigoUbicacion, numeroVivienda, metraje, tieneSalaComedor, nroCuartos, nroBanos);

                Response.Redirect("Vivienda_lst.aspx");
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", string.Format("mostraMensaje('{0}');",ex.Message), true);
            }
        
        }
        #endregion

        private void MostrarVivienda()
        {
            string getRequestQueryStringVivienda = "";
            getRequestQueryStringVivienda = Request.QueryString["CODIGO_VIVIENDA"];
            if (getRequestQueryStringVivienda != string.Empty)
            {
                ViviendaWS.Vivienda viviendaResultado = new ViviendaWS.Vivienda();
                viviendaResultado = proxyVivienda.ObtenerVivienda(int.Parse(getRequestQueryStringVivienda));
                txtCodigoVivienda.Text = viviendaResultado.CodigoVivienda.ToString();
                ddlTipoVivienda.SelectedValue = viviendaResultado.TipoVivienda.CodigoTipoVivienda.ToString();
                ddlUbicacion.SelectedValue = viviendaResultado.Ubicacion.CodigoUbicacion.ToString();
                txtNúmeroVivienda.Text = viviendaResultado.NumeroVivienda.ToString();
                txtMetraje.Text = viviendaResultado.Metraje.ToString();
                chkSalaComedor.Checked = viviendaResultado.TieneSalaComedor;
                chkEstado.Checked = viviendaResultado.Estado;
                txtNroCuartos.Text = viviendaResultado.NroCuartos.ToString();
                txtNroBanos.Text = viviendaResultado.NroBano.ToString();
            }
        
        }

        private void LLenarCombos()
        { 
           // llenar Tipo Vivienda
            List<TipoViviendaWS.TipoVivienda> lstTipoVivienda = new List<TipoViviendaWS.TipoVivienda>();
            lstTipoVivienda = proxyTipoVivienda.ListarTipoVivienda().ToList();
            ddlTipoVivienda.DataTextField = "NombreTipoVivienda";
            ddlTipoVivienda.DataValueField = "CodigoTipoVivienda";
            ddlTipoVivienda.DataSource = lstTipoVivienda;
            ddlTipoVivienda.DataBind();

            // llenar ubicación
            List<UbicacionWS.Ubicacion> lstUbicacion = new List<UbicacionWS.Ubicacion>();
            lstUbicacion = proxyUbicacion.ListarUbicacion().ToList();
            ddlTipoVivienda.DataTextField = "NombreUbicacion";
            ddlTipoVivienda.DataValueField = "CodigoUbicacion";
            ddlTipoVivienda.DataSource = lstUbicacion;
            ddlTipoVivienda.DataBind();


        }
    }
}