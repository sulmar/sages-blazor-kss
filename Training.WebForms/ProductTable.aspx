<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTable.aspx.cs" Inherits="Training.WebForms.ProductTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Products</h1>

            <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="false" EmptyDataText="No products">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </main>
    </form>
</body>
</html>
