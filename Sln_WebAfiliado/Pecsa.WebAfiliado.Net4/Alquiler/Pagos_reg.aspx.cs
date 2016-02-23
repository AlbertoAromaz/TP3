using IU.WebCondominios.Net4.Entidad;
using Pecsa.WebAfiliado.Net4.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RN = Pecsa.WebAfiliado.Net4;

namespace IU.WebCondominios.Net4
{
    public partial class Pagos_reg : System.Web.UI.Page
    {
        #region Variables
        // Servicio Residente
        RN.ResidenteWS.ResidenteServiceClient proxyResidente = new RN.ResidenteWS.ResidenteServiceClient();      
       
        // servicio Vivienda
        RN.ViviendaWS.ViviendaServiceClient proxyVivienda = new RN.ViviendaWS.ViviendaServiceClient();

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarCombos();

            }
        }
  

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Buscar la lista de Cuotas
            ConsultarCuotas( Convert.ToInt32(ddlUbicacion.SelectedValue) , Convert.ToInt32(ddlResidente.SelectedValue));
        }
        protected void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            // Recorrer la lista de Cuotas
            string codigoContrato ;
            string codigoCuota ;
            decimal saldoImporte = 0.0m;
            foreach (GridViewRow item in grdListaCuotas.Rows)
            {
                codigoContrato = string.Empty;
                codigoCuota  = string.Empty;
                CheckBox Check = item.FindControl("chkElegir") as CheckBox;
                if (Check.Checked)
                {
                    codigoContrato = Convert.ToString(grdListaCuotas.DataKeys[item.RowIndex]["CodigoContrato"]);
                    codigoCuota = Convert.ToString(grdListaCuotas.DataKeys[item.RowIndex]["CodigoCuota"]);

                    // LLamar al metodo grabar
                    saldoImporte += Convert.ToDecimal(grdListaCuotas.DataKeys[item.RowIndex]["Importe"]);
                }
            }

            // Volver a listar las Cuotas
            ConsultarCuotas( 0, 0);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('Pagos efectuados correctamente!');", true);
        }

        #endregion

        #region Methods
        private void cargarCombos()
        {
            // llenar Tipo Vivienda
            List<RN.ViviendaWS.Vivienda> lstViviendas = new List<RN.ViviendaWS.Vivienda>();
            List<Vivienda> objLst = new List<Vivienda>();

            lstViviendas = proxyVivienda.ListarViviendas().ToList();

            foreach (var item in lstViviendas)
            {
                objLst.Add(new Vivienda()
                {
                    CodigoVivienda = item.CodigoVivienda,
                    UbicacionComp = item.Ubicacion.NombreUbicacion + " - " + item.NumeroVivienda,               
                });
            }

            ddlUbicacion.DataTextField = "UbicacionComp";
            ddlUbicacion.DataValueField = "CodigoVivienda";
            ddlUbicacion.DataSource = objLst;
            ddlUbicacion.DataBind();

            // llenar Clientes
            List<RN.ResidenteWS.Residente> lstResidentes = new List<RN.ResidenteWS.Residente>();           
            lstResidentes = proxyResidente.listarResidentes().ToList();
            List<Residente> objLstRes = new List<Residente>();

            foreach (var item in lstResidentes)
            {
                objLstRes.Add(new Residente()
                {
                    Codigo = item.Codigo,
                    Nombres = item.ApellidoPaterno + " " + item.ApellidoMaterno + " " + item.Nombres 
                });
            }
            ddlResidente.DataTextField = "Nombres";
            ddlResidente.DataValueField = "Codigo";
            ddlResidente.DataSource = objLstRes;
            ddlResidente.DataBind();
        }

        private void ConsultarCuotas(int codVivienda , int codResidente) 
        { 
            
        }
        #endregion

      
    }

  
}