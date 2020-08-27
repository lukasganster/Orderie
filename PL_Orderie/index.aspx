<%@ page language="C#" autoeventwireup="true" codebehind="Index.aspx.cs" inherits="PL_Orderie.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" type="image/x-icon" href="~/ows.ico" />
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
            <h1>
        Login
    </h1>
        <div>
            <asp:Label CssClass="label" ID="labelUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox CssClass="inputFull" ID="textUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" controltovalidate="textUsername" errormessage="Please enter your name!" />
            <br />
            <asp:Label CssClass="label" ID="labelPwd" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox CssClass="inputFull" ID="textPwd" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" controltovalidate="textPwd" errormessage="Please enter your password!" />
            <br />
            <asp:Label ID="labelHint" CssClass="labelHint" runat="server" Text=""></asp:Label>
            <asp:Button CssClass="button buttonFull" ID="buttonLogin" runat="server" Text="Login" OnClick="buttonLogin_Click" />

        </div>


    </form>
</body>
</html>
