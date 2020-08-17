<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTable.aspx.cs" Inherits="PL_Orderie.EditTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
     <nav>
        <div>
            <span class="back" onclick="window.history.back();">ᐊ</span>
        </div>
        <img src="images/logo.png" />
    </nav>
    <h1>Table details</h1>
    <form id="form1" runat="server">
        <asp:Label  CssClass="label" ID="label" runat="server" Text="Table id"></asp:Label>
        <asp:Label CssClass="labelHint" runat="server" ID="id"></asp:Label>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Table name"></asp:Label>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" controltovalidate="name" errormessage="Please enter a name!" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="name" ErrorMessage="Name the table in this format: tablename number" ValidationExpression="^[a-zA-Z]+\s[0-9]+$"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="name" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Button CssClass="button primaryButton" runat="server" Text="Save" ID="addProduct" OnClick="saveTable" />


    </form>
</body>
</html>
