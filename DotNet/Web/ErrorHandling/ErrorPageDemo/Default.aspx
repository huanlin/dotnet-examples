<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrorPageDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Throw Exception" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="1234.html">引發 IIS 層級的 404</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
