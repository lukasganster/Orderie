<%@ page language="C#" autoeventwireup="true" codebehind="index.aspx.cs" inherits="PL_Orderie.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="label" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:Label ID="labelEmail" runat="server" Text="E-Mail:"></asp:Label>
            <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="labelPwd" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="textPwd" runat="server"></asp:TextBox>
                <br />
            <asp:Button ID="buttonLogin" runat="server" Text="Login" OnClick="buttonLogin_Click" />
        </div>


    </form>
</body>
</html>
