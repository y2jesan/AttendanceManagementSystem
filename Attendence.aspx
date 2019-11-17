<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendence.aspx.cs" Inherits="AttendanceManagementSystem.Attendence" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Students List:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="Log Out" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="StudentName" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="StudentCGPA" HeaderText="CGPA" ReadOnly="True" />
                <asp:ButtonField Text="Present" ButtonType="Button" CommandName="present" />
                <asp:ButtonField ButtonType="Button" CommandName="absent" Text="Absent" />
                <asp:BoundField DataField="present" />
                <asp:BoundField DataField="Date" HeaderText="Given Date" />
                <asp:ButtonField ButtonType="Button" CommandName="drop" Text="Drop" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
        <br />
        <asp:Button ID="ButtonLock" runat="server" OnClick="ButtonLock_Click" Text="Lock" />
        <asp:Button ID="ButtonRef" runat="server" OnClick="ButtonRef_Click" Text="Refresh" />
    
        <br />
    
    </div>
    </form>
</body>
</html>
