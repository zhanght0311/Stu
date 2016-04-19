<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passwd.aspx.cs" Inherits="Stud.passwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <table align="center" style="border: 0px solid #C0C0C0; font-family: 微软雅黑; font-size: 14px; color: #464646; position: inherit; top: 20px; bottom: 20px; width: 412px;">
            <tr>
                <td colspan="2" style="height: 39px; text-align: center">
                    <strong><span style="font-size:16px">修改密码</span></strong></td>
                <td colspan="1" style="width: 224px; height: 39px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right">
                    <span ><strong>原密码</strong></span></td>
                <td style="font-size: 12pt; width: 143px">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="118px" ></asp:TextBox></td>
                <td style="font-size: 12pt; width: 224px; color: red">
                    
            </tr>
            <tr >
                <td style="width: 100px; text-align: right">
                    <span style="font-size: 10pt"><strong>新密码</strong></span></td>
                <td style="width: 143px; color: #000000">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="117px"></asp:TextBox></td>
                <td style="width: 224px; color: red">
            </tr>
            <tr >
                <td style="width: 100px; text-align: right">
                    <span ><strong>重复一次</strong></span></td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="116px"></asp:TextBox></td>
                <td style="width: 224px; color: red;">
                   
            </tr>
            <tr>
                <td colspan="2" align ="center">
                     
                        <asp:Button ID="Button1" runat="server"  
                     Font-Bold="True" Font-Size="12pt" ForeColor="#8F5A0A"  
                     BorderColor="#D69E31" BorderStyle="Solid" BorderWidth="0px"
                            OnClick="Button1_Click" Text="提交" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <input type="reset" id="Button2"
                    value="重置" style="border: 0px solid #D69E31; font-weight: bold; font-size: 12pt; font-family: 黑体; color: #8F5A0A; " />
            </td>
            </tr>
           
        </table>
    </form>
</body>
</html>
