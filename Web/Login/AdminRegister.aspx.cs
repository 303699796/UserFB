using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserFB.Web.Login
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            Model.Admin admin = new Model.Admin();
            admin.adminName = txbUserName.Text;
            admin.adminPassword = txbPassword1.Text;
            admin.department = txbDepartment.Text;
            admin.job = txbJob.Text;
            admin.permission = "0";

            BLL.AdminManager admin1 = new BLL.AdminManager();
            bool bo = admin1.Add(admin);

           
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('申请成功！请耐心等待管理员同意')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('申请失败！请重试')");
            }
        }
    }
}