<%@ page language="C#" autoeventwireup="true" codebehind="index.aspx.cs" inherits="PL_Orderie.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Orderie Login</title>
    <link rel="stylesheet" src="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="label" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:Label ID="labelUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="textUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="labelPwd" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="textPwd" runat="server"></asp:TextBox>
                <br />
            <asp:Button ID="buttonLogin" runat="server" Text="Login" OnClick="buttonLogin_Click" />
            <br />
            <asp:Label ID="labelHint" runat="server" Text="Label"></asp:Label>
        </div>


    </form>
</body>
</html>
