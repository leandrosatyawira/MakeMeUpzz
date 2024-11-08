<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="Homepageaspx.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.Homeaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1>
            HomePage
        </h1>
    </header>
    <div>
        <asp:Label ID="LblLoggedInUser" runat="server" Text="Welcome, User!" Visible="false"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="false">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="Date of Birth" SortExpression="UserDOB" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
                <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
            </Columns>
        </asp:GridView> 
    </div>
</asp:Content>
