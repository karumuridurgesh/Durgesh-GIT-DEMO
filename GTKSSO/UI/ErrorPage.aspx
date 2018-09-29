<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="GTKSSO.UI.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
    <div id="divError" runat="server" class="ErrorImage" style="width: 100%;margin-top: 130px; height:288px">
     
        <div style="margin-top: 120px;padding-top: 120px;margin-left:5px">
            <asp:Label ID="lblError" runat="server" style="word-wrap: normal;word-break:break-all;" CssClass="error_label" Width="350px"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
