<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchPanel.ascx.cs" Inherits="Training.WebForms.Controls.SearchPanel" %>

<section>
    <asp:TextBox ID="SearchTextBox" runat="server" />

    <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="Search" />
</section>
