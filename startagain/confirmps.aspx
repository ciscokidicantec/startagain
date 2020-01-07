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
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Drop And Re Create Database And Table" />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Drop  Table Only" />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Delete Table And Repopulate Data" />
            <br />
            <br />
            <br />
            <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="PostCode" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="PostCode" HeaderText="PostCode" ReadOnly="True" SortExpression="PostCode" />
                    <asp:BoundField DataField="In_Use" HeaderText="In_Use" SortExpression="In_Use" />
                    <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                    <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                    <asp:BoundField DataField="Easting" HeaderText="Easting" SortExpression="Easting" />
                    <asp:BoundField DataField="Northing" HeaderText="Northing" SortExpression="Northing" />
                    <asp:BoundField DataField="Grid_Ref" HeaderText="Grid_Ref" SortExpression="Grid_Ref" />
                    <asp:BoundField DataField="County" HeaderText="County" SortExpression="County" />
                    <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />
                    <asp:BoundField DataField="Ward" HeaderText="Ward" SortExpression="Ward" />
                    <asp:BoundField DataField="District_Code" HeaderText="District_Code" SortExpression="District_Code" />
                    <asp:BoundField DataField="Ward_Code" HeaderText="Ward_Code" SortExpression="Ward_Code" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="County_Code" HeaderText="County_Code" SortExpression="County_Code" />
                    <asp:BoundField DataField="Constituency" HeaderText="Constituency" SortExpression="Constituency" />
                    <asp:BoundField DataField="Introduced" HeaderText="Introduced" SortExpression="Introduced" />
                    <asp:BoundField DataField="Dateterminated" HeaderText="Dateterminated" SortExpression="Dateterminated" />
                    <asp:BoundField DataField="Parish" HeaderText="Parish" SortExpression="Parish" />
                    <asp:BoundField DataField="National_Park" HeaderText="National_Park" SortExpression="National_Park" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="Households" HeaderText="Households" SortExpression="Households" />
                    <asp:BoundField DataField="Built_Up_Area" HeaderText="Built_Up_Area" SortExpression="Built_Up_Area" />
                    <asp:BoundField DataField="Built_Up_Sub_Division" HeaderText="Built_Up_Sub_Division" SortExpression="Built_Up_Sub_Division" />
                    <asp:BoundField DataField="Lower_Layer_Super_Output_Area" HeaderText="Lower_Layer_Super_Output_Area" SortExpression="Lower_Layer_Super_Output_Area" />
                    <asp:BoundField DataField="Rural_Urban" HeaderText="Rural_Urban" SortExpression="Rural_Urban" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="Altitude" HeaderText="Altitude" SortExpression="Altitude" />
                    <asp:BoundField DataField="London_Zone" HeaderText="London_Zone" SortExpression="London_Zone" />
                    <asp:BoundField DataField="LSOA_Code" HeaderText="LSOA_Code" SortExpression="LSOA_Code" />
                    <asp:BoundField DataField="Local_Authority" HeaderText="Local_Authority" SortExpression="Local_Authority" />
                    <asp:BoundField DataField="MSOA_Code" HeaderText="MSOA_Code" SortExpression="MSOA_Code" />
                    <asp:BoundField DataField="Middle_Layer_Super_Output_Area" HeaderText="Middle_Layer_Super_Output_Area" SortExpression="Middle_Layer_Super_Output_Area" />
                    <asp:BoundField DataField="Parish_Code" HeaderText="Parish_Code" SortExpression="Parish_Code" />
                    <asp:BoundField DataField="Census_Output_Area" HeaderText="Census_Output_Area" SortExpression="Census_Output_Area" />
                    <asp:BoundField DataField="Constituency_Code" HeaderText="Constituency_Code" SortExpression="Constituency_Code" />
                    <asp:BoundField DataField="Index_Of_Multiple_Deprivation" HeaderText="Index_Of_Multiple_Deprivation" SortExpression="Index_Of_Multiple_Deprivation" />
                    <asp:BoundField DataField="Quality" HeaderText="Quality" SortExpression="Quality" />
                    <asp:BoundField DataField="User_Type" HeaderText="User_Type" SortExpression="User_Type" />
                    <asp:BoundField DataField="Last_Updated" HeaderText="Last_Updated" SortExpression="Last_Updated" />
                    <asp:BoundField DataField="Nearest_Station" HeaderText="Nearest_Station" SortExpression="Nearest_Station" />
                    <asp:BoundField DataField="Distance_To_Station" HeaderText="Distance_To_Station" SortExpression="Distance_To_Station" />
                    <asp:BoundField DataField="Postcode_Area" HeaderText="Postcode_Area" SortExpression="Postcode_Area" />
                    <asp:BoundField DataField="Postcode_District" HeaderText="Postcode_District" SortExpression="Postcode_District" />
                    <asp:BoundField DataField="Police_Force" HeaderText="Police_Force" SortExpression="Police_Force" />
                    <asp:BoundField DataField="Water_Company" HeaderText="Water_Company" SortExpression="Water_Company" />
                    <asp:BoundField DataField="Plus_Code" HeaderText="Plus_Code" SortExpression="Plus_Code" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:postcodetransferConnectionStringmysql %>"
                        ProviderName="<%$ ConnectionStrings:postcodetransferConnectionStringmysql.ProviderName %>" 
                        SelectCommand="SELECT * FROM postcodetransfer.testpostcodetransfer;"></asp:SqlDataSource>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
