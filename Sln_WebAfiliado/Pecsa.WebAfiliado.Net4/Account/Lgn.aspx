<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lgn.aspx.cs" Inherits="Pecsa.WebAfiliado.Net4.Account.Lgn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/login.css">
</head>
<body class="page-body login-page login-form-fall loaded login-form-fall-init">
    <div class="login-container">
        <div class="login-progressbar">
            <div></div>
        </div>
        <div class="login-form">
            <div class="login-content">
                <div class="logo" style="padding-bottom: 25px;">
                    <img src="<%: ResolveUrl("~/Images/logo.png") %>" alt="">
                </div>
                <form method="post" id="form_login" runat="server">
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="entypo-user"></i></div>
                            <%--<input type="text" class="form-control" name="username" id="username" autocomplete="off">--%>
                            <asp:TextBox ID="txtUsuario" runat="server" class="form-control" AutoCompleteType="Office"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="entypo-key"></i></div>
                            <%--<input type="password" class="form-control" name="password" id="password" autocomplete="off">--%>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" AutoCompleteType="Office" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-primary btn-block btn-login" OnClick="btnIngresar_Click" />
                        <%--<button type="submit" class="btn btn-primary btn-block btn-login">
                            <i class="entypo-login"></i>
                            Login In
                        </button>--%>
                    </div>
                </form>
            </div>
        </div>
    </div>

</body>
</html>
