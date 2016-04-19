<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S_9.aspx.cs" Inherits="Stud.students.S_9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Styles/css1.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table align="center" style="border: 0px solid #C0C0C0; font-family: 微软雅黑; font-size: 14px; color: #464646; position: inherit;">
            <tr>
                <td style="width: 456px; height: 40px; text-align: center ">
                    <strong><span style="font-size: 16pt;">导师评价查询</span></strong></td>
            </tr>
        </table>
   </div>
       
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None"  Font-Names="微软雅黑" Font-Size="Small" Height="10px" HorizontalAlign="Center" Width="1000px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="bianhao" HeaderText="编号" ReadOnly="True" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="timu" HeaderText="标题" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="tianjiashijian" HeaderText="添加时间" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:HyperLinkField HeaderText="操作" Text="查看"
                    DataNavigateUrlFields="bianhao"
                     DataNavigateUrlFormatString="S_9_1.aspx?bianhao={0}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:HyperLinkField>
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
             
   

         </form>
</body>
</html>
