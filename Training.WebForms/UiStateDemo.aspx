<%@ Page Language="C#"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="UiStateDemo.aspx.cs"
    Inherits="Training.WebForms.UiStateDemo" %>

<!DOCTYPE html>
<html>
<body>
    <form id="form1" runat="server">

        <h2>Produkty</h2>

        <asp:Panel ID="LoadingPanel" runat="server">
            Ładowanie...
        </asp:Panel>

        <asp:Panel ID="EmptyPanel" runat="server" Visible="false">
            Brak produktów.
        </asp:Panel>

        <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
            Wystąpił błąd podczas pobierania produktów.
        </asp:Panel>

        <asp:GridView
            ID="ProductsGrid"
            runat="server"
            AutoGenerateColumns="false"
            Visible="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nazwa" />
                <asp:BoundField DataField="Price" HeaderText="Cena" />
            </Columns>
        </asp:GridView>

        <asp:Button
            ID="RefreshButton"
            runat="server"
            Text="Odśwież"
            OnClick="RefreshButton_Click" />

    </form>
</body>
</html>
