using IU.WebCondominios.Net4.Entidad;
using Pecsa.WebAfiliado.Net4.Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
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
                List<Cuota> lst = new List<Cuota>();
                grdListaCuotas.DataSource = lst;
                grdListaCuotas.DataBind();
            }
        }
  

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Buscar la lista de Cuotas
            ConsultarCuotas( Convert.ToInt32(ddlUbicacion.SelectedValue) , Convert.ToInt32(ddlResidente.SelectedValue));
        }

        protected void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                // Recorrer la lista de Cuotas
                string codigoContrato;
                string codigoCuota;
                decimal saldoImporte = 0.0m;
                foreach (GridViewRow item in grdListaCuotas.Rows)
                {
                    codigoContrato = string.Empty;
                    codigoCuota = string.Empty;
                    CheckBox Check = item.FindControl("chkElegir") as CheckBox;
                    if (Check.Checked)
                    {
                        codigoContrato = Convert.ToString(grdListaCuotas.DataKeys[item.RowIndex]["CodigoContrato"]);
                        codigoCuota = Convert.ToString(grdListaCuotas.DataKeys[item.RowIndex]["CodigoCuota"]);

                        // LLamar al metodo grabar
                        //saldoImporte += Convert.ToDecimal(grdListaCuotas.DataKeys[item.RowIndex]["Monto"]);

                        string postdata = "{\"CodigoCuota\":\"" + codigoCuota + "\"}"; //JSON
                        byte[] data = Encoding.UTF8.GetBytes(postdata);
                        HttpWebRequest req = (HttpWebRequest)WebRequest
                        .Create("http://localhost:7141/CuotaService.svc/CuotaService");
                        req.Method = "PUT";
                        req.ContentLength = data.Length;
                        req.ContentType = "application/json";
                        var reqStream = req.GetRequestStream();
                        reqStream.Write(data, 0, data.Length);
                        HttpWebResponse res = null;

                        Cuota objCuota = new Cuota();

                        try
                        {
                            res = (HttpWebResponse)req.GetResponse();
                            StreamReader reader = new StreamReader(res.GetResponseStream());
                            string cuotaJson = reader.ReadToEnd();
                            JavaScriptSerializer js = new JavaScriptSerializer();

                            objCuota = js.Deserialize<Cuota>(cuotaJson);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                //txtTotalAPagar.Text = saldoImporte.ToString();
                // Volver a listar las Cuotas              

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('Pagos efectuados correctamente!');", true);
                ConsultarCuotas(0, Convert.ToInt32(ddlResidente.SelectedValue));
                txtTotalAPagar.Text = "0.0";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('Error al registrar los pagos!');", true);
            }
        }

        //protected void grdListaCuotas_DataBound(object sender, EventArgs e)
        //{
        //    decimal saldoImporte = 0.0m;
        //    foreach (GridViewRow item in grdListaCuotas.Rows)
        //    {
                   
        //        CheckBox Check = item.FindControl("chkElegir") as CheckBox;
        //        if (Check.Checked)
        //        {
        //            saldoImporte += Convert.ToDecimal(grdListaCuotas.DataKeys[item.RowIndex]["Monto"]);
        //        }
        //    }
        //    txtTotalAPagar.Text = saldoImporte.ToString();
        //    updateSaldo.Update();
        //}
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
            string uriBuscarCuotas = string.Format("http://localhost:7141/CuotaService.svc/CuotaService/{0},{1},{2},{3},{4},{5}", 0, codResidente, 0, 0, 0, 0);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create(uriBuscarCuotas);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string cuotaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            List<Cuota> lstCuotas = js.Deserialize<List<Cuota>>(cuotaJson);

            grdListaCuotas.DataSource = lstCuotas.ToList();
            grdListaCuotas.DataBind();
           
        }
        #endregion

        protected void chkElegir_CheckedChanged(object sender, EventArgs e)
        {
            Double suma = 0.0;
            foreach (GridViewRow item in grdListaCuotas.Rows)
            {
                CheckBox Check = item.FindControl("chkElegir") as CheckBox;
                if (Check.Checked)
                {
                    Double precio = Convert.ToDouble(grdListaCuotas.DataKeys[item.RowIndex]["Monto"]);
                    suma = suma + precio;

                }
            }

            txtTotalAPagar.Text = suma.ToString();
        }
       

      
    }

  
}