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
                    <asp:HyperLink ID="lnkBuscar" runat="server" CssClass="bFirst buttonYP basicYP" > <%--<img src="<%: ResolveUrl("~/Images/icons/light/buscar.png") %>" class="icon" alt="">--%><span>Buscar &nbsp;</span> </asp:HyperLink>
                </span>
                <span>
                    <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="~/Vivienda/Vivienda_reg.aspx"> <%--<img src="<%: ResolveUrl("~/Images/icons/light/nuevo.png") %>" class="icon" alt="">--%><span>Nuevo</span> </asp:HyperLink>
                </span>
            </div>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span1m">
                <asp:Label ID="Label1" runat="server" Text="Zona"></asp:Label>
            </span>
            <span class="span7">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>
            <span class="span1m">
                <asp:Label ID="Label2" runat="server" Text="Numero"></asp:Label>
            </span>
            <span class="span2">              
                <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox>
            </span>
            
        </div>
        
        <div class="formRow">
            <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdListaVivienda" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" DataKeyNames="Numero" >
                        <Columns>
                            <asp:BoundField HeaderText="Item" DataField="ItemGrid" ControlStyle-Width="30px" />
                            <asp:BoundField HeaderText="Ubicación" DataField="Ubicacion" />
                            <asp:BoundField HeaderText="Número" DataField="Numero" />
                            <asp:BoundField HeaderText="Tipo Viv." DataField="Tipo" />
                            <asp:BoundField HeaderText="Metraje" DataField="Metraje" />
                            <asp:BoundField HeaderText="Caracteristicas" DataField="Caracteristicas" />
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


