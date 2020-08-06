﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addneworder.aspx.cs" Inherits="PL_Orderie.addneworder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <h1>Create a new order</h1>

        <label class="label">Select the table:</label>

        <asp:DropDownList ID="ddTables" runat="server" AutoPostBack="True" DataTextField="tableName" OnSelectedIndexChanged="dropDownSelect">
            
        </asp:DropDownList>

        <label class="label">Products for this order:</label>

        <asp:ListView ID="GVProducts" runat="server" OnItemDeleting="deleteFromOrder">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="products marginLeft">
                <asp:Label ID="lblCat" CssClass="productCategory" runat="server" Text='<%# Eval("productCategory") %>' />
                <asp:Label ID="lblNr" runat="server" Text='<%# Eval("productName") %>' />
                <asp:Label ID="lblTable" CssClass="price" runat="server" Text='<%# Eval("price") %>' />
                <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("currency") %>' />
                <asp:LinkButton ID="buttonDelete" CommandName="Delete"  runat="server" Text='Delete' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>

        <asp:Button CssClass="button" runat="server" Text="Add product ➕" ID="addProduct" OnClick="addProduct_Click" />
        <asp:Button CssClass="button" runat="server" Text="Finish order" ID="finishOrder" OnClick="finishOrder_Click" />
        <asp:Label runat="server" Text="Label" ID="label"></asp:Label>
    </form>
</body>
</html>
