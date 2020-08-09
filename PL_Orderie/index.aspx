<%@ page language="C#" autoeventwireup="true" codebehind="Index.aspx.cs" inherits="PL_Orderie.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Orderie Login</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.history.back();">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <form id="form1" runat="server">
        <asp:Label ID="label" runat="server" Text="Orderie Login"></asp:Label>
        <div>
            <asp:Label CssClass="label" ID="labelUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox CssClass="inputFull" ID="textUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label CssClass="label" ID="labelPwd" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox CssClass="inputFull" ID="textPwd" runat="server"></asp:TextBox>
            <br />
            <asp:Button CssClass="button buttonFull" ID="buttonLogin" runat="server" Text="Login" OnClick="buttonLogin_Click" />
            <br />
            <asp:Label ID="labelHint" runat="server" Text="Label"></asp:Label>
        </div>


    </form>
</body>
</html>
