<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AttendanceManagementSystem.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Add Student:
        <br />
        Student Name:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        CGPA:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Student" />
        <br />
        <br />
        Add Faculty:
        Faculty Name:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        Pasword:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Faculty" />
        <br />
        <br />
        Add Student To Course:<br />
        Student ID :
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
&nbsp;<br />
        Course ID:
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        Section ID:<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add" />
    
    </div>
    </form>
</body>
</html>
