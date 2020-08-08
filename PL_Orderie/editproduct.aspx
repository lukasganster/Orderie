<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editproduct.aspx.cs" Inherits="PL_Orderie.editproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Product details</h1>
    <form id="form1" runat="server">
        <asp:Label  ID="label" runat="server" Text="Product id"></asp:Label>
        <asp:Label  runat="server" ID="id"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Product name"></asp:Label>
        <asp:TextBox runat="server" ID="name" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Product category"></asp:Label>
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
        <asp:Label runat="server" Text="Price"></asp:Label>
        <asp:TextBox runat="server" ID="price"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Currency"></asp:Label>
        <asp:DropDownList ID="ddCurrencies" runat="server" OnSelectedIndexChanged="ddCurrencies_SelectedIndexChanged">
            <asp:ListItem Text="EUR" Value="EUR"></asp:ListItem>
            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
            <asp:ListItem Text="GBP" Value="GBP"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button CssClass="button" runat="server" Text="Save" ID="addProduct" OnClick="saveProduct" />
    </form>
</body>
</html>
