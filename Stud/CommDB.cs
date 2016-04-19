using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// CommDB 的摘要说明
/// </summary>
public class CommDB
{
    //默认构造函数
    public CommDB()
    { }

    /// <summary>
    /// 执行select并返回行数，主要用于登陆和简单查询
    /// </summary>
    /// <param name="sql">执行的SQL语句</param>
    /// <param name="tname">保存的表名（没用）</param>
    /// <param name="sname">返回第一行第一列值</param>
    /// <returns>SELECT语句执行后记录集中的行数</returns>
    public int Rownum(string sql, string tname, ref string sname)
    {
        int i = 0;
        string mystr = ConfigurationManager.AppSettings["myconnstring"];//连接数据库
        SqlConnection myconn = new SqlConnection();
        myconn.ConnectionString = mystr;
        myconn.Open();
        SqlCommand mycmd = new SqlCommand(sql, myconn);
        SqlDataReader myreader = mycmd.ExecuteReader();
        while (myreader.Read())　　//循环读取信息
        {
            sname = myreader[0].ToString();
            i++;
        }
        myconn.Close();
        return i;

    }

    /// <summary>
    /// 执行SQL语句，返回是否成功执行。主要用于数据更新
    /// </summary>
    /// <param name="sql"></param>
    /// <returns>是否执行成功</returns>
    public Boolean ExecuteNonQuery(string sql)
    {
        string mystr = ConfigurationManager.AppSettings["myconnstring"];
        SqlConnection myconn = new SqlConnection();
        myconn.ConnectionString = mystr;
        myconn.Open();
        SqlCommand mycmd = new SqlCommand(sql, myconn);
        try
        {
            mycmd.ExecuteNonQuery();
            myconn.Close();
        }
        catch
        {
            myconn.Close();
            return false;
        }
        return true;
    }
    /// <summary>
    /// 执行SQL查询语句，返回dataset类型，用于复杂查询
    /// </summary>
    /// <param name="sql">执行的SQL语句</param>
    /// <param name="tname">保存的表名</param>
    /// <returns>dataset类型</returns>
    public DataSet ExecuteQuery(string sql, string tname)
    {
        string mystr = ConfigurationManager.AppSettings["myconnstring"];
        SqlConnection myconn = new SqlConnection();
        myconn.ConnectionString = mystr;
        myconn.Open();
        SqlDataAdapter myda = new SqlDataAdapter(sql, myconn);
        DataSet myds = new DataSet();
        myda.Fill(myds, tname);
        myconn.Close();
        return myds;
    }

}