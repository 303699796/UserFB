using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserFB.BLL;
using UserFB.Model;

namespace UserFB.Web.Login
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            BLL.UsersManager bllusersManager = new BLL.UsersManager();
            string strWhere = "username='" + txbUserName.Text.Trim() + "'and password='" + txbPassword.Text + "'";
            DataSet ds = bllusersManager.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
               Session["userID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
               Session["username"] = txbUserName.Text.Trim();
               // Session["password"] = ds.Tables[0].Rows[0]["userid"].ToString();
               
                Response.Redirect("~/Users/Question.aspx");
                return;
            }
            else
            {
                Response.Write("<script language=javascript>alert('用户名不存在或密码错误！');location.href='UserLogin.aspx'</script>");
                Response.End();
            }

        }
    }
}