<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CounterDisplay.ascx.cs" Inherits="Training.WebForms.Controls.CounterDisplay" %>

<section>
    <h2>
        <asp:Literal ID="TitleLiteral" runat="server" Mode="Encode" />
    </h2>

    <p role="status">
        Current count:       
        <asp:Label ID="CurrentCountLabel" runat="server" Text="0" />
    </p>

    <asp:Button ID="IncrementButton" runat="server" OnClick="IncrementCount" />
</section>
