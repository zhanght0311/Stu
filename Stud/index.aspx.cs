using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud
{
    public partial class Zhuce : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox6.Text = "例：计算机131";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tb1 = TextBox1.Text.Trim();//学号
            string tb2 = TextBox2.Text.Trim();//姓名
            string tb3 = TextBox3.Text.Trim();//再次输入的密码
            string tb4 = TextBox6.Text.Trim();//班级
            string tb5 = TextBox7.Text.Trim();//密码
            int i;
            string mysql, sn = "";
            mysql = "SELECT * FROM Students_information WHERE Sno='" + tb1 + "'";
            i = mydb.Rownum(mysql, "Students_information", ref sn);
            if (i > 0)
            {
                Response.Write("<script>alert('注册失败，此学号已被注册!')</script>");
                return;
            }
            else
            {
                if (tb5.Equals(tb3))
                {
                    string xb;//性别
                    if (RadioButton1.Checked)
                    {
                        xb = "男";
                    }
                    else if (RadioButton2.Checked)
                    {
                        xb = "女";
                    }
                    else
                    {
                        xb = "";
                    }
                    mysql = "insert into Students_information(Sno,Sname,Ssex,school,major,class,judge1,judge2) values('"
                        + tb1 + "','"                 //Sno
                    + tb2 + "','"                 //Sname
                    + xb + "','"                            //Ssex

                    + DropDownList3.SelectedValue + "','"   //school
                    + DropDownList4.SelectedValue + "','"   //major


                    + tb4                //class

                   + "',0,0)";
                    bool b = mydb.ExecuteNonQuery(mysql);
                    if (b)
                    {
                        mysql = "insert into System_login values('" + tb1 + "','" + tb5 + "'," + "0)";
                        b = mydb.ExecuteNonQuery(mysql);
                        if(b)
                        {
                            Response.Write("<script>alert('注册成功，请登录系统!')</script>");
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('注册失败，请查看输入信息是否符合要求!')</script>");
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('注册失败，请查看输入信息是否符合要求!')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('注册失败，两次密码输入不相同!')</script>");
                    return;
                }
            }
        }
    }
}