<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="css/signin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div  class="container">
    <form class="form-signin" id="form1" runat="server">
            <h2 class="form-signin-heading">Sistema de SMS</h2>
        <asp:TextBox ID="TextBox1" class="form-control" placeholder="Login"  runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" class="form-control" placeholder="Senha"  runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="Button1" class="btn btn-lg btn-primary btn-block" runat="server" Text="Entrar" OnClick="Button1_Click" />
    </form>
    </div>
</body>
</html>
