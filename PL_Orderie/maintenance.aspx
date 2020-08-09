﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="PL_Orderie.maintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        Maintenance
    </h1>
    <form id="form1" runat="server">
        <div>
            <asp:Button CssClass="button buttonFull" ID="buttonEditUsers" runat="server" Text="Users" />
            <asp:Button CssClass="button buttonFull" ID="buttonEditTables" runat="server" Text="Tables" />
            <asp:Button CssClass="button buttonFull" ID="buttonEditProducts" runat="server" Text="Products" OnClick="buttonEditProducts_Click" />
        </div>
    </form>
</body>
</html>
