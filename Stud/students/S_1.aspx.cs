using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.students
{
    public partial class S_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tb_Title.Text = DateTime.Now.ToShortDateString() + Session["uname"].ToString() + "的学习总结";
                Tb_Addtime.Text = DateTime.Now.ToString();
                Tb_Ower.Text = Session["uname"].ToString();
            }
        }

        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "select max(convert(int,substring(bianhao,1,len(bianhao)))) from Xuexizongjie";
            myds = mydb.ExecuteQuery(mysql, "Xuexizongjie");
            //string tmp = (string)myds.Tables["Xuexizongjie"].Rows[0][0];
            //int i = Convert.ToInt32(tmp);
            int i = (int)myds.Tables["Xuexizongjie"].Rows[0][0];
            i = i + 1;
            mysql = "insert into Xuexizongjie values(" + i + "," + Session["uno"] + ",'"
                + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                + Tb_TaskPlan.Text + "','" + Tb_Addtime.Text + "')";
            if (mydb.ExecuteNonQuery(mysql))
            {
                Response.Write("<script>alert('录入成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('录入失败，请重试')</script");

            }
        }
    }
}