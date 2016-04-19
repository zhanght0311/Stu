using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_8 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string mysql;
            mysql = "SELECT bianhao,biaoti,Sno from Xueximubiao";

            myds = mydb.ExecuteQuery(mysql, "Score");
            GridView1.DataSource = myds.Tables["Score"];
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string mysql;
            mysql = "SELECT bianhao,biaoti,Sno from Xueximubiao";
            myds = mydb.ExecuteQuery(mysql, "Score");
            GridView1.DataSource = myds.Tables["Score"];
            GridView1.DataBind();
        }
    }
}