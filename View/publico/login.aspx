<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="View.publico.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="assets/css/style.css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
    <body class="bg-color">
        <div class="container-fluid h-100">
            <div class="row form-cadastro justify-content-center p-4">
                <div class="col-md-3 align-self-center area-form">                 
<div class="row justify-content-center">
    <img src="imagens/logo.png"alt="" height="150" width="170" />
</div>
<span class="large d-block text-center text-white font-weight-bold">Faça o seu Login</span>

<form id="frmCadastro" runat="server">
    <div class="input-group mt-2 rows" >
          <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" CssClass="label" placeholder="Digite seu E-mail"></asp:TextBox>
    </div>
    <div class="input-group mt-2 rows" >
         <asp:TextBox ID="txtSenha" runat="server" MaxLength="200" CssClass="label" placeholder="Password"></asp:TextBox>
    </div>
    <div class="row justify-content-center">
                <asp:button ID="btnLogin" runat="server" type="button" class="btn btn-info btn-block mt-2" OnClick="btnLogin_Click" Text="Logar"/>
    </div> 
     
    <div class="row justify-content-center large d-block text-center font-weight-bold mt-3 ">
        <a href="cadastro.aspx">Não tem uma conta? Clique aqui</a>
    </div> 
</form>
</div>
</div>
</div>


</body>
</html>
