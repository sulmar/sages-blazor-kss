<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="JavaScriptDemo.aspx.cs"
    Inherits="Training.WebForms.JavaScriptDemo" %>

<!DOCTYPE html>
<html>
<body>
    <form id="form1" runat="server">

        <h2>JavaScript Demo</h2>

        <asp:Button
            ID="ShowSizeButton"
            runat="server"
            Text="Pokaż rozmiar okna"
            OnClientClick="showWindowSize(); return false;" />

        <p id="windowSize"></p>

        <script>
            function showWindowSize() {
                const width = window.innerWidth;
                const height = window.innerHeight;

                document.getElementById("windowSize").innerText =
                    `Rozmiar: ${width} x ${height}`;
            }
        </script>

    </form>
</body>
</html>
