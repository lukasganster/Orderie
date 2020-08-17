<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PL_Orderie.EditUser" %>

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
    <h1>User details</h1>
    <form id="form1" runat="server">
        <asp:Label  CssClass="label" ID="label" runat="server" Text="User id"></asp:Label>
        <asp:Label CssClass="labelHint" runat="server" ID="id"></asp:Label>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Username"></asp:Label>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" controltovalidate="username" errormessage="Please enter a name!" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="username" ErrorMessage="Please enter only characters!" ValidationExpression="[a-zA-Z]+[ a-zA-Z-_]"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="username" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Firstname"></asp:Label>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" controltovalidate="firstname" errormessage="Please enter a name!" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="firstname" ErrorMessage="Please enter only characters!" ValidationExpression="[a-zA-Z]+[ a-zA-Z-_]"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="firstname" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Lastname"></asp:Label>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" controltovalidate="lastname" errormessage="Please enter a name!" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="lastname" ErrorMessage="Please enter only characters!" ValidationExpression="[a-zA-Z]+[ a-zA-Z-_]"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="lastname" MinLength="3" ValidationMessage="not valid"></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" Text="Role"></asp:Label>
        <asp:DropDownList ID="ddIsManager" runat="server" AutoPostBack="True" >
            <asp:ListItem Text="Manager" Value="Manager"></asp:ListItem>
            <asp:ListItem Text="Waiter" Value="Waiter"></asp:ListItem>
        </asp:DropDownList>
        <br />
     
        <asp:Label CssClass="label" runat="server" Text="Password and confirmation (Omit the field if the password is not to be changed)"></asp:Label>
          <asp:TextBox id="password" runat="server"
              TextMode="Password" />
          <!-- <asp:RequiredFieldValidator id="passwordReq"
              runat="server"
              ControlToValidate="password"
              ErrorMessage="Password is required!"
              SetFocusOnError="True" Display="Dynamic" /> -->
          <asp:TextBox id="confirmPasswordTextBox" runat="server"
              TextMode="Password" />
        <!--
          <asp:RequiredFieldValidator id="confirmPasswordReq"
              runat="server" 
              ControlToValidate="confirmPasswordTextBox"
              ErrorMessage="Password confirmation is required!"
              SetFocusOnError="True" 
              Display="Dynamic" />
        -->
          <asp:CompareValidator id="comparePasswords" 
              runat="server"
              ControlToCompare="password"
              ControlToValidate="confirmPasswordTextBox"
              ErrorMessage="Your passwords do not match up!"
              Display="Dynamic" />

        <br />
        <asp:Label ID="labelPassword" runat="server" Text="Label"></asp:Label>
        <asp:Button CssClass="button primaryButton" runat="server" Text="Save" ID="addProduct" OnClick="saveUser" />


    </form>
</body>
</html>
