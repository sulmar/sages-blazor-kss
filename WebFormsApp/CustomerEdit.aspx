<%@ Page Language="C#"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="CustomerEdit.aspx.cs"
    Inherits="WebFormsApp.CustomerEdit" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Edycja klienta</h2>

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
    </div>

    <asp:Button
        ID="SaveButton"
        runat="server"
        Text="Zapisz"
        OnClick="SaveButton_Click" />

</form>
</body>
</html>
