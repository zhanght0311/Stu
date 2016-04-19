using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_7_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bianhao = Request.QueryString["bianhao"];
                string mysql = "select biaoti,xiangmujianjie,xiangmujiangxiang,Sno from Bisai where bianhao=" + bianhao;
                myds = mydb.ExecuteQuery(mysql, "Xuexizongjie");
                Tb_Title.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][0];
                Tb_TaskSummary.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][1];
                Tb_TaskPlan.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][2];
                Tb_Addtime.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][3];
                Tb_Ower.Text = DateTime.Now.ToString();
                int i = Convert.ToInt32(bianhao);
                Session["test51"] = i;
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "delete from Bisai where bianhao=" + Session["test51"];
            if (mydb.ExecuteNonQuery(mysql))
            {

                mysql = "insert into Bisai values(" + Session["test51"] + ",'" + Tb_Addtime.Text + "','"
                   + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                   + Tb_TaskPlan.Text + "','" + Tb_Ower.Text + "')";
                if (mydb.ExecuteNonQuery(mysql))
                {
                    Response.Write("<script>alert('修改成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败，请重试')</script");

                }
            }
            else
            {
                Response.Write("<script>alert('修改失败，请重试')</script");

            }
        }
    }
}