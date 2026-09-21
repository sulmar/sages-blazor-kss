<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductDetails.aspx.cs"
    Inherits="Training.WebForms.ProductDetails" %>

<!DOCTYPE html>

<html>
<body>
    <form id="form1" runat="server">

        <h1>Produkt</h1>

        <div>
            ID:
            <asp:Label ID="IdLabel" runat="server" />
        </div>

        <div>
            Nazwa:
            <asp:Label ID="NameLabel" runat="server" />
        </div>

        <div>
            Cena:
            <asp:Label ID="PriceLabel" runat="server" />
        </div>

    </form>
</body>
</html>
