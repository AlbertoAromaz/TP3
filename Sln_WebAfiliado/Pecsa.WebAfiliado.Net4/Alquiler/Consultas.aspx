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
                <asp:Label ID="Label3" runat="server" Text="Ubicación"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlUbicacion" runat="server">
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>
            <span class="span2">
                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
            </span>
            <span class="span3">
                 <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>Cancelado</asp:ListItem>
                    <asp:ListItem>Pendiente</asp:ListItem>                    
                </asp:DropDownList>
            </span>
            <span class="span2">
                <a href="#" title="" class="button greenB"><span>Buscar</span></a>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label7" runat="server" Text="Residente"></asp:Label>
            </span>
            <span class="span8">
                <asp:TextBox ID="txtResidente" runat="server"></asp:TextBox>
            </span>
            <span class="span2">
                <a href="#" title="" class="button greenB"><span>Limpiar</span></a>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label8" runat="server" Text="Fec. Inicio"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
            <span class="span2">
                <asp:Label ID="Label9" runat="server" Text="Fec.  Final"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
        </div>
        <div class="formRow"> </div>
          <div class="formRow">
            <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdListaCuotasxCobrar" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" DataKeyNames="NroCuota" >
                        <Columns>
                            <asp:BoundField HeaderText="# Cuota" DataField="NroCuota" ControlStyle-Width="30px" />
                            <asp:BoundField HeaderText="Vivienda" DataField="Vivienda" />
                            <asp:BoundField HeaderText="Residente" DataField="Residente" />
                            <asp:BoundField HeaderText="Importe" DataField="Importe" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
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