using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.students
{

    public partial class S_5_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string mysql;
            string bianhao = Request.QueryString["bianhao"];
            mysql = "update Xueximubiao set judge=1 where bianhao=" + bianhao;
            if (mydb.ExecuteNonQuery(mysql))
            {
                mysql = "update Students_information set judge1=1 where Sno=" + Session["uno"];
                if (mydb.ExecuteNonQuery(mysql))
                {
                    Response.Redirect("S_5.aspx");
                }
                else
                {
                    Response.Write("<script>alert('失败，请重试')</script");
                }
            }
            else
            {
                Response.Write("<script>alert('失败，请重试')</script");
            }
        }
    }
}