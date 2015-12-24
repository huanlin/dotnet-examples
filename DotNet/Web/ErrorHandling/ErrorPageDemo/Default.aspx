<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrorPageDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="1234.html">引發 IIS 層級的 404</asp:HyperLink>
        <p> </p>
        <asp:DropDownList ID="ddlLanguagesInSession" runat="server"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Throw Exception" />    
    </div>
    </form>
</body>
</html>
