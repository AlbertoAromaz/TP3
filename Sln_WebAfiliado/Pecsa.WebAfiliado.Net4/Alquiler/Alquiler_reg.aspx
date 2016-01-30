<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alquiler_reg.aspx.cs" Inherits="IU.WebCondominios.Net4.Alquiler_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titleYP">
        <h6>Registro de Alquiler</h6>
        <div class="textR">
            <span>
                <asp:Button ID="btnGrabar" runat="server" CssClass="hidden" />
            </span>
            <span>
                <asp:HyperLink ID="lnkGrabar" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:jQuery('[id$=btnGrabar]').click();void(0);">
                <img src="<%: ResolveUrl("~/Images/icons/light/create.png") %>" class="icon" alt=""><span>Grabar</span>
                </asp:HyperLink>
            </span>
        </div>
    </div>
    <div class="title">
        <h6>Vivienda</h6>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Ubicación" Enabled="False"></asp:Label>
            </span>
            <span class="span6">
                <asp:DropDownList ID="ddlUbicacion" runat="server" >
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>
            
            
        </div>
         <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label7" runat="server" Text="Tipo Viv."></asp:Label>
            </span>
            <span class="span4">
                <asp:DropDownList ID="DropDownList1" runat="server" Enabled="false">
                    <asp:ListItem>Casa</asp:ListItem>
                    <asp:ListItem>Apartamento</asp:ListItem>
                </asp:DropDownList>
            </span>
              <span class="span2">
                <asp:Label ID="Label6" runat="server" Text="Metraje"></asp:Label>
            </span>
            <span class="span4">
                <asp:TextBox ID="txtMetraje" runat="server" Width="80px" Enabled="false"></asp:TextBox>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label10" runat="server" Text="Caracteristicas"></asp:Label>
            </span>
            <span class="span10">
                <asp:TextBox ID="txtCaracteristicas" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
            </span>            
        </div> 
    </div>
     <div class="title">
         <h6>Datos del Residente</h6>         
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label1" runat="server" Text="Nombres"></asp:Label> 
            </span>
            <span class="span8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtResidente" runat="server" Enabled="false"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdListaResidentes" EventName="RowCommand"/>
                    </Triggers>
                </asp:UpdatePanel>
            
            </span>
            <span class="span2">
                <a href="javascript:jQuery('[id$=btnBuscarResidente]').click();void(0);" title="" class="wButton greenwB m2"><span>Buscar</span></a>
                <asp:Button ID="btnBuscarResidente" runat="server" OnClick="btnBuscarResidente_Click" CssClass="hidden" />
                
            </span>
        </div>
         <div class="formRow">
             </div>
         <div class="formRow">
             </div>
    </div>
     <div class="title">
         <h6>Datos del Contrato</h6>         
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span3">
                <asp:Label ID="Label3" runat="server" Text="Fecha Contrato"></asp:Label>
            </span>
            <span class="span6">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="datepicker"></asp:TextBox>

            </span>
            
        </div>
        <div class="formRow">
            <span class="span3">
                <asp:Label ID="Label5" runat="server" Text="Periodo Alquiler"></asp:Label>
            </span>
            <span class="span2">
                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            </span>
        </div>
        <div class="formRow">
            <span class="span3">
                <asp:Label ID="Label8" runat="server" Text="Costo Mensual"></asp:Label>
            </span>
            <span class="span2">
                <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
            </span>
            
        </div>
        <div class="formRow">
            </div>
    </div>
    <div class="title">
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span4">
                <a href="#" title="" class="wButton greenwB m2"><span>Generar Contrato</span></a>
            </span>
        </div>    
    </div>

    <div id="modal-Residente">
        <fieldset>
            <div class="wrapper">
                <div class="widget">
                    <div class="titleYP">
                        <h6>Lista de Residentes</h6>
                        <div class="textR">
                            <span>
                                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:$('#modal-Residente').dialog('close');void(0);">
                        <span>Cancelar</span>
                                </asp:HyperLink>
                            </span>
                        </div>
                    </div>
                    <div class="fluid">
                        <div class="formRow">
                            <div class="widget">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                         <asp:GridView ID="grdListaResidentes" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" 
                                             DataKeyNames="Nombres" 
                                             OnRowCommand="grdListaResidentes_RowCommand">
                                        <Columns>
                                            <asp:BoundField HeaderText="Item" DataField="ItemGrid" ControlStyle-Width="30px" />
                                            <asp:BoundField HeaderText="Tipo Doc." DataField="TipoDoc" />
                                            <asp:BoundField HeaderText="Nro. Doc." DataField="NroDocumento" />
                                            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
                                            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                                            <asp:BoundField HeaderText="Celular" DataField="Celular" />
                                            <asp:BoundField HeaderText="Correo Electronico" DataField="Correo" />
                                            <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSelectCC" runat="server" CommandName="SelectCC" ImageUrl="~/Images/icons/light/select.png" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="25px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                        
                          
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnBuscarResidente" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
    <asp:HiddenField id="hddCodigo" runat="server"></asp:HiddenField>
    
    <script>

        function openAsociarResidente() {
            $(".ui-dialog-titlebar").hide();
            $("#modal-Residente").dialog('open');
        }

        function successResidente() {
            $("#modal-Residente").dialog('close');
        }

        $("#modal-Residente").dialog({
            autoOpen: false,
            resizable: false,
            closeOnEscape: false,
            modal: true,
            width: 800
        }).parent().appendTo('.form');


    </script>
</asp:Content>
