<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Vivienda_lst.aspx.cs" Inherits="Pecsa.WebAfiliado.Net4.Vivienda.Vivienda_lst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="titleYP">
        <%--<img src="<%: ResolveUrl("~/Images/icons/dark/list.png") %>" alt="" class="titleIcon" />--%>
        <h6>Lista de Viviendas</h6>
        <div class="textR">

             <span>
                    <asp:Button ID="btnBuscar" runat="server"  CssClass="hidden" />
                </span>
            <span>
              <asp:LinkButton ID="lkbLimpiar" runat="server" CssClass="bFirst buttonYP basicYP" OnClick="btnLimpiar_Click"><span>Limpiar</span></asp:LinkButton>
            </span>
            <span>
              <asp:LinkButton ID="lkbBuscar" runat="server" CssClass="bFirst buttonYP basicYP" OnClick="btnBuscar_Click"><span>Buscar</span></asp:LinkButton>
            </span>
                <span>
                    <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="~/Vivienda/Vivienda_reg.aspx"> <%--<img src="<%: ResolveUrl("~/Images/icons/light/nuevo.png") %>" class="icon" alt="">--%><span>Nuevo</span> </asp:HyperLink>
                </span>
            </div>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Tipo Vivienda"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlTipoVivienda" runat="server" Enabled="true" />
                           
            </span>             
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label3" runat="server" Text="Ubicación"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlUbicacion" runat="server" Enabled="true"/>
            </span>     
             <span class="span1">
                <asp:Label ID="Label5" runat="server" Text="Número"></asp:Label>
            </span>
            <span class="span1">
                <asp:TextBox ID="txtNúmeroVivienda" runat="server" Width="60px"></asp:TextBox>
            </span>
                    
        </div>
        
        <div class="formRow">
            <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdListaVivienda" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" DataKeyNames="CodigoVivienda" OnRowCommand="grdListaVivienda_RowCommand" >
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="CodigoVivienda" ControlStyle-Width="30px" />
                           <%-- <asp:BoundField HeaderText="Tipo" DataField="TipoVivienda.NombreTipoVivienda" />
                            <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion.NombreUbicacion" />--%>
                            <asp:BoundField HeaderText="Numero" DataField="NumeroVivienda" />
                            <asp:BoundField HeaderText="Metraje" DataField="Metraje" />
                            <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandName="Editar" ImageUrl="~/Images/icons/light/pencil.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


