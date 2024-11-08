<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
</head>
<body>
    <h1>Please fill out the information to create an account</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Username" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Pass" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Confirm_Pass" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="Confirm_PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="DropDownGender" runat="server">
                    <asp:ListItem Value ="Male"> Male </asp:ListItem>
                    <asp:ListItem Value ="Female"> Female </asp:ListItem>
            </asp:DropDownList>
        <div>
            <asp:Label ID="DOB" runat="server" Text="Date Of Birth"></asp:Label>
            <asp:Calendar ID="CalendarDOB" runat="server" Text="Date Of Birth">
            </asp:Calendar>
        </div>
         <div>
            <asp:LinkButton ID="LBLogin" runat="server" OnClick="LBLogin_Click">Login Here!</asp:LinkButton>
        </div>
        <div>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
        </div>
        <div>
            <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
