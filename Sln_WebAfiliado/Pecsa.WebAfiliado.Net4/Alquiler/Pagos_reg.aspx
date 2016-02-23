<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos_reg.aspx.cs" Inherits="IU.WebCondominios.Net4.Pagos_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titleYP">
        <h6>Pago</h6>
        <div class="textR">
            <%--<span>
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
            </span>--%>
        </div>
    </div>
      <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Ubicación" Enabled="False"></asp:Label>
            </span>
            <span class="span8">
               <asp:DropDownList ID="ddlUbicacion" runat="server"/>
            </span>           
            
        </div>
          <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label1" runat="server" Text="Residente"></asp:Label> 
            </span>
            <span class="span8">
                <asp:DropDownList ID="ddlResidente" runat="server"/>
            </span>

            <span class="span2">
                 <a href="javascript:jQuery('[id$=btnBuscar]').click();void(0);" title="" class="wButton greenwB m2"><span>Buscar</span></a>
                 <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" CssClass="hidden" />                 
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
                              <asp:GridView ID="grdListaCuotas" runat="server" AutoGenerateColumns="False" ShowHeader="true" 
                                            ShowHeaderWhenEmpty="True" CssClass="sTable" 
                                            Width="100%"  DataKeyNames="CodigoContrato,CodigoCuota, Importe" >
                                  <Columns>
                                      <asp:TemplateField>
                                          <ItemTemplate>
                                              <asp:CheckBox ID="chkElegir" runat="server" />
                                          </ItemTemplate>
                                          <HeaderStyle Width="30px" />
                                          <ItemStyle HorizontalAlign="Center" />
                                      </asp:TemplateField>
                                      <asp:BoundField HeaderText="Contrato" DataField="CodigoContrato" ControlStyle-CssClass="hidden" />
                                      <asp:BoundField HeaderText="Cuota" DataField="CodigoCuota" ControlStyle-CssClass="hidden"/>
                                      <asp:BoundField HeaderText="# Cuota" DataField="NumSequencial" ControlStyle-Width="30px" />
                                      <asp:BoundField HeaderText="vivienda" DataField="NombreCompletoVivienda" />
                                      <asp:BoundField HeaderText="Residente" DataField="NombreCompletoResidente" />
                                      <asp:BoundField HeaderText="Importe" DataField="Importe" />
                                      <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                      <asp:BoundField HeaderText="Fec. Vencimiento" DataField="FechaVencimiento" />                                      
                                    <asp:BoundField HeaderText="Fec. Pago" DataField="FechaPago" />                                      
                                  </Columns>
                              </asp:GridView>
                          </ContentTemplate>
                          <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
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
                  <span>
                      <asp:Button ID="btnRegistrarPago" runat="server" CssClass="hidden" OnClick="btnRegistrarPago_Click" />
                  </span>
                  <span class="span2">
                      <asp:HyperLink ID="HyperLink9" runat="server" CssClass="button greenB" NavigateUrl="javascript:jQuery('[id$=btnRegistrarPago]').click();void(0);">
                    <span>Registrar Pago</span>
                      </asp:HyperLink>
                  </span>
              </div>
          
          </div>

      </div>

      <div id="modal-exito">
        <fieldset>
            <div class="wrapper">
                <div class="widget">
                    <div class="titleYP">
                        <h6>Mensaje</h6>
                        <div class="textR">
                            <span>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:$('#modal-exito').dialog('close');void(0);">
                        <span>Aceptar</span>
                                </asp:HyperLink>
                            </span>
                        </div>
                    </div>
                    <div class="fluid">
                        <br />
                        <br />
                        
                        <div id="mensaje">

                        </div>

                    </div>
                </div>
            </div>
        </fieldset>
    </div>

     <script type="text/javascript">
         function mostrarmensaje(valor) {
             $('#mensaje').html(valor);
             $(".ui-dialog-titlebar").hide();
             $("#modal-exito").dialog('open');
             
         }
         $("#modal-exito").dialog({
             autoOpen: false,
             resizable: false,
             closeOnEscape: false,
             modal: true,
             width: 400
         }).parent().appendTo('.form');
     </script>
</asp:Content>