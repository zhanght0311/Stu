using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.students
{
    public partial class S_10_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string bianhao = Request.QueryString["bianhao"];
            string mysql = "select zhuanyemingcheng,pingjia,zhidao from Zhuanyefazhan where bianhao=" + bianhao;
            myds = mydb.ExecuteQuery(mysql, "Xuexizongjie");
            Tb_Title.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][0];
            Tb_TaskSummary.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][1];
            Tb_TaskPlan.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][2];
            Tb_Addtime.Text = DateTime.Now.ToString();
            Tb_Ower.Text = Session["uname"].ToString();
            Tb_Title.ReadOnly = true;
            Tb_TaskSummary.ReadOnly = true;
            Tb_TaskPlan.ReadOnly = true;
        }
    }
}