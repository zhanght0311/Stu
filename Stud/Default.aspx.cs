using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud
{
    public partial class Login : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            int i;
            string uname = "";
            string tb1 = Tb_LoginID.Text.Trim();
            string tb2 = Tb_PassWd.Text.Trim();
            //输入是否符合格式
            if (tb1.Length > 6 || tb2.Length > 18)
            {
                Response.Write("<script>alert('输入过长')</script>");
            }
            else
            {
                //查询登陆用户
                mysql = "SELECT judge FROM System_login WHERE account = '" + tb1 + "' AND password = '" + tb2 + "'";
                i = mydb.Rownum(mysql, "System_login", ref uname);
                if (i > 0)
                {
                    if (uname.Equals("0"))
                    {
                        //Response.Write("<script>alert('学生你好!')</script>");
                        //保存编号
                        Session["uno"] = tb1;
                        //获取并保存姓名
                        mysql = "SELECT Sname FROM Students_information WHERE Sno='" + tb1 + "'";
                        mydb.Rownum(mysql, "Students_information", ref uname);
                        Session["uname"] = uname;
                        //跳转
                        //Server.Transfer("~/S_menu.aspx");
                        Response.Redirect("S_menu.aspx");
                    }
                    else if (uname.Equals("1"))
                    {
                        //Response.Write("<script>alert('辅导员你好!')</script>");
                        //保存编号
                        Session["uno"] = tb1;
                        //获取并保存姓名
                        mysql = "SELECT Tname FROM Teacher WHERE Tno='" + tb1 + "'";
                        mydb.Rownum(mysql, "Teacher", ref uname);
                        Session["uname"] = uname;
                        //跳转
                        //Server.Transfer("~/T_menu.aspx");
                        Response.Redirect("T1_menu.aspx");
                    }
                    else if (uname.Equals("2"))
                    {   //专业导师
                        //保存编号
                        Session["uno"] = tb1;
                        //获取并保存姓名
                        mysql = "SELECT Tname FROM Teacher WHERE Tno='" + tb1 + "'";
                        mydb.Rownum(mysql, "Admin", ref uname);
                        Session["uname"] = uname;
                        //跳转
                        //Server.Transfer("~/M_menu.aspx");
                        Response.Redirect("T2_menu.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('对不起，你输入的用户名或者密码错误，请查实!')</script>");
                }

            }
        }
        protected void Ibt_Submit_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
