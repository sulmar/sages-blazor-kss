<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductEdit.aspx.cs"
    Inherits="Training.WebForms.ProductEdit" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h1>Edycja produktu</h1>

    <div>
        Nazwa:
        <asp:TextBox ID="NameTextBox" runat="server" />
    </div>

    <div>
        Cena:
        <asp:TextBox ID="PriceTextBox" runat="server" />
    </div>

    <asp:Button ID="SaveButton"
                runat="server"
                Text="Zapisz"
                OnClick="SaveButton_Click" />

</form>
</body>
</html>
