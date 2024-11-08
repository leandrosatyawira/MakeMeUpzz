<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order History</h1>
        <asp:Label ID="RoleLbl" runat="server" Text="UserRole" Font-Size="28px" Font-Bold="true" ></asp:Label>
    </div>
    <div>
        <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False" OnRowCommand="TransactionGV_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" Visible="false"/>
                <asp:BoundField DataField="User.Username" HeaderText="Username" SortExpression="User.Username" Visible="false"/>
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                
                <asp:ButtonField ButtonType="Button" CommandName="Details" HeaderText="View Details" ShowHeader="True" Text="Details" />
                
                
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
