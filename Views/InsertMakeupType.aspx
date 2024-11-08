<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMakeupType.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.InsertMakeupType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click"/>

             <div>
                 <h1>Insert MakeupType Page</h1>
                 <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
                 <asp:TextBox ID="NameTB" runat="server"></asp:TextBox><br />
             </div>
            <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
            <asp:Label ID="AlertLbl" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
