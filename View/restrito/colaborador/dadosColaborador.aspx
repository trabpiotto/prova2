<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dadosColaborador.aspx.cs" Inherits="View.restrito.colaborador.dadosColaborador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dados do colaborador</h1>
            <br />
            Nome do colaborador: <br />
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100"></asp:TextBox>
            <br />
            <br />
            CPF do colaborador: <br />
            <asp:TextBox ID="txtCpf" runat="server" MaxLength="11"></asp:TextBox>
            <br />
            <br />
            Unidade do colaborador: <br />
            <asp:DropDownList ID="cmbUnidades" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            &nbsp;
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
