using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_3 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string mysql;
            mysql = "SELECT Pingjiaxuesheng.bianhao,Students_information.Sname,Pingjiaxuesheng.timu from Pingjiaxuesheng,Students_information where Pingjiaxuesheng.Sno=Students_information.Sno and judge2=1";
            myds = mydb.ExecuteQuery(mysql, "Pingjia");
            GridView1.DataSource = myds.Tables["Pingjia"];
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string mysql;
            mysql = "SELECT Pingjiaxuesheng.bianhao,Students_information.Sname,Pingjiaxuesheng.timu from Pingjiaxuesheng,Students_information where Pingjiaxuesheng.Sno=Students_information.Sno and judge2=1";
            myds = mydb.ExecuteQuery(mysql, "Pingjia");
            GridView1.DataSource = myds.Tables["Pingjia"];
            GridView1.DataBind();
        }
    }
}