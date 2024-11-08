<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head> 
<body>
    <h1>Login</h1>
    <form id="form1" runat="server"> 
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CBRememberMe" runat="server" Text="Remember Me"/>
        </div>
        <div>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </div>
        <div>
            <asp:Label ID="LblError" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register Here</asp:LinkButton>
        </div>
        <div>
            <asp:Literal ID="DebugInfo" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
