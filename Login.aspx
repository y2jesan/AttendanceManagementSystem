<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AttendanceManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ID : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
    Password : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
        <br />
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        <br />
    </div>
    </form>
</body>
</html>
