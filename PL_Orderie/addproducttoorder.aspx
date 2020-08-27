<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProductToOrder.aspx.cs" Inherits="PL_Orderie.addproducttoorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Add Product to Order</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.location.href = 'AddNewOrder.aspx'">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <form id="form1" runat="server">
        
        <h1>Add product to order</h1>
        <asp:ListView ID="GVProductsAv" runat="server" SelectionMode="Single" OnSelectedIndexChanging="chooseFromProducts">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="products">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("imagePath") %>' />
                <asp:Label ID="lblCat" CssClass="productCategory" runat="server" Text='<%# Eval("productCategory") %>' />
                <asp:Label ID="lblNr" runat="server" Text='<%# Eval("productName") %>' />
                <asp:Label ID="lblTable" CssClass="price" runat="server" Text='<%# Eval("price") %>' />
                <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("currency") %>' />
                <asp:LinkButton ID="buttonSelect" CommandName="Select" CssClass="buttonOrderie" runat="server" Text='Choose' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
