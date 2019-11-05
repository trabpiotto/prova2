<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paginaInicial.aspx.cs" Inherits="View.restrito.paginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Bem vindo,  <asp:Label ID="lblNome" runat="server"> </asp:Label> </h1><br /><br />
            <asp:Label ID="lblDescricao" runat="server"></asp:Label>
           
        </div>
    </form>
</body>
</html>
