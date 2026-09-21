<%@ Page Language="C#"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="CustomerCreate.aspx.cs"
    Inherits="WebFormsApp.CustomerCreate" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Nowy klient</h2>

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
            AssociatedControlID="EmailTextBox"
            Text="E-mail:" />

        <asp:TextBox
            ID="EmailTextBox"
            runat="server" />

        <asp:RequiredFieldValidator
            runat="server"
            ControlToValidate="EmailTextBox"
            ErrorMessage="E-mail jest wymagany"
            ForeColor="Red" />

        <asp:RegularExpressionValidator
            runat="server"
            ControlToValidate="EmailTextBox"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            ErrorMessage="Nieprawidłowy adres e-mail"
            ForeColor="Red" />
    </div>

    <asp:Button
        ID="SaveButton"
        runat="server"
        Text="Dodaj klienta"
        OnClick="SaveButton_Click" />

</form>
</body>
</html>
