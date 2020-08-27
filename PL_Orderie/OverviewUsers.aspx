<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverviewUsers.aspx.cs" Inherits="PL_Orderie.OverviewUsers" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Overview Users</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.location.href = 'Maintenance.aspx'">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <h1>Select user</h1>
    <form id="form1" runat="server">
        <div class="row row-head">
            <span>Username</span>
            <span>Firstname</span>
            <span>Lastname</span>
            <span>Role</span>
        </div>
        <asp:ListView ID="GVUsers" runat="server" OnSelectedIndexChanging="editUser" OnItemDeleting="deleteUser" OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="users row">
                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("username") %>' />
                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("firstName") %>' />
                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("lastName") %>' />
                <asp:Label ID="lblIsMan" runat="server"  Text="Manager" CssClass='<%# Eval("isManager").ToString() == "True" ? "" : "hide" %>' />
                <asp:Label ID="lblIsNoMan" runat="server"  Text="Waiter" CssClass='<%# Eval("isManager").ToString() == "True" ? "hide" : "" %>' />
                <asp:LinkButton ID="buttonSelect" CommandName="Select" CssClass="buttonOrderie" runat="server" Text='Edit' />
                <asp:LinkButton ID="buttonDelete" CommandName="Delete" CssClass="buttonOrderie buttonDelete" runat="server" Text='Delete' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
        <asp:Button CssClass="button primaryButton" runat="server" Text="Create new user" ID="addUser" OnClick="addUser_Click" />
    </form>
</body>
</html>
