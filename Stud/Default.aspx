<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stud.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生发展档案管理系统</title>
     <link type="text/css" href="Styles/login.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
       <div id="top"></div>
       <div id="bottom">
            <div id="bottom_one"></div>
            <div id="bottom_two">
                <table class="Logintable">
                <tr>
                <td class="Loginspan">用户名</td>
                <td><asp:TextBox ID="Tb_LoginID" runat="server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                <td class="Loginspan">密&nbsp;码</td>
                <td><asp:TextBox ID="Tb_PassWd" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2" align="center"><asp:ImageButton ID="Ibt_Submit" runat="server" 
                        ImageUrl="~/Image/Login/1_11.gif" onclick="Ibt_Submit_Click" /></td></tr>
                    <tr><td colspan="2" align="center"><asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Image/Login/1_12.gif" onclick="Ibt_Submit_Click1" /></td></tr>
                </table>
            </div>
            <div id="bottom_three"></div>
       </div>
    </div>
    </form>
</body>
</html>
