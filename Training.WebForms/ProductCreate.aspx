<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductCreate.aspx.cs"
    Inherits="Training.WebForms.ProductCreate" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Nowy produkt</h2>

    <div>
        <asp:Label
            runat="server"
            AssociatedControlID="NameTextBox"
            Text="Nazwa:" />

        <asp:TextBox
            ID="NameTextBox"
            runat="server" />

        <asp:RequiredFieldValidator
            runat="server"
            ControlToValidate="NameTextBox"
            ErrorMessage="Nazwa jest wymagana"
            ForeColor="Red" />
    </div>

    <div>
        <asp:Label
            runat="server"
            AssociatedControlID="PriceTextBox"
            Text="Cena:" />

        <asp:TextBox
            ID="PriceTextBox"
            runat="server" />

        <asp:RequiredFieldValidator
            runat="server"
            ControlToValidate="PriceTextBox"
            ErrorMessage="Cena jest wymagana"
            ForeColor="Red" />
    </div>

    <asp:Button
        ID="SaveButton"
        runat="server"
        Text="Zapisz"
        OnClick="SaveButton_Click" />

</form>
</body>
</html>
