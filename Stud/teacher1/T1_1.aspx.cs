using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tb_Title.Text = DateTime.Now.ToShortDateString() + "请输入科研题目";
                Tb_Addtime.Text = "请输入参与者学号";
                Tb_Ower.Text = DateTime.Now.ToShortDateString();
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "select max(bianhao) from Keyan";
            myds = mydb.ExecuteQuery(mysql, "Keyan");
            string tmp = (string)myds.Tables["Keyan"].Rows[0][0];
            int i = Convert.ToInt32(tmp);
            i = i + 1;
            mysql = "insert into Keyan values(" + i + "," + Tb_Addtime.Text + ",'"
                + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                + Tb_TaskPlan.Text + "','" + Tb_Ower.Text + "')";
            if (mydb.ExecuteNonQuery(mysql))
            {
                Response.Write("<script>alert('录入成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('录入失败，请正确输入学号后重试')</script>");

            }
        }
    }
}