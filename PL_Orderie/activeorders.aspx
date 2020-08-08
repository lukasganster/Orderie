<%@ page language="C#" autoeventwireup="true" codebehind="activeorders.aspx.cs" inherits="PL_Orderie.activeorders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="table tableHead">
            <span>Nr</span>
            <span>Tablename</span>
            <span>Status</span>
            <span></span>
        </div>
        <asp:ListView ID="GVtables" runat="server" OnSelectedIndexChanging="GVtables_SelectedIndexChanged" SelectionMode="Single">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "active table" : "inactive table" %>' CommandName="Select" >
                <asp:Label ID="lblNr" runat="server" Text='<%# Eval("tableID") %>' />
                <asp:Label ID="lblTable" runat="server" Text='<%# Eval("tableName") %>' />
                <asp:Label ID="lblHasActiveOrdersActive" runat="server"  Text="Active" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "" : "hide" %>' />
                <asp:Label ID="lblHasActiveOrdersEmpty" runat="server"  Text="Empty" CssClass='<%# Eval("hasOrder").ToString() == "True" ? "hide" : "" %>' />
                <asp:LinkButton ID="buttonSelect" CssClass="buttonOrderie" CommandName="Select"  runat="server" Text='View Table' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
