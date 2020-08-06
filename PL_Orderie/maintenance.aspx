<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="maintenance.aspx.cs" Inherits="PL_Orderie.maintenance" %>

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
            <asp:Button ID="buttonEditUsers" runat="server" Text="Users" />
            <asp:Button ID="buttonEditTables" runat="server" Text="Tables" />
            <asp:Button ID="buttonEditProducts" runat="server" Text="Products" />
        </div>
    </form>
</body>
</html>
