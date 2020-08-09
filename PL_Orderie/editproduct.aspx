﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="PL_Orderie.editproduct" %>

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
    <h1>Product details</h1>
    <form id="form1" runat="server">
        <asp:Label  CssClass="label" ID="label" runat="server" Text="Product id"></asp:Label>
        <asp:Label CssClass="labelHint" runat="server" ID="id"></asp:Label>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Product name"></asp:Label>
        <asp:TextBox runat="server" ID="name" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Product category"></asp:Label>
        <asp:DropDownList ID="ddCategories" runat="server" OnSelectedIndexChanged="categorySelect" AutoPostBack="True" >
            <asp:ListItem Text="Drink" Value="Drink"></asp:ListItem>
            <asp:ListItem Text="Hot Drink" Value="HotDrink"></asp:ListItem>
            <asp:ListItem Text="Breakfast" Value="Breakfast"></asp:ListItem>
            <asp:ListItem Text="Soup" Value="Soup"></asp:ListItem>
            <asp:ListItem Text="Salad" Value="Salad"></asp:ListItem>
            <asp:ListItem Text="Appetizers" Value="Appetizers"></asp:ListItem>
            <asp:ListItem Text="Main Dish" Value="MainDish"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Price"></asp:Label>
        <asp:TextBox runat="server" ID="price"></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Currency"></asp:Label>
        <asp:DropDownList ID="ddCurrencies" runat="server" OnSelectedIndexChanged="ddCurrencies_SelectedIndexChanged">
            <asp:ListItem Text="EUR" Value="EUR"></asp:ListItem>
            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
            <asp:ListItem Text="GBP" Value="GBP"></asp:ListItem>
        </asp:DropDownList>
        <br />


        <asp:FileUpload id="FileUploadControl" runat="server" />
        <asp:Button CssClass="fileSubmit" runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
        <br /><br />
        <asp:Label CssClass="labelHint" runat="server" id="StatusLabel" text="Upload status: not uploaded yet." />
        <asp:Button CssClass="button" runat="server" Text="Save" ID="addProduct" OnClick="saveProduct" />


    </form>
</body>
</html>
