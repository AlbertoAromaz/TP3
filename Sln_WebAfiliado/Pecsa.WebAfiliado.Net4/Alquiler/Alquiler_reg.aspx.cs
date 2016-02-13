using IU.WebCondominios.Net4.Entidad;
using IU.WebCondominios.Net4.Util;
using Pecsa.WebAfiliado.Net4.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Alquiler_reg : System.Web.UI.Page
    {
        #region Variables
        // Servicio Residente
        RN.ResidenteWS.ResidenteServiceClient proxyResidente = new RN.ResidenteWS.ResidenteServiceClient();
        RN.ResidenteWS.Residente[] lstResidente = null;
        List<Residente> lstRes = new List<Residente>();
        // servicio Vivienda
        RN.ViviendaWS.ViviendaServiceClient proxyVivienda = new RN.ViviendaWS.ViviendaServiceClient();
        
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) 
            {
                Session["ListaVivienda"] = null;
                cargarCombos();
                ddlUbicacion_SelectedIndexChanged(null, null);
            }
        }

        protected void btnBuscarResidente_Click(object sender, EventArgs e)
        {
            cargarGrilla();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogMensajeResidente", "openAsociarResidente();", true);
        }


        protected void grdListaResidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = gvr.RowIndex;
            if (grdListaResidentes.DataKeys != null)
            {

                string codigo = Validator.Cstr(grdListaResidentes.DataKeys[index]["Codigo"]);
                string nombre = Validator.Cstr(grdListaResidentes.DataKeys[index]["Nombres"]);
               
                if (e.CommandName == "SelectCC")
                {
                    hddCodigoResidente.Value = codigo;
                    txtResidente.Text = nombre;
                    UpdatePanel1.Update();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dialogcc", "successResidente();", true);
                }
            }
        }

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Vivienda> lstViv = (List<Vivienda>)Session["ListaVivienda"];
            Vivienda v = lstViv[ddlUbicacion.SelectedIndex];

            txtMetraje.Text = v.Metraje.ToString();
            txtCaracteristicas.Text = v.Caracteristicas;
            txtTipoVivienda.Text = v.tipoVivienda;
            updateVivienda.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "initPg", "init();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarContoles();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
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
                objLst.Add(new Vivienda(){
                    CodigoVivienda = item.CodigoVivienda,
                    UbicacionComp = item.Ubicacion.NombreUbicacion + " - " + item.NumeroVivienda,
                    Metraje = item.Metraje,
                    tipoVivienda = item.TipoVivienda.NombreTipoVivienda,
                    Caracteristicas = "Sala y comedor: " + (item.TieneSalaComedor == true ?"SI":"NO")
                                      + "\n" + "Cuartos: " + item.NroCuartos
                                      + " , Baños: " + item.NroBano
                });             
            }

            ddlUbicacion.DataTextField = "UbicacionComp";
            ddlUbicacion.DataValueField = "CodigoVivienda";
            ddlUbicacion.DataSource = objLst;
            ddlUbicacion.DataBind();

            Session["ListaVivienda"] = objLst;
        
        }
        
        private void cargarGrilla()
        {
            lstResidente = proxyResidente.buscarResidentes(string.Empty, string.Empty);
            if (lstResidente != null)
            {
                foreach (var obj in lstResidente)
                {
                    lstRes.Add(new Residente
                    {
                        Codigo = obj.Codigo,
                        Nombres = obj.Nombres + " " + obj.ApellidoPaterno + " " + obj.ApellidoMaterno,
                        TipoDocumento = (obj.TipoDocumento == "01" ? "DNI" : "C.E"),
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

        private void LimpiarContoles() 
        {
            hddCodigoResidente.Value = null;
            ddlUbicacion.SelectedIndex = 0;
            txtTipoVivienda.Text = string.Empty;
            txtMetraje.Text = string.Empty;
            txtCaracteristicas.Text = string.Empty;
            txtResidente.Text = string.Empty;
            txtFechaContrato.Text = string.Empty;
            txtPerAlquiler.Text = string.Empty;
            txtCostoMensual.Text = string.Empty;
        }

        private void Grabar() 
        {
            try 
            {
                //Grabar
                string postdata =
                "{\"CodigoVivienda\":\"" + ddlUbicacion.SelectedValue.ToString() + "\""
                + ",\"CodigoResidente\":\"" + hddCodigoResidente.Value + "\""
                + ",\"FechaContrato\":\"" + txtFechaContrato.Text + "\""
                + ",\"FechaIniResidencia\":\"" + txtFechaContrato.Text + "\""
                + ",\"CostoMensual\":\"" + txtCostoMensual.Text + "\""
                + ",\"Periodo\":\"" + DateTime.Now.Year.ToString() + "\""
                + ",\"Estado\":\"1\""
                + ",\"UsuarioCreacion\":\"LFUNES\""
                + ",\"FechaCreacion\":\"" + DateTime.Now.ToShortDateString() + "\"}";
                

                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5364/ContratoService.svc/ContratoService");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string contratoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Contrato contratoCreado = js.Deserialize<Contrato>(contratoJson);

                if (contratoCreado.CodigoContrato != 0)
                {
                    //Generacion de Cuotas

                    //
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('Datos grabados correctamente!');", true);
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('Error, no se guardo el registro!');", true);
                }
            }catch(WebException e){
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('" + mensaje + "');", true);
            }
            catch(Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "successProcesar", "mostrarmensaje('" + ex.Message + "');", true);
            }            
        }

        private void ObtenerCostoAlquilerMensual() 
        {
            string Uri = String.Format("http://localhost:5364/ContratoService.svc/ObtenerCostoAquilerMensual?codigoVivienda={0}&fechaContrato={1}", ddlUbicacion.SelectedValue,txtFechaContrato.Text);
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create(Uri);
            req.Method = "GET";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string contratoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            decimal costo = js.Deserialize<decimal>(contratoJson);
            txtCostoMensual.Text = costo.ToString();
            UpdateCosto.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "initPg", "init();", true);
        }
        #endregion

        protected void btnBuscarCosto_Click(object sender, ImageClickEventArgs e)
        {
            ObtenerCostoAlquilerMensual();
        }

    

    }
}