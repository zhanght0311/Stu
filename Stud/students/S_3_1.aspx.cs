using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.students
{
    public partial class S_3_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bianhao = Request.QueryString["bianhao"];
                string mysql = "select biaoti,mubiaoguihua,mubiaopingjia from Xueximubiao where bianhao=" + bianhao;
                myds = mydb.ExecuteQuery(mysql, "Xueximubiao");
                Tb_Title.Text = (string)myds.Tables["Xueximubiao"].Rows[0][0];
                Tb_TaskSummary.Text = (string)myds.Tables["Xueximubiao"].Rows[0][1];
                Tb_TaskPlan.Text = (string)myds.Tables["Xueximubiao"].Rows[0][2];
                Tb_Addtime.Text = DateTime.Now.ToString();
                Tb_Ower.Text = Session["uname"].ToString();
                int i = Convert.ToInt32(bianhao);
                Session["test2"] = i;
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "delete from Xueximubiao where bianhao=" + Session["test2"];
            if (mydb.ExecuteNonQuery(mysql))
            {

                mysql = "insert into Xueximubiao values(" + Session["test1"] + "," + Session["uno"] + ",'"
                   + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                   + Tb_TaskPlan.Text + "','" + Tb_Addtime.Text + "',0)";
                if (mydb.ExecuteNonQuery(mysql))
                {
                    Response.Write("<script>alert('修改成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败，请重试')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('修改失败，请重试')</script>");

            }
        }
    }
}