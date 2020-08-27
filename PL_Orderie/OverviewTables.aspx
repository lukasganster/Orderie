<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverviewTables.aspx.cs" Inherits="PL_Orderie.OverviewTables" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Overview Tables</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.location.href = 'Maintenance.aspx'">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <h1>Select table</h1>
    <form id="form1" runat="server">
        <div class="row row-head">
            <span class="doubleRow">Table ID</span>
            <span class="doubleRow">Table name</span>
        </div>
        <asp:ListView ID="GVTables" runat="server" OnSelectedIndexChanging="editTable" OnItemDeleting="deleteTable" OnSelectedIndexChanged="GVTables_SelectedIndexChanged">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="tables row">
                <asp:Label ID="lblId" CssClass="doubleRow" runat="server" Text='<%# Eval("tableID") %>' />
                <asp:Label ID="lblName" CssClass="doubleRow" runat="server" Text='<%# Eval("tableName") %>' />
                <asp:LinkButton ID="buttonSelect" CommandName="Select" CssClass="buttonOrderie" runat="server" Text='Edit' />
                <asp:LinkButton ID="buttonDelete" CommandName="Delete" CssClass="buttonOrderie buttonDelete" runat="server" Text='Delete' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
        <asp:Button CssClass="button primaryButton" runat="server" Text="Create new table" ID="addTable" OnClick="addTable_Click" />
    </form>
</body>
</html>
