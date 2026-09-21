<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Training.WebForms.ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Products</h1>

            <asp:Repeater ID="ProductsRepeater" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Price</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#: Eval("Id") %></td>
                        <td><%#: Eval("Name") %></td>
                        <td><%#: Eval("Price", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </tbody>
        </table>
                </FooterTemplate>
            </asp:Repeater>

        </main>
    </form>
</body>
</html>
