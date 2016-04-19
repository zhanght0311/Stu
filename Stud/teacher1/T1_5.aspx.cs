using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher1
{
    public partial class T1_5 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string mysql;
            mysql = "SELECT Sno,Sname from Students_information where judge1=0";
            myds = mydb.ExecuteQuery(mysql, "Ziping");
            GridView1.DataSource = myds.Tables["Ziping"];
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string mysql;
            mysql = "SELECT Sno,Sname from Students_information where judge1=0";
            myds = mydb.ExecuteQuery(mysql, "Ziping");
            GridView1.DataSource = myds.Tables["Ziping"];
            GridView1.DataBind();
        }
    }
}