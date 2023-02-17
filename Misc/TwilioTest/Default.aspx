<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TwilioTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Twilio Test</h2>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SendMsg.aspx">Send message</asp:HyperLink>
            <br />
            <br />
            Recent 20 received messages:
        <asp:Button ID="btnLoadReceivedMsg" runat="server" OnClick="btnLoadReceivedMsg_Click" Text="Refresh" Width="97px" />
            <br />
            <asp:ListBox ID="lbxMsg" runat="server" Height="266px" Width="601px" AutoPostBack="True" OnSelectedIndexChanged="lbxMsg_SelectedIndexChanged"></asp:ListBox>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upnlMsg" runat="server">
            <ContentTemplate>
                <div style="width: 600px; display:inline-block;">
                    <asp:Label ID="lblMsgContent" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger runat="server" ControlID="lbxMsg" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
