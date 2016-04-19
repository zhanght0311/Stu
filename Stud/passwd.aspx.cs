using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud
{
    public partial class passwd : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mysql, sn = "";
            string t2 = TextBox2.Text.Trim();
            string t3 = TextBox3.Text.Trim();
            int i;
            mysql = "SELECT * FROM System_login WHERE account='" + Session["uno"] + "' AND password='" + TextBox1.Text.Trim() + "'";
            i = mydb.Rownum(mysql, "teacher", ref sn);
            if (i == 0)
                // Server.Transfer("~/dispinfo.aspx?info=原密码输入错误!");
                Response.Write("<script>alert('原密码输入错误!')</script>");
            else
            {
                if (t2.Equals(t3))
                {
                    mysql = "UPDATE System_login SET password='" + TextBox2.Text.Trim() + "' WHERE account='" + Session["uno"] + "'";
                    mydb.ExecuteNonQuery(mysql);
                    //Server.Transfer("~/dispinfo.aspx?info=密码修改成功!");
                    Response.Write("<script>alert('密码修改成功!')</script>");
                }
                else
                {
                    // Server.Transfer("~/dispinfo.aspx?info=两次密码输入不想等，请重新输入!");
                    Response.Write("<script>alert('两次密码输入不想等，请重新输入!')</script>");
                }
            }
        }
    }
}