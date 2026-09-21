<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="PriceList.aspx.cs"
    Inherits="Training.WebForms.PriceList" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Ustawienia cennika</h2>

    <asp:Label
        runat="server"
        Text="Maksymalna cena:" />

    <asp:TextBox
        ID="MaxPriceTextBox"
        runat="server" />

    <asp:Button
        ID="SaveButton"
        runat="server"
        Text="Zapisz"
        OnClick="SaveButton_Click" />

</form>
</body>
</html>
