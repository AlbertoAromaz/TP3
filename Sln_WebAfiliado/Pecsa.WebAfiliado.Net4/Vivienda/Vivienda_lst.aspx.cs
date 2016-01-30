using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pecsa.WebAfiliado.Net4.Vivienda
{
    public partial class Vivienda_lst : System.Web.UI.Page
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
                LLenarCombos();
                BuscarViviendas(0, 0, 0);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarViviendas(int.Parse(ddlTipoVivienda.SelectedValue), int.Parse(ddlUbicacion.SelectedValue), int.Parse(txtNúmeroVivienda.Text));
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        protected void grdListaVivienda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            { 
               // e.CommandArgument()
            }
        }

        #endregion

        #region Private Methods

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

        private void BuscarViviendas(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda)
        {
            List<ViviendaWS.Vivienda> lstVivienda = new List<ViviendaWS.Vivienda>();
            //lstVivienda = proxyVivienda.BuscarVivienda(codigoTipoVivienda, codigoUbicacion, numeroVivienda).ToList();
            lstVivienda = proxyVivienda.ListarViviendas().Where(r => ((r.TipoVivienda.CodigoTipoVivienda == codigoTipoVivienda || codigoTipoVivienda == 0)
                                                                          || (r.Ubicacion.CodigoUbicacion == codigoUbicacion || codigoUbicacion == 0)
                                                                          || (r.NumeroVivienda == numeroVivienda || numeroVivienda == 0))).ToList();

            PintarGrid(lstVivienda);

        }

        private void PintarGrid(List<ViviendaWS.Vivienda> lstVivienda)
        {
            grdListaVivienda.DataSource = lstVivienda;
            grdListaVivienda.DataBind();
        }

        private void Limpiar()
        {
            ddlTipoVivienda.SelectedIndex = -1;
            ddlUbicacion.SelectedIndex = -1;
            txtNúmeroVivienda.Text = string.Empty;

            BuscarViviendas(0, 0, 0);

        }


        #endregion


    }
    
}