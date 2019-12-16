<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ini.aspx.cs" Inherits="startagain.ini" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1429px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="postcode" DataValueField="codeareadescription">
            </asp:DropDownList>
    </p>
        <p class="auto-style1">
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="codeareadescription" DataValueField="postcode" Width="458px"></asp:ListBox>
    </p>
        <p class="auto-style1">
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="indexpostcode" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="indexpostcode" HeaderText="indexpostcode" ReadOnly="True" SortExpression="indexpostcode" />
                    <asp:BoundField DataField="postcode" HeaderText="postcode" SortExpression="postcode" />
                    <asp:BoundField DataField="codeareadescription" HeaderText="codeareadescription" SortExpression="codeareadescription" />
                </Columns>
            </asp:GridView>
    </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:estateporrtalConnectionStringpostcode %>" ProviderName="<%$ ConnectionStrings:estateporrtalConnectionStringpostcode.ProviderName %>" SelectCommand="select * from postcodes"></asp:SqlDataSource>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="imageindex" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
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
