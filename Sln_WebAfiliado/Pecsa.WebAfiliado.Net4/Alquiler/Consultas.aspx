<%@ Page Language="C#"   MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="IU.WebCondominios.Net4.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titleYP">
        <%--<img src="<%: ResolveUrl("~/Images/icons/dark/list.png") %>" alt="" class="titleIcon" />--%>
        <h6>consulta de Pagos</h6>
    </div>

    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label3" runat="server" Text="Vivienda"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlVivienda" runat="server"/>
            </span>
            <span class="span2">
                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
            </span>
            <span class="span3">
                 <asp:DropDownList ID="ddlEstado" runat="server">
                  <asp:ListItem>Seleccionar</asp:ListItem>
                   <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>Cancelado</asp:ListItem>
                    <asp:ListItem>Pendiente</asp:ListItem>                    
                </asp:DropDownList>
            </span>
            <span class="span2">
                <asp:LinkButton ID="lkbBuscar" runat="server" class="button greenB" OnClick="btnBuscar_Click"><span>Buscar</span></asp:LinkButton>
             </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label7" runat="server" Text="Residente"></asp:Label>
            </span>
            <span class="span8">
                <asp:DropDownList ID="ddlResidente" runat="server"/>
            </span>
            <span class="span2">
                <%--<a href="#" title="" class="button greenB"><span>Limpiar</span></a>--%>
                <asp:LinkButton ID="lkbLimpiar" runat="server" CssClass="button greenB" OnClick="btnLimpiar_Click"><span>Limpiar</span></asp:LinkButton>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label8" runat="server" Text="Fec. Inicio"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="txtFecIni" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
            <span class="span2">
                <asp:Label ID="Label9" runat="server" Text="Fec.  Final"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="txtFecFin" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
        </div>
        <div class="formRow"> </div>
          <div class="formRow">
            <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdListaCuotasxCobrar" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" DataKeyNames="CodigoCuota" >
                        <Columns>
                            <asp:BoundField HeaderText="# Cuota" DataField="NumSequencial" ControlStyle-Width="30px" />
                            <asp:BoundField HeaderText="Vivienda" DataField="NombreCompletoVivienda" />
                            <asp:BoundField HeaderText="Residente" DataField="NombreCompletoResidente" />
                            <asp:BoundField HeaderText="Importe" DataField="Monto" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado_Cuota" />
                            <asp:BoundField HeaderText="Fecha Vencimiento" DataField="FechaVencimiento" />
                            <asp:BoundField HeaderText="Fecha Pago" DataField="FechaPago" />
                                                        
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    
                </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>