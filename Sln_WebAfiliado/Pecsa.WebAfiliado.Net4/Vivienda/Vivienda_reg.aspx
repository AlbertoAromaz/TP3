<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vivienda_reg.aspx.cs" Inherits="Pecsa.WebAfiliado.Net4.Vivienda.Vivienda_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titleYP">
        <%--<img src="<%: ResolveUrl("~/Images/icons/dark/files.png") %>" alt="" class="titleIcon" />--%>
        <h6>Registro de Vivienda</h6>
        <div class="textR">
            <span>
                
            </span>
            <span>
                <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="bFirst buttonYP basicYP"  >
                    <img src="<%: ResolveUrl("~/Images/icons/light/create.png") %>" class="icon" alt="">
                    <span>Grabar</span>
                </asp:HyperLink>--%>
                <asp:LinkButton ID="lkbGrabar" runat="server" CssClass="bFirst buttonYP basicYP" OnClick="btnGrabar_Click"><span>Grabar</span></asp:LinkButton>
               <%-- <asp:Button ID="btnGrabar" runat="server"  CssClass="bFirst buttonYP basicYP" OnClick="btnGrabar_Click" />--%>
            </span>
        </div>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </span>
            <span class="span1">
                <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
            </span>             
            <span class="span2">
                <asp:CheckBox ID="chkEstado" runat="server" Text="Estado" Checked="True" Enabled="false" />
            </span>
        </div>

        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Tipo Vivienda"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlTipoVivienda" runat="server" />
                           
            </span>             
        </div>

        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label3" runat="server" Text="Ubicación"></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlUbicacion" runat="server"/>
            </span>     
             <span class="span1">
                <asp:Label ID="Label5" runat="server" Text="Número"></asp:Label>
            </span>
            <span class="span1">
                <asp:TextBox ID="txtNúmero" runat="server" Width="60px"></asp:TextBox>
            </span>
                    
        </div>
        <div class="formRow">
              <span class="span2">
                <asp:Label ID="Label6" runat="server" Text="Metraje"></asp:Label>
            </span>
            <span class="span1">
                <asp:TextBox ID="txtMetraje" runat="server"></asp:TextBox>
            </span>
        </div>

        <div class="titleYP">
            <h6>Caracteristicas:</h6>
        </div>
        <div class="formRow">
            <span class="span2">
                 <asp:Label ID="Label4" runat="server" Text="Label4" ForeColor="White" ></asp:Label>
            </span>
            <span class="span4">
                <asp:CheckBox ID="chkSalaComedor" runat="server" Text="Sala y Comedor?" Checked="True" />
            </span>
        
        </div>
        <div class="formRow">
            <span class="span2">
                 <asp:Label ID="Label8" runat="server" Text="Label4" ForeColor="White" ></asp:Label>
            </span>
            <span class="span1">
                <asp:Label ID="lblCuartos" runat="server" Text="Nro.Cuartos"></asp:Label>
            </span>
            <span class="span1">
                 <asp:TextBox ID="txtNroCuartos" runat="server" Width="60px"></asp:TextBox>
            </span>     
        </div>

         <div class="formRow">
            <span class="span2">
                 <asp:Label ID="Label9" runat="server" Text="Label4" ForeColor="White" ></asp:Label>
            </span>
            <span class="span1">
                <asp:Label ID="Label10" runat="server" Text="Nro.Baños"></asp:Label>
            </span>
            <span class="span1">
                <asp:TextBox ID="txtNroBaños" runat="server" Width="60px"></asp:TextBox>
            </span>     
        </div>



        
   <%--        <!-- Multiple files uploader -->
        <div class="widget">
            <div class="title"><img src="../Images/icons/dark/upload.png" alt="" class="titleIcon" /><h6>Subir Fotos</h6></div>
            <div id="uploader"></div>
        </div>--%>
    
        
        
         
    </div>
    <div id="modal-Mensaje">
        <fieldset>
            <div class="wrapper">
                <div class="widget">
                    <div class="titleYP">
                        <h6>Mensaje</h6>
                        <div class="textR">

                            <span>
                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="bFirst buttonYP basicYP" NavigateUrl="javascript:jQuery('#modal-Mensaje').dialog('close');;void(0);">
                                    <span>Aceptar</span>
                                </asp:HyperLink>
                            </span>
                        </div>
                    </div>

                    <div class="fluid">
                        <span id="valorMensaje" style="padding: 10px; float: left;"></span>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>

    <script type="text/javascript">

        function dialogPrecioSucces() {
            $(".ui-dialog-titlebar").hide();
            $("#modal-Mensaje").dialog('open');
        }

        function mostrarMensaje(valor) {
            $(".ui-dialog-titlebar").hide();
            $("#valorMensaje").html(valor);
            $("#modal-Mensaje").dialog('open');
        }

        $("#modal-Mensaje").dialog({
            autoOpen: false,
            resizable: false,
            closeOnEscape: false,
            modal: true,
            width: 400
        }).parent().appendTo('.form');

    </script>

</asp:Content>
