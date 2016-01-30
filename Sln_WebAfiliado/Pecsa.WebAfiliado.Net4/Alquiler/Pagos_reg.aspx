<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos_reg.aspx.cs" Inherits="IU.WebCondominios.Net4.Pagos_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titleYP">
        <h6>Pago de Cuotas</h6>
        <div class="textR">
            <span>
                <asp:Button ID="btnGrabar" runat="server" CssClass="hidden" />
            </span>
            <span>
                <asp:Button ID="btnLimpiar" runat="server" CssClass="hidden" />
            </span>
            <span>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:jQuery('[id$=btnLimpiar]').click();">
                <img src="<%: ResolveUrl("~/Images/icons/dark/close.png") %>" class="icon" alt=""><span>Limpiar</span>
                </asp:HyperLink>
            </span>
            <span>
                <asp:HyperLink ID="lnkGrabar" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:jQuery('[id$=btnGrabar]').click();">
                <img src="<%: ResolveUrl("~/Images/icons/light/create.png") %>" class="icon" alt=""><span>Grabar</span>
                
                </asp:HyperLink>
            </span>
        </div>
    </div>
      <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Ubicación" Enabled="False"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlUbicacion" runat="server" >
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>
             <span class="span2">
                <asp:Label ID="Label4" runat="server" Text="Número"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="txtNúmero" runat="server" Width="80px"></asp:TextBox>
            </span>
             <span class="span2">
                <a href="#" title="" class="button greenB"><span>Buscar</span></a>
            </span>
        </div>
          <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label1" runat="server" Text="Residente"></asp:Label> 
            </span>
            <span class="span10">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
            </span>
          </div>
          <div class="title">
              <h6>Registro de Pago</h6>
          </div>
          <div class="fluid">
              <div class="formRow">
                  <span class="span2">
                      <asp:Label ID="Label3" runat="server" Text="Fecha Pago"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:TextBox ID="TextBox2" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                  </span>
                  <span class="span2">
                      <asp:Label ID="Label5" runat="server" Text="A Pagar"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:TextBox ID="TextBox3" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                  </span>
              </div>
              <div  class="formRow">
                  <span class="span2">
                      <asp:Label ID="Label6" runat="server" Text="Forma Pago"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:DropDownList ID="ddlFormaPago" runat="server" OnChange="probar(this);">
                          <asp:ListItem>Efectivo</asp:ListItem>
                          <asp:ListItem>Deposito</asp:ListItem>
                      </asp:DropDownList>
                  </span>               
              </div>
              <div id="idCuenta" class="formRow" style="display:none">
                  <span class="span2">
                      <asp:Label ID="Label8" runat="server" Text="Cuenta"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:DropDownList ID="DropDownList3" runat="server">
                          <asp:ListItem>BCP-1111254557</asp:ListItem>
                          <asp:ListItem>BBVA-1335568874</asp:ListItem>
                      </asp:DropDownList>
                  </span>
                  <span class="span2">
                      <asp:Label ID="Label10" runat="server" Text="Nro. Operación"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox>
                  </span>
              </div>
              <div class="formRow">                 
                   <span class="span2">
                      <asp:Label ID="Label7" runat="server" Text="Moneda"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:DropDownList ID="DropDownList2" runat="server">
                          <asp:ListItem>Soles</asp:ListItem>
                      </asp:DropDownList>
                  </span>
                   <span class="span2">
                      <asp:Label ID="Label9" runat="server" Text="Importe"></asp:Label>
                  </span>
                  <span class="span4">
                      <asp:TextBox ID="TextBox4" runat="server"  Width="100px" ></asp:TextBox>
                  </span>
              </div>
              <div class="formRow">    
                  <span class="span2">
                      <asp:Label ID="Label11" runat="server" Text="Comentarios"></asp:Label>
                  </span>
                  <span class="span10">
                      <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine"></asp:TextBox>
                  </span>
              </div>
          </div>
          <div class="title">
              <h6>Lista de Pagos (Vivienda/Cliente)</h6>
          </div>
          <div class="fluid">
              <div class="formRow">
                  <div class="widget">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>
                              <asp:GridView ID="grdListaCuotas" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" >
                                  <Columns>
                                      <asp:BoundField HeaderText="Item" DataField="ItemGrid" ControlStyle-Width="30px" />
                                      <asp:BoundField HeaderText="Fecha Pago" DataField="FechaPago" />
                                      <asp:BoundField HeaderText="Concepto" DataField="Concepto" />
                                      <asp:BoundField HeaderText="Moneda" DataField="Moneda" />
                                      <asp:BoundField HeaderText="Importe" DataField="Importe" />
                                      <asp:BoundField HeaderText="Pagado" DataField="Pagado" />                                      
                                  </Columns>
                              </asp:GridView>
                          </ContentTemplate>
                          <Triggers>
                          </Triggers>
                      </asp:UpdatePanel>
                  </div>
              </div>
          </div>

      </div>

     <script type="text/javascript">
         function probar(elem) {
             if (elem.selectedIndex == "-1") {
                 document.getElementById('idCuenta').style.display = 'none';
             } else
             {
                 document.getElementById('idCuenta').style.display = 'block';
             }
             return true;
         }
     </script>
</asp:Content>