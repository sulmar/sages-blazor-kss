<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Training.WebForms.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Products</h1>

            <p>
                <a href="ProductCreate.aspx">Nowy produkt</a>
                <a href="PriceList.aspx">Ustawienia cennika</a>
            </p>

            <asp:GridView ID="ProductsGrid"
                          runat="server"
                          AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Nazwa" />
                    <asp:BoundField DataField="Price" HeaderText="Cena" />

                    <asp:HyperLinkField
                        Text="Podgląd"
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="ProductDetails.aspx?id={0}" />

                    <asp:HyperLinkField
                        Text="Edytuj"
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="ProductEdit.aspx?id={0}" />
                </Columns>
            </asp:GridView>
        </main>
    </form>
</body>
</html>
