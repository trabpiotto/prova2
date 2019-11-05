<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="View.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Usuário</title>
    <link rel="stylesheet" type="text/css" href="assets/css/style.css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
   <body class="bg-color">
        <div class="container-fluid h-100">
            <div class="row form-cadastro justify-content-center p-4">
                <div class="col-md-3 align-self-center area-form">                 
<div class="row justify-content-center">
    <img src="imagens/logo.png"alt="" height="150" width="170" />
</div>
<span class="large d-block text-center text-white font-weight-bold">Crie um novo cadastro</span>

<form id="frmCadastro" runat="server">
    <div class="input-group mt-2 rows">
          <asp:TextBox ID="txtNome" runat="server" class="textArea2" MaxLength="200" placeholder="Nome completo"></asp:TextBox> </div>
    <div class="input-group mt-2 rows">
         <asp:TextBox ID="txtEmail" runat="server" class="textArea2" MaxLength="200" placeholder="Email"></asp:TextBox>
    </div>
        <div class="input-group mt-2">
         <asp:TextBox ID="txtDescricao" runat="server" class="textArea" TextMode="MultiLine" placeholder="Descrição"></asp:TextBox>
    </div>
   <div class="input-group mt-2">
        <asp:TextBox ID="txtSenha" runat="server" class="textArea2" MaxLength="20" TextMode="Password" placeholder="Senha"></asp:TextBox>
    </div>
    <div class="row">
        <div class="col-md-6">
                <asp:button ID="btnCancelar" runat="server" type="button" class="btn btn-info btn-block mt-2" OnClick="btnCadastrar_Click" Text="Cancelar"/>
        </div>
        <div class="col-md-6">
                <asp:button ID="btnCadastrar" runat="server" type="button" class="btn btn-info btn-block mt-2" OnClick="btnCadastrar_Click" Text="Cadastrar"/>
        </div>
    </div>  
</form>
</div>
</div>
</div>
</body>
</html>
