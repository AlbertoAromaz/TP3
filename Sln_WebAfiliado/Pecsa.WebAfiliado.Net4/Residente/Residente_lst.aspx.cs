using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pecsa.WebAfiliado.Net4.Residentes
{
    public partial class Residente_lst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                List<Residente> lstRes = new List<Residente>();
                Residente objR = new Residente()
                {
                    ItemGrid = "1",
                    TipoDoc = "DNI",
                    NroDocumento = "70517084",
                    Telefono = "44444",
                    Celular = "999222122",
                    Nombres = "Juan Perez Ramos",
                    Correo = "Juan@gmail.com"
                };

                lstRes.Add(objR);


                grdListaResidentes.DataSource = lstRes;
                grdListaResidentes.DataBind();
            } 
        }



    }

    public class Residente 
    { 
       public string ItemGrid {get;set;}
       public string TipoDoc {get;set;}
       public string NroDocumento {get;set;}
       public string Telefono {get;set;}
       public string Celular {get;set;}
       public string Nombres{get;set;}
       public string Correo { get; set; }
    
    }
}