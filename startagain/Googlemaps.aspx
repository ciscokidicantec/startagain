<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Googlemaps.aspx.cs" Inherits="startagain.Googlemaps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Maps Using Api's</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

<%--            <iframe width="600" height="450" frameborder="0" style="border:0"
                src="https://www.google.com/maps/embed/v1/undefined?origin=...&q=...&destination=...&center=...&zoom=...&key=..." allowfullscreen>

            </iframe> */
--%>

            <iframe width="600" height="450" style="border:0"
            src="https://www.google.com/maps/embed/v1/place?q=place_id:ChIJeae4dglEe0gRDXrxobT7O2Q&key=AIzaSyBaEKsYARxgTwueXy6jgscGXyYZcEwjKsM"></iframe> 


        </div>
    </form>
</body>
</html>
