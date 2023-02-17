<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="ErrorPageDemo.Content._404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>發生 404 錯誤!</h2>
        <p>自訂語系參數 (使用 Session): <%= Session["UserLanguage"] %></p>
        <p>執行緒 UICulture: <%= System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() %></p>
        <p>伺服器變數 HTTP_ACCEPT_LANGUAGE: <%= Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"] %></p>
    </div>
    </form>
</body>
</html>
