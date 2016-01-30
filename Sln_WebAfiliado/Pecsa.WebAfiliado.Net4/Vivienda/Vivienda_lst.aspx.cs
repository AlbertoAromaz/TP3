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
        private ViviendaWS.ViviendaServiceClient proxyVivienda = new ViviendaWS.ViviendaServiceClient();

        #region Form Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                List<Vivienda> lstviv = new List<Vivienda>();
                Vivienda obj = new Vivienda
                {
                    ItemGrid = "1",
                    Ubicacion = "Zona A",
                    Numero = "104",
                    Tipo = "Casa",
                    Caracteristicas = "3 Dormitorios, 1 Baño",
                    Metraje = "200*600m",
                    
                };
                lstviv.Add(obj);

                grdListaVivienda.DataSource = lstviv;
                grdListaVivienda.DataBind();
            }
        }
    }

        #endregion

    public class Vivienda
    {
        public string ItemGrid { get; set; }
        public string Ubicacion {get;set;}
        public string Numero {get;set;}
        public string Tipo {get;set;}
        public string Caracteristicas {get;set;}
        public string Metraje {get;set;}
        public string Precio { get; set; }
    }
}