<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ini.aspx.cs" Inherits="startagain.ini" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="imageindex" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="imageindex" HeaderText="imageindex" ReadOnly="True" SortExpression="imageindex" />
                    <asp:BoundField DataField="myguid" HeaderText="myguid" SortExpression="myguid" />
                    <asp:BoundField DataField="originalfilename" HeaderText="originalfilename" SortExpression="originalfilename" />
                    <asp:BoundField DataField="imagesizeKbytes" HeaderText="imagesizeKbytes" SortExpression="imagesizeKbytes" />
                    <asp:BoundField DataField="savedondiskfilename" HeaderText="savedondiskfilename" SortExpression="savedondiskfilename" />
                    <asp:BoundField DataField="inserteddate" HeaderText="inserteddate" SortExpression="inserteddate" />
                    <asp:BoundField DataField="postalcodeplace" HeaderText="postalcodeplace" SortExpression="postalcodeplace" />
                </Columns>
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:estateporrtalConnectionString %>" ProviderName="<%$ ConnectionStrings:estateporrtalConnectionString.ProviderName %>" SelectCommand="SELECT * FROM images"></asp:SqlDataSource>
        </p>
        <div>
        </div>
    </form>
</body>
</html>
