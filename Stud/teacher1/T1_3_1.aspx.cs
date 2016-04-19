using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_3_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        //string a;
        //int b;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string bianhao = Request.QueryString["bianhao"];
                string mysql = "select timu,neirong,Sno from Pingjiaxuesheng where bianhao=" + bianhao;
                myds = mydb.ExecuteQuery(mysql, "Pingjia");
                Tb_Title.Text = (string)myds.Tables["Pingjia"].Rows[0][0];
                Tb_TaskSummary.Text = (string)myds.Tables["Pingjia"].Rows[0][1];
                //a= (string)myds.Tables["Pingjia"].Rows[0][2];
                Session["test11"] = (string)myds.Tables["Pingjia"].Rows[0][2];
                Tb_Addtime.Text = DateTime.Now.ToString();
                Tb_Ower.Text = Session["uname"].ToString();
                int i = Convert.ToInt32(bianhao);
                //b = i;
                Session["test12"] = i;
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "delete from Pingjiaxuesheng where bianhao=" + Session["test12"];
            if (mydb.ExecuteNonQuery(mysql))
            {

                mysql = "insert into Pingjiaxuesheng values('" + Session["test12"] + "','" + Session["test11"] + "','"
                   + Tb_Title.Text + "','" + Tb_TaskSummary.Text
                   + "','" + Tb_Addtime.Text + "')";
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