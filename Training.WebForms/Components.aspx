<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Components.aspx.cs" Inherits="Training.WebForms.Components" %>


<%@ Register
    Src="~/Controls/CounterDisplay.ascx"
    TagPrefix="training"
    TagName="CounterDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Components</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Components</h1>

            <training:CounterDisplay ID="FirstCounter" runat="server" Title="First counter" Step="1" />
            <training:CounterDisplay ID="SecondCounter" runat="server" Title="Second counter" Step="5" />
        </main>
    </form>
</body>
</html>
