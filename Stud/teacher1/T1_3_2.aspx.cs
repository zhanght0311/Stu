using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_3_2 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        //string xuehao;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bianhao = Request.QueryString["Sno"];
                Session["test10"] = bianhao;
                Tb_Title.Text = bianhao + "的学习评价";
                Tb_TaskSummary.Text = "请输入内容";
                Tb_Addtime.Text = DateTime.Now.ToString();
                Tb_Ower.Text = Session["uname"].ToString();
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "select max(convert(int,substring(bianhao,1,len(bianhao)))) from Pingjiaxuesheng";
            myds = mydb.ExecuteQuery(mysql, "Ping");
            //string tmp = (string)myds.Tables["Ping"].Rows[0][0];
            //int i = Convert.ToInt32(tmp);
            int i = (int)myds.Tables["Ping"].Rows[0][0];
            i = i + 1;
            mysql = "insert into Pingjiaxuesheng values(" + i + ",'" + Session["test10"] + "','"
                       + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                       + Tb_Addtime.Text + "')";
            if (mydb.ExecuteNonQuery(mysql))
            {
                mysql = "update Students_information set judge2=1 where Sno='" + Session["test10"] + "'";
                if (mydb.ExecuteNonQuery(mysql))
                {
                    Response.Write("<script>alert('录入成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('录入失败，请重试')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('录入失败，请重试')</script>");

            }
        }
    }
}