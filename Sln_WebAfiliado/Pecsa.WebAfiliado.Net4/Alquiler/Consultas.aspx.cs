using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IU.WebCondominios.Net4.Util;
using R=Pecsa.WebAfiliado.Net4;
using Pecsa.WebAfiliado.Net4.Entidad;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace IU.WebCondominios.Net4
{
    public partial class Consultas : System.Web.UI.Page
    {
        private R.ViviendaWS.ViviendaServiceClient proxyVivienda = new R.ViviendaWS.ViviendaServiceClient();
        private R.ResidenteWS.ResidenteServiceClient proxyResidente = new R.ResidenteWS.ResidenteServiceClient();

        #region Form Methods

        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                //ddlResidente.SelectedIndex = -1;
                //ddlVivienda.SelectedIndex = -1;
                //ddlEstado.SelectedValue = "Seleccionar";
                sincronizarCuotas();
                LLenarCombos();
                BuscarCuotas("0", "0","TODOS","0","0");
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigoVivienda = (ddlVivienda.SelectedValue == string.Empty) ? 0 : int.Parse(ddlVivienda.SelectedValue);
            int codigoResidente = (ddlResidente.SelectedValue == string.Empty) ? 0 : int.Parse(ddlResidente.SelectedValue);
            string estadoCuota = (ddlEstado.SelectedValue.Equals("Seleccionar")) ? "0" : ddlEstado.SelectedValue;
            string fecIni = (txtFecIni.Text.Equals(string.Empty)) ? "0" : txtFecIni.Text;
            string fecFin = (txtFecFin.Text.Equals(string.Empty)) ? "0" : txtFecFin.Text;

            BuscarCuotas(codigoVivienda.ToString(), codigoResidente.ToString(), estadoCuota, fecIni, fecFin);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


       

        #endregion

        #region Private Methods
        private void LLenarCombos()
        {
            // llenar Vivienda
            List<R.ViviendaWS.Vivienda> lstVivienda = new List<R.ViviendaWS.Vivienda>();
            lstVivienda = proxyVivienda.ListarViviendas().ToList();
            ddlVivienda.DataTextField = "NombreVivienda";
            ddlVivienda.DataValueField = "CodigoVivienda";
            ddlVivienda.DataSource = lstVivienda;
            ddlVivienda.DataBind();

            // llenar residente
            List<R.ResidenteWS.Residente> lstResidente = new List<R.ResidenteWS.Residente>();
            lstResidente= proxyResidente.listarResidentes().ToList();
            ddlResidente.DataTextField = "Nombres";
            ddlResidente.DataValueField = "Codigo";
            ddlResidente.DataSource = lstResidente;
            ddlResidente.DataBind();


        }

        private void Limpiar()
        {
            ddlResidente.SelectedIndex = -1;
            ddlVivienda.SelectedIndex = -1;
            ddlEstado.SelectedValue = "Seleccionar";
            

            BuscarCuotas("0", "0","TODOS","0","0");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoVivienda"></param>
        /// <param name="codigoResidente"></param>
        /// <param name="estadoCuota"></param>
        /// <param name="fecIni"></param>
        /// <param name="fecFin"></param>
        private void BuscarCuotas(string codigoVivienda, string codigoResidente, string estadoCuota, string fecIni, string fecFin)
        { 
            List<Cuota> lstCuota = new List<Cuota>();

            string uriBuscarCuotas = string.Format("http://localhost:7141/CuotaService.svc/CuotaService/{0},{1},{2},{3},{4},{5}", 0, codigoResidente, codigoVivienda, estadoCuota, fecIni, fecFin);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create(uriBuscarCuotas);
            req.Method = "GET";

             HttpWebResponse res = (HttpWebResponse)req.GetResponse();
             StreamReader reader = new StreamReader(res.GetResponseStream());
             string cuotaJson = reader.ReadToEnd();
             JavaScriptSerializer js = new JavaScriptSerializer();

             lstCuota = js.Deserialize<List<Cuota>>(cuotaJson);


            PintarGrid(lstCuota);
        }

        private void PintarGrid(List<Cuota> lstCuota)
        {
            grdListaCuotasxCobrar.DataSource = lstCuota;
            grdListaCuotasxCobrar.DataBind();
        }


        private void sincronizarCuotas()
        {
            string uriListarCuotas = String.Format("http://localhost:7141/CuotaService.svc/CuotaService");
            HttpWebRequest reqListarCuotas = (HttpWebRequest)WebRequest
           .Create(uriListarCuotas);
            reqListarCuotas.Method = "GET";
            reqListarCuotas.GetResponse();
        }
        #endregion


    }

}