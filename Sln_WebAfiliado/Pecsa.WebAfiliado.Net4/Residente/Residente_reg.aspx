<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Residente_reg.aspx.cs" Inherits="Pecsa.WebAfiliado.Net4.Residentes.Residente_reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="titleYP">
        <%--<img src="<%: ResolveUrl("~/Images/icons/dark/files.png") %>" alt="" class="titleIcon" />--%>
        <h6>Registro de Residentes</h6>
        <div class="textR">
            <span>
                <asp:Button ID="btnGrabar" runat="server" CssClass="hidden" OnClick="btnGrabar_Click"  />
            </span>
            <span>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="bFirst buttonYP basicYP"  NavigateUrl="javascript:jQuery('[id$=btnGrabar]').click();">
                    <%--<img src="<%: ResolveUrl("~/Images/icons/light/create.png") %>" class="icon" alt="">--%>
                    <span>Grabar</span>
                </asp:HyperLink>
            </span>
        </div>
    </div>
    <div class="fluid">
        <div class="formRow">
            <span class="span2">               
                     <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>              
            </span>
            <span class="span3">
                 <asp:UpdatePanel ID="updateCodigo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCodigo" runat="server" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="btnGrabar" EventName="Click"/>
                     </Triggers>
                </asp:UpdatePanel>
            </span>
            <span class="span2">
                <asp:Label ID="Label5" runat="server" Text="Fecha Reg"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="txtFechaRegistro" runat="server" Enabled="False"></asp:TextBox>
            </span>          
            <span class="span2">
                <asp:CheckBox ID="chkEstado" runat="server" Text="Estado" Checked="True" />
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label2" runat="server" Text="Tipo Doc."></asp:Label>
            </span>
            <span class="span3">
                <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                    <asp:ListItem>DNI</asp:ListItem>
                    <asp:ListItem>C. E.</asp:ListItem>
            </asp:DropDownList>
            </span>
            <span class="span2">
                <asp:Label ID="Label9" runat="server" Text="Número Doc."></asp:Label>
            </span>
            <span class="span5">
                <asp:TextBox ID="txtNroDoc" runat="server" ></asp:TextBox>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
            </span>
            <span class="span10">
                <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
            </span>  
        </div>
        <div class ="formRow">
            <span class="span2">
                <asp:Label ID="Label13" runat="server" Text="Apellido Paterno"></asp:Label>
            </span>
            <span class="span10">
                <asp:TextBox ID="txtApellidoP" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class ="formRow">
           <span class="span2">
                <asp:Label ID="Label14" runat="server" Text="Apellido Materno"></asp:Label>
            </span>
            <span class="span10">
                <asp:TextBox ID="txtApellidoM" runat="server"></asp:TextBox>
            </span>
        </div>
        
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label4" runat="server" Text="Sexo"></asp:Label>
            </span>
            <span class="span3">
                
                <asp:DropDownList ID="ddlSexo" runat="server" >
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Femenino</asp:ListItem>
                </asp:DropDownList>
                
            </span>
            <span class="span2">
                <asp:Label ID="Label6" runat="server" Text="F.N."></asp:Label>
            </span>
            <span class="span5">
                <asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label7" runat="server" Text="Teléfono"></asp:Label>
            </span>
            <span class="span3">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </span>
            <span class="span2">
                <asp:Label ID="Label8" runat="server" Text="Celular"></asp:Label>
            </span>
            <span class="span5">
                <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
            </span>                
        </div>
        <div class="formRow">
            <span class="span2">
                <asp:Label ID="Label10" runat="server" Text="Correo"></asp:Label>
            </span>
            <span class="span10">
                <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            </span>
        </div>
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

        $('[id$=btnGrabar]').click(function () {
            valida();
        });

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

        function valida() {

            var nombre = $('[id$=txtNombres]').val();
            var ApeMat = $('[id$=TextBox1]').val();
            var ApePat = $('[id$=TextBox2]').val();

            var dni = $('[id$=TextBox5]').val();
            var dni1 = "40530678";

            if (nombre == "" || ApeMat == "" || ApeMat == "") {
                alert("Ingrese los datos necesarios");
                return false;
            }

            if (dni == dni1) {
                alert("El residente ya se encuentra registrado");
                return false;
            }

            return true;
            //var mensaje = "";
            //if (dni == "123")
            //{
            //    mensaje = "Debe ingresar el numero de DNI";
            //}
            alert(dni);

        }

    </script>
</asp:Content>