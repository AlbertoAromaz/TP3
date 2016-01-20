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
                <asp:HyperLink ID="lnkGrabar" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:jQuery('[id$=btnGrabar]').click();">
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
            <span class="span4">
                <asp:DropDownList ID="ddlUbicacion" runat="server" Enabled="false">
                    <asp:ListItem>Zona A</asp:ListItem>
                    <asp:ListItem>Zona B</asp:ListItem>
                    <asp:ListItem>Zona C</asp:ListItem>
                </asp:DropDownList>
            </span>
             <span class="span2">
                <asp:Label ID="Label4" runat="server" Text="Número"></asp:Label>
            </span>
            <span class="span4">
                <asp:TextBox ID="txtNúmero" runat="server" Width="80px" Enabled="false"></asp:TextBox>
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
         <h6>Cliente</h6>         
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                  <asp:Label ID="Label1" runat="server" Text="Nombres"></asp:Label> 
            </span>
            <span class="span8">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
            </span>
            <span class="span2">
                <a href="#" title="" class="wButton greenwB m2"><span>Buscar</span></a>
            </span>
        </div>
         <div class="formRow">
             </div>
         <div class="formRow">
             </div>
    </div>
     <div class="title">
         <h6>Reglas de Generación de Cuotas</h6>         
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label3" runat="server" Text="Frecuencia"></asp:Label>
            </span>
            <span class="span4">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Mensual</asp:ListItem>
                    <asp:ListItem>Quincenal</asp:ListItem>
                </asp:DropDownList>
            </span>
            <span class="span2">
                <asp:Label ID="Label5" runat="server" Text="Concepto"></asp:Label>
            </span>
            <span class="span4">
                <asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>Alquiler</asp:ListItem>
                    <asp:ListItem>Comprar</asp:ListItem>
                </asp:DropDownList>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label8" runat="server" Text="E. Inicio"></asp:Label>
            </span>
            <span class="span4">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
            <span class="span2">
                <asp:Label ID="Label9" runat="server" Text="E. Final"></asp:Label>
            </span>
            <span class="span4">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="datepicker"></asp:TextBox>
            </span>
        </div>
    </div>
</asp:Content>
