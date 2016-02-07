using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            RemoverSession();
            Response.Redirect("~/Vivienda/Vivienda_lst.aspx", true);
        }
        #endregion

        #region private methods
        private void GrabarVivienda()
        {
            try
            {
                RemoverSession();

                int codigoVivienda = (txtCodigoVivienda.Text==string.Empty)?0: int.Parse(txtCodigoVivienda.Text);
                int codigoTipoVivienda = int.Parse(ddlTipoVivienda.SelectedValue);
                int codigoUbicacion = int.Parse(ddlUbicacion.SelectedValue);
                int numeroVivienda = (txtNúmeroVivienda.Text == string.Empty) ? 0 : int.Parse(txtNúmeroVivienda.Text);
                decimal metraje = (txtMetraje.Text == string.Empty) ? 0 : decimal.Parse(txtMetraje.Text);
                Boolean tieneSalaComedor = chkSalaComedor.Checked;
                int nroCuartos = (txtNroCuartos.Text == string.Empty) ? 0 : int.Parse(txtNroCuartos.Text);
                int nroBanos = (txtNroBanos.Text == string.Empty) ? 0 : int.Parse(txtNroBanos.Text);

                if(codigoVivienda.Equals(0))
                    proxyVivienda.CrearVivienda(codigoTipoVivienda,codigoUbicacion,numeroVivienda,metraje,tieneSalaComedor,nroCuartos,nroBanos);
                else
                    proxyVivienda.ModificarVivienda(codigoTipoVivienda,codigoTipoVivienda, codigoUbicacion, numeroVivienda, metraje, tieneSalaComedor, nroCuartos, nroBanos);

                Response.Redirect("~/Vivienda/Vivienda_lst.aspx", true);
            }
            catch(FaultException<ViviendaWS.RepetidoException> fe)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", string.Format("mostrarMensaje('{0}');", fe.Detail.Mensaje), true);
            }
        
        }

        private void MostrarVivienda()
        {
            string getSessionVivienda = string.Empty;
            getSessionVivienda = (Session["CODIGO_VIVIENDA"]!=null)? Session["CODIGO_VIVIENDA"].ToString(): string.Empty;
            if (getSessionVivienda != string.Empty)
            {
                ViviendaWS.Vivienda viviendaResultado = new ViviendaWS.Vivienda();
                viviendaResultado = proxyVivienda.ObtenerVivienda(int.Parse(getSessionVivienda));
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
            ddlUbicacion.DataTextField = "NombreUbicacion";
            ddlUbicacion.DataValueField = "CodigoUbicacion";
            ddlUbicacion.DataSource = lstUbicacion;
            ddlUbicacion.DataBind();


        }

        private bool Validar(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda, decimal metraje)
        {

            if (codigoTipoVivienda == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", string.Format("mostraMensaje('{0}');", "Debe seleccionar el Tipo de Vivienda"), true);
                return false;
            }

            if (codigoUbicacion == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", string.Format("mostraMensaje('{0}');", "Debe seleccionar la Ubicación"), true);
                return false;
            }

            if (metraje == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogPrecioSucces", string.Format("mostraMensaje('{0}');", "Ingrese un metraje de vivienda válido"), true);
                return false;
            }


            return true;

        }
        private void RemoverSession()
        {
            if (Session["CODIGO_VIVIENDA"] != null)
                Session["CODIGO_VIVIENDA"] = null;
        }
        #endregion

       
    
    
    }
}