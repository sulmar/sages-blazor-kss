<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Counter.aspx.cs" Inherits="Training.WebForms.Counter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Counter</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1>Counter</h1>

            <p role="status">Current Count: <asp:Label ID="CurrentCountLabel" runat="server" Text="0" /></p>

            <asp:Button ID="IncrementCountButton" runat="server" Text="Click me" OnClick="IncrementCount" />
        </main>
    </form>
</body>
</html>
