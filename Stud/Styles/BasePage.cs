using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 万合OA办公系统
{
    public class BasePage:System.Web.UI.Page
    {
        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }
        /// <summary>
        /// 检查页面登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BasePage_Load(object sender,EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        /// <summary>
        /// 查找页面控件
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        protected virtual Dictionary<string, string> FindControls(Control ct)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (Control ctl in ct.Controls)
            {
                if (ctl is TextBox)
                {
                    string Name = ctl.ID.Substring(3, ctl.ID.Length - 3);
                    TextBox tb = (TextBox)ctl;
                    string Value = tb.Text;
                    dic.Add(Name, Value);
                }
            }
            return dic;
        }
        protected virtual void SetDefault(Control Ct)
        {
            foreach (Control cn in Ct.Controls)
            {
                if (cn is TextBox)
                {
                    TextBox tb = (TextBox)cn;
                    tb.Text = string.Empty;
                }
                if (cn is DropDownList)
                {
                    DropDownList Dd = (DropDownList)cn;
                    Dd.Text = "-请选择-";
                }
            }
        }
    }
}