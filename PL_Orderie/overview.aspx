<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="PL_Orderie.overview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="buttonNew" runat="server" Text="New Order" OnClick="buttonNew_Click1" />
        <asp:Button ID="buttonActive" runat="server" Text="Active Order" OnClick="buttonActive_Click" />
        <asp:Button ID="buttonMain" runat="server" Text="Maintenance" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
