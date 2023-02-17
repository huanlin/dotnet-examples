<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMsg.aspx.cs" Inherits="TwilioTest.SendMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .label span {
            display: inline-block; 
            width: 120px;
            vertical-align: text-top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="label">
        <span>Account Sid: </span><asp:TextBox ID="txtAccSid" runat="server" Width="294px">AC0692381d260a639ebc78d82e0941af92</asp:TextBox><br />
        <span>Auth. token: </span><asp:TextBox ID="txtAuthToken" runat="server" Width="294px">94639f002cd4fa05f7b37ac99cf3cd06</asp:TextBox><br />
        <span>From: </span><asp:TextBox ID="txtFrom" runat="server">+13478972288</asp:TextBox><br />
        <span>To: </span><asp:TextBox ID="txtTo" runat="server">+886936681639</asp:TextBox><br />
        <span>Message: </span><asp:TextBox ID="txtMsg" runat="server" Width="471px" Height="54px" TextMode="MultiLine"></asp:TextBox><br /><br />
        <span>&nbsp;</span><asp:Button ID="Button1" runat="server" Text="Send message" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
