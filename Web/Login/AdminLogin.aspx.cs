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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            BLL.AdminManager adminManager = new BLL.AdminManager();
            string Str1 = "adminname='" + txbUserName.Text.Trim() + "'and adminpassword='" + txbPassword.Text + "'and permission='" + 1 + "'";
            DataSet ds1 = adminManager.GetList(Str1);
            string Str2 = "adminname='" + txbUserName.Text.Trim() + "'and adminpassword='" + txbPassword.Text + "'and permission='" + 2 + "'";
            DataSet ds2 = adminManager.GetList(Str2);
            string Str0 = "adminname='" + txbUserName.Text.Trim() + "'and adminpassword='" + txbPassword.Text + "'and permission='" + 0 + "'";
            DataSet ds0 = adminManager.GetList(Str0);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Session["adminname"] = txbUserName.Text.Trim();
                Session["adminpassword"] = ds1.Tables[0].Rows[0]["adminid"].ToString();
                Response.Redirect("~/UserLogin.aspx");
                return;
            }

            else if (ds2.Tables[0].Rows.Count > 0)
                {
                    Session["adminname"] = txbUserName.Text.Trim();
                    Session["adminpassword"] = ds2.Tables[0].Rows[0]["adminid"].ToString();
                    Response.Redirect("~/UserLogin.aspx");
                    return;
                }
            else if (ds0.Tables[0].Rows.Count > 0)
            {
                Session["adminname"] = txbUserName.Text.Trim();
                Session["adminpassword"] = ds0.Tables[0].Rows[0]["adminid"].ToString();
                Response.Redirect("~/Default.aspx");
                return;
            }



            else
            {
                Response.Write("<script language=javascript>alert('用户名不存在或密码错误！');location.href='AdminLogin.aspx'</script>");
                Response.End();
            }
        }
    }
}