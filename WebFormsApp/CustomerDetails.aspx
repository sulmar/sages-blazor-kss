<%@ Page Language="C#"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="CustomerDetails.aspx.cs"
    Inherits="WebFormsApp.CustomerDetails" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Klient</h2>

    <asp:Panel
        ID="LoadingPanel"
        runat="server"
        Visible="false">

        Ładowanie...

    </asp:Panel>

    <asp:Panel
        ID="NotFoundPanel"
        runat="server"
        Visible="false">

        Nie znaleziono klienta.

    </asp:Panel>

    <asp:Panel
        ID="ErrorPanel"
        runat="server"
        Visible="false">

        Nie udało się pobrać danych.

        <asp:Button
            ID="RetryButton"
            runat="server"
            Text="Spróbuj ponownie"
            OnClick="RetryButton_Click" />

    </asp:Panel>

    <asp:Panel
        ID="CustomerPanel"
        runat="server"
        Visible="false">

        <div>
            Nazwa:
            <asp:Label ID="NameLabel" runat="server" />
        </div>

        <div>
            E-mail:
            <asp:Label ID="EmailLabel" runat="server" />
        </div>

    </asp:Panel>

</form>
</body>
</html>
