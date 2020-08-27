<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="PL_Orderie.overview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Overview</title>
        <link rel="stylesheet" href="style.css" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.history.back();">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <h1>
        Overview
    </h1>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button CssClass="button buttonFull" ID="buttonNew" runat="server" Text="New Order" OnClick="buttonNew_Click1" />
        <asp:Button CssClass="button buttonFull" ID="buttonActive" runat="server" Text="Active Order" OnClick="buttonActive_Click" />
        <asp:Button CssClass="button buttonFull" ID="buttonMain" runat="server" Text="Maintenance" OnClick="buttonMain_Click"/>
        <asp:Button CssClass="button buttonFull" ID="buttonLoggout" runat="server" Text="Loggout" OnClick="buttonLoggout_Click" />
    </form>
</body>
</html>
