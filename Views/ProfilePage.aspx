<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header>
        <h1>
        Profile
        </h1>
    </header>
    <div id="Form1">
        <div>
            <asp:Label ID="Username" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTxtBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Email" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="EmailTxtBox" runat="server"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="DropDownGender" runat="server">
                    <asp:ListItem Value ="Male"> Male </asp:ListItem>
                    <asp:ListItem Value ="Female"> Female </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="DOB" runat="server" Text="Date Of Birth"></asp:Label>
            <asp:TextBox ID="DOBTxtBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update"  OnClick="UpdateBtn_Click"/>
        </div>
        <div>
            <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>

     <div id="Form2">
     <div>
        <asp:Label ID="Old_Pass" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPassTxtBox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="Change_Pass1" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="Change_Pass1TxtBox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="Change_Pass2" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="Change_Pass2TxtBox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
     <div>
         <asp:Button ID="Change_PassBtn" runat="server" Text="Change Password" OnClick="Change_PassBtn_Click" />
     </div>
      <div>
         <asp:Label ID="errorLabelPassword" runat="server" Text=""></asp:Label>
     </div>
 </div>


</asp:Content>
