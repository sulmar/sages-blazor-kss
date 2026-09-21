<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="ErrorDemo.aspx.cs"
    Inherits="WebFormsApp.ErrorDemo" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Obsługa błędów</h2>

    <p>
        Ta część strony działa poprawnie.
    </p>

    <asp:Button
        ID="ErrorButton"
        runat="server"
        Text="Wygeneruj błąd"
        OnClick="ErrorButton_Click" />

    <p>
        Ta część również jest częścią tej samej strony.
    </p>

</form>
</body>
</html>
