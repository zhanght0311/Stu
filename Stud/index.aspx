<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Stud.Zhuce" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新用户注册</title>
    <link href="link.css" rel="stylesheet" type="text/css" />
    <link href="../link.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 278px;
        }
        .auto-style2 {
            height: 22px;
            width: 278px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" style="border: 1px solid #C0C0C0;  font-family: 微软雅黑; font-size: 14px; color: #464646; position: inherit;" frame="hsides">
            <tr>
            <td colspan="2" style="text-align: center; height: 42px;">
                <strong><span style="font-size: 16pt; color:#464646; font-family:微软雅黑">学生用户注册</span></strong></td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span >学 号</span></strong></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server" Width="91px"></asp:TextBox>
                    &nbsp;&nbsp;
                    
            </tr>
            <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span >姓 名</span></strong></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox2" runat="server" Width="91px"></asp:TextBox>&nbsp;&nbsp;
                   
            </tr>
            <tr>
                <td style="width: 110px; height: 22px; text-align: right;">
                    <strong><span>性 别</span></strong></td>
                <td class="auto-style2">
                    <asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" Font-Size="10pt"
                        GroupName="ssex" Text="男" />
                    &nbsp;
                    <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" Font-Size="10pt"
                        GroupName="ssex" Text="女" /></td>
            </tr>
            
            
             
           
           
            <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span>学 院</span></strong></td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList3" runat="server"  Font-Size="14px" ForeColor="#464646">
                        <asp:ListItem Value="计算机科学与软件学院">计算机科学与软件学院</asp:ListItem>
                       
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span>专 业</span></strong></td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList4" runat="server"  Font-Size="14px" ForeColor="#464646">
                        <asp:ListItem Value="计算机科学与技术">计算机科学与技术</asp:ListItem>
                        <asp:ListItem Value="软件工程">软件工程</asp:ListItem>
                        <asp:ListItem Value="网络工程">网络工程</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span >班 级</span></strong></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox6" runat="server" Width="91px"></asp:TextBox>
                    &nbsp;&nbsp;
                    
            </tr>
             <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span >密 码</span></strong></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" Width="91px"></asp:TextBox>
                    &nbsp;&nbsp;
                    
            </tr>
          <tr>
                <td style="width: 110px; text-align: right;">
                    <strong><span >再次输入密码</span></strong></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="91px"></asp:TextBox>
                    &nbsp;&nbsp;
                    
            </tr>
            <tr>
                <td colspan="2" style="height: 37px"  align="center">
                                    
                    <asp:Button ID="Button1" runat="server" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#8F5A0A" BackColor="#FDDB6F" 
                     BorderColor="#D69E31" BorderStyle="Solid" BorderWidth="1px"
                         OnClick="Button1_Click"  Text="确定" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <input id="Button2" style="border: 1px solid #D69E31; font-weight: bold; font-size: 12pt; font-family: 黑体; color: #8F5A0A; background-color: #FDDB6F;" type="reset" value="重置" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
