using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_8_1 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bianhao = Request.QueryString["bianhao"];
                string mysql = "select biaoti,mubiaoguihua,mubiaopingjia,Sno from Xueximubiao where bianhao=" + bianhao;
                myds = mydb.ExecuteQuery(mysql, "Xuexizongjie");
                Tb_Title.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][0];
                Tb_TaskSummary.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][1];
                Tb_TaskPlan.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][2];
                Tb_Addtime.Text = (string)myds.Tables["Xuexizongjie"].Rows[0][3];
                Tb_Ower.Text = Session["uname"].ToString();
                Tb_Title.ReadOnly = true;
                Tb_TaskSummary.ReadOnly = true;
                Tb_TaskPlan.ReadOnly = true;
                Tb_Addtime.ReadOnly = true;
            }
        }
    }
}