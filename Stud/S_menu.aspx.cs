using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud
{

    public partial class S_menu : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        protected bool[] flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            //test数据
            //Session["uname"] = "test";
            //Session["uno"] = "100001";

            Lb_User.Text = Session["uname"].ToString() + "欢迎您";
            string ID = Session["uno"].ToString();
            //flag = mydb.flag("select * from Authority ", ID);
        }
    }
}