﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stud.teacher2
{
    public partial class T2_2 : System.Web.UI.Page
    {
        CommDB mydb = new CommDB();
        DataSet myds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tb_Title.Text = DateTime.Now.ToShortDateString() + "请输入专业名称";
                Tb_Addtime.Text = "请输入学生学号";
                Tb_Ower.Text = DateTime.Now.ToShortDateString();
            }
        }
        protected void Ibt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            string mysql;
            mysql = "select max(convert(int,substring(bianhao,1,len(bianhao)))) from Zhuanyefazhan";
            myds = mydb.ExecuteQuery(mysql, "Zhuanyefazhan");
            //string tmp = (string)myds.Tables["Zhuanyefazhan"].Rows[0][0];
            //int i = Convert.ToInt32(tmp);
            int i = (int)myds.Tables["Zhuanyefazhan"].Rows[0][0];
            i = i + 1;
            mysql = "insert into Zhuanyefazhan values(" + i + "," + Tb_Addtime.Text + ",'"
                + Tb_Title.Text + "','" + Tb_TaskSummary.Text + "','"
                + Tb_TaskPlan.Text + "','" + Tb_Ower.Text + "')";
            if (mydb.ExecuteNonQuery(mysql))
            {
                Response.Write("<script>alert('录入成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('录入失败，请正确输入学号后重试')</script>");

            }
        }
    }
}