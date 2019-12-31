<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmps.aspx.cs" Inherits="startagain.confirmps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Import To Seq Svr" />

            <asp:Button ID="Button1" runat="server" Text="Transfer To Mysql" OnClick="Button2_Click" Width="265px" />
        </div>
    </form>
</body>
</html>
