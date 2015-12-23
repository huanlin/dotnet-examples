<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="ErrorPageDemo.Content._500" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>糟糕! HTTP 500!</h2>
        <p>自訂語系參數: <%= Application["UserLanguage"] %></p>
        <p>伺服器變數 HTTP_ACCEPT_LANGUAGE: <%= Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"] %></p>
        <p>執行緒 UICulture: <%= System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() %></p>
    </div>
    </form>
</body>
</html>
