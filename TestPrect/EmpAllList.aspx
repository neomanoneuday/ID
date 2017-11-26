<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpAllList.aspx.cs" Inherits="TestPrect.EmpAllList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="grdAllList" runat="server"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="PI_Id" HeaderText="EmployeeId" />
            <asp:BoundField DataField="PI_Name" HeaderText="EmployeeName" />
            <asp:BoundField DataField="PI_MobileNo" HeaderText="EmployeeMobile" />
            <asp:BoundField DataField="PI_EmailAddress" HeaderText="EmployeeEmail" />
            <asp:BoundField DataField="PI_PosstionApplyFor" HeaderText="EmployeeAppliedPost" />
            <asp:BoundField DataField="PI_City" HeaderText="EmployeeCity" />
            <asp:BoundField DataField="PI_City" HeaderText="City" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href="Emp_Form.aspx?pid=<%#Eval("PI_Id") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    </div>
    </form>
</body>
</html>
