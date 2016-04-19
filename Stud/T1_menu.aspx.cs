using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud
{

    public partial class T1_menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommDB mydb = new CommDB();
            //test数据
            //Session["uname"] = "test";
            //Session["uno"] = "100001";

            Lb_User.Text = Session["uname"].ToString() + "欢迎您";
            string ID = Session["uno"].ToString();
            //flag = mydb.flag("select * from Authority ", ID);
        }
    }
}