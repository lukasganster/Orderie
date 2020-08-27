<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverviewProducts.aspx.cs" Inherits="PL_Orderie.products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Overview Products</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.location.href = 'Maintenance.aspx'">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <h1>Select products</h1>
    <form id="form1" runat="server">
        <div class="row row-head">
            <span style="width:4% !important;""></span>
            <span>Category</span>
            <span>Name</span>
            <span>Price</span>
        </div>
        <asp:ListView ID="GVProducts" runat="server" OnSelectedIndexChanging="editProduct" OnItemDeleting="deleteProduct" OnSelectedIndexChanged="GVProducts_SelectedIndexChanged">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="products">
               <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("imagePath") %>' />
                <asp:Label ID="lblCat" CssClass="productCategory" runat="server" Text='<%# Eval("productCategory") %>' />
                <asp:Label ID="lblNr" runat="server" Text='<%# Eval("productName") %>' />
                <asp:Label ID="lblTable" CssClass="price" runat="server" Text='<%# Eval("price") %>' />
                <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("currency") %>' />
                <asp:LinkButton ID="buttonSelect" CommandName="Select" CssClass="buttonOrderie" runat="server" Text='Edit' />
                <asp:LinkButton ID="buttonDelete" CommandName="Delete" CssClass="buttonOrderie buttonDelete" runat="server" Text='Delete' />
            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>

         
        <asp:Button CssClass="button primaryButton" runat="server" Text="Create new product" ID="addProduct" OnClick="addProduct_Click" />
    </form>
</body>
</html>
