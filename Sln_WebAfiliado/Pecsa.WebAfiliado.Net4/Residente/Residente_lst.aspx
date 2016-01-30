<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Residente_lst.aspx.cs" Inherits="Pecsa.WebAfiliado.Net4.Residentes.Residente_lst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="titleYP">
        <%--<img src="<%: ResolveUrl("~/Images/icons/dark/list.png") %>" alt="" class="titleIcon" />--%>
        <h6>Lista de Residentes</h6>
        <div class="textR">
                <span>
                    <asp:Button ID="btnBuscar" runat="server"  CssClass="hidden" />
                </span>
                <span>
                    <asp:HyperLink ID="lnkBuscar" runat="server" CssClass="bFirst buttonYP basicYP" > <%--<img src="<%: ResolveUrl("~/Images/icons/light/buscar.png") %>" class="icon" alt="">--%><span>Buscar &nbsp;</span> </asp:HyperLink>
                </span>
                <span>
                    <asp:HyperLink ID="lnkNuevo" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="~/Residente/Residente_reg.aspx"> <%--<img src="<%: ResolveUrl("~/Images/icons/light/nuevo.png") %>" class="icon" alt="">--%><span>Nuevo</span> </asp:HyperLink>
                </span>
            </div>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label1" runat="server" Text="Razón Social"></asp:Label>
            </span>
            <span class="span5">
                <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
            </span>
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Nro Documento"></asp:Label>
            </span>
            <span class="span3">
                
                <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox>
            </span>
            
        </div>
        
        <div class="formRow">
            <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdListaResidentes" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowHeaderWhenEmpty="True" CssClass="sTable" Width="100%" DataKeyNames="Nombres" >
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

