<%@ Page Language="C#"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="Customers.aspx.cs"
    Inherits="WebFormsApp.Customers" %>

<!DOCTYPE html>

<html>
<body>
<form id="form1" runat="server">

    <h2>Klienci</h2>

    <asp:Button
        ID="RefreshButton"
        runat="server"
        Text="Odśwież"
        OnClick="RefreshButton_Click" />

    <asp:Panel
        ID="LoadingPanel"
        runat="server"
        Visible="false">

        Ładowanie klientów...

    </asp:Panel>

    <asp:Panel
        ID="EmptyPanel"
        runat="server"
        Visible="false">

        Brak klientów.

    </asp:Panel>

    <asp:Panel
        ID="ErrorPanel"
        runat="server"
        Visible="false">

        Nie udało się pobrać klientów.

    </asp:Panel>

    <asp:GridView
        ID="CustomersGrid"
        runat="server"
        AutoGenerateColumns="false">

        <Columns>

            <asp:BoundField
                DataField="Id"
                HeaderText="Id" />

            <asp:BoundField
                DataField="Name"
                HeaderText="Nazwa" />

            <asp:BoundField
                DataField="Email"
                HeaderText="E-mail" />

            <asp:HyperLinkField
                Text="Podgląd"
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="CustomerDetails.aspx?id={0}" />

            <asp:HyperLinkField
                Text="Edytuj"
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="CustomerEdit.aspx?id={0}" />

        </Columns>

    </asp:GridView>

</form>
</body>
</html>
