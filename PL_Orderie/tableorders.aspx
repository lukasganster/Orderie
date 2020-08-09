
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableOrders.aspx.cs" Inherits="PL_Orderie.tableorders" %>

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
    <form id="form1" runat="server">
        <h1>
           <asp:Label ID="lblNr" runat="server" Text="X"></asp:Label>
        </h1>
        <asp:ListView ID="lvOrders" runat="server" SelectionMode="Single" OnSelectedIndexChanging="lvOrders_Select">
        <ItemTemplate>
            <asp:Panel runat="server" CssClass="orders">
                <asp:Label ID="lblCat"  runat="server" Text='Order with the id:' />
                <asp:Label ID="Label1" CssClass="orderId" runat="server" Text='<%# Eval("orderID") %>' />
                <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("timeOrdered") %>' />
                <asp:LinkButton ID="buttonSelect" CssClass="buttonOrderie floatRight" CommandName="Select"  runat="server" Text='mark as paid' />
                
                <asp:ListView ID="orderProducts" runat="server" DataSource='<%# Eval("products") %>'>
                <ItemTemplate>
                    <asp:Panel runat="server" CssClass="productInOrder">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("productCategory") %>' />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("productName") %>' />
                        <asp:Label ID="lblTable" CssClass="price" runat="server" Text='<%# Eval("price") %>' />
                        <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("currency") %>' />
                    </asp:Panel>
                </ItemTemplate>
                </asp:ListView>

                <asp:Label ID="Label5" CssClass="orderBottom orderUser" runat="server" Text='<%# Eval("user.username") %>' />
                <asp:Label ID="Label4" CssClass="orderSum orderBottom" runat="server" Text='<%# Eval("priceSum") %>' />

            </asp:Panel>
        </ItemTemplate>
        </asp:ListView>
        
    </form>
</body>
</html>
