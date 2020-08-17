<%@ page language="C#" autoeventwireup="true" codebehind="ActiveOrders.aspx.cs" inherits="PL_Orderie.activeorders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <form id="form1" runat="server">
        <asp:ListView ID="LVtables" runat="server" OnSelectedIndexChanging="GVtables_SelectedIndexChanged" SelectionMode="Single">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "active table" : "inactive table" %>' CommandName="Select" >
                <asp:Label ID="lblTable" runat="server" CssClass="doubleRow" Text='<%# Eval("tableName") %>' />
                <asp:Label ID="lblHasActiveOrdersActive" runat="server"  Text="Active" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "doubleRow" : "hide" %>' />
                <asp:Label ID="lblHasActiveOrdersEmpty" runat="server"  Text="Empty" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "hide" : "doubleRow" %>' />
                <asp:LinkButton ID="buttonSelect" CssClass="buttonOrderie" CommandName="Select"  runat="server" Text='View Table' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
