<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1>WebFormsApp</h1>
        <p>Punkt odniesienia do ćwiczeń migracji listy, dodawania, edycji i szczegółów klientów.</p>

        <ul>
            <li><a href="Customers.aspx">Klienci</a></li>
            <li><a href="CustomerCreate.aspx">Nowy klient</a></li>
            <li><a href="ErrorDemo.aspx">Obsługa błędów</a></li>
        </ul>
    </main>

</asp:Content>
