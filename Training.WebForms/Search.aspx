<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Training.WebForms.Search" %>

<%@ Register Src="~/Controls/SearchPanel.ascx" TagPrefix="training" TagName="SearchPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Search</h1>

            <training:SearchPanel ID="SearchPanel" runat="server" OnValueChanged="SearchValueChanged" />

            <p>
                Search value:
                <asp:Label ID="SearchValueLabel" runat="server" />
            </p>
        </main>
    </form>
</body>
</html>
