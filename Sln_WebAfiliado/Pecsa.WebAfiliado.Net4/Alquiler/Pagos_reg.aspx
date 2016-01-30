<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos_reg.aspx.cs" Inherits="IU.WebCondominios.Net4.Pagos_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titleYP">
        <h6>Pago</h6>
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
            <span class="span8">
                <asp:DropDownList ID="ddlUbicacion" runat="server" >
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>           
            
        </div>
          <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label1" runat="server" Text="Residente"></asp:Label> 
            </span>
            <span class="span8">
                <asp:TextBox ID="txtResidente" runat="server" Enabled="false"></asp:TextBox>
            </span>

            <span class="span2">
                <a href="#" title="" class="button greenB"><span>Buscar</span></a>
            </span>
          </div>
          <div class="title">
              <h6>Detalle de Cuotas</h6>
          </div>
  
          <div class="fluid">
              <div class="formRow">
                  <div class="widget">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>
                              <asp:GridView ID="grdListaCuotas" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" >
                                  <Columns>
                                    <asp:TemplateField HeaderText="Sel">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRow" runat="server" />
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:BoundField HeaderText="# Cuota" DataField="ItemGrid" ControlStyle-Width="30px" />
                                      <asp:BoundField HeaderText="vivienda" DataField="Vivienda" />
                                      <asp:BoundField HeaderText="Residente" DataField="Residente" />
                                      <asp:BoundField HeaderText="Importe" DataField="Importe" />
                                      <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                      <asp:BoundField HeaderText="Fec. Vencimiento" DataField="Pagado" />                                      
                                    <asp:BoundField HeaderText="Fec. Pago" DataField="FechaPago" />                                      
                                  </Columns>
                              </asp:GridView>
                          </ContentTemplate>
                          <Triggers>
                          </Triggers>
                      </asp:UpdatePanel>
                  </div>
              </div>
          
            <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label3" runat="server" Text="Total a Pagar"></asp:Label> 
            </span>
            <span class="span2">
                <asp:TextBox ID="txtTotalAPagar" runat="server" Enabled="false"></asp:TextBox>
            </span>
             <span class="span2">
                <a href="#" title="" class="button greenB"><span>Registrar Pago</span></a>
            </span>
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