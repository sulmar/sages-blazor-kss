<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductEditValidation.aspx.cs"
    Inherits="Training.WebForms.ProductEditValidation" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h1>Edycja produktu — walidacja</h1>

    <asp:ValidationSummary
        runat="server"
        HeaderText="Popraw następujące błędy:" />

    <asp:TextBox ID="NameTextBox"
                 runat="server" />

    <asp:RequiredFieldValidator
        runat="server"
        ControlToValidate="NameTextBox"
        ErrorMessage="Nazwa jest wymagana"
        ForeColor="Red" />

    <br />

    <asp:TextBox ID="PriceTextBox"
                 runat="server" />

    <asp:RequiredFieldValidator
        runat="server"
        ControlToValidate="PriceTextBox"
        ErrorMessage="Cena jest wymagana"
        ForeColor="Red" />

    <asp:RangeValidator
        runat="server"
        ControlToValidate="PriceTextBox"
        Type="Double"
        MinimumValue="0.01"
        MaximumValue="1000000"
        ErrorMessage="Cena musi być większa od 0"
        ForeColor="Red" />

    <br />

    <asp:Button ID="SaveButton"
                runat="server"
                Text="Zapisz"
                OnClick="SaveButton_Click" />

</form>
</body>
</html>
