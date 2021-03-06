﻿using System;
using System.Collections.Generic;
using System.Data;
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
                string str = "adminname='" + txbUserName.Text.Trim() + "'";
                DataSet ds = admin1.GetList(str);    
                Session["NadminID"] = ds.Tables[0].Rows[0]["adminID"].ToString();
                Session["NadminName"] = txbUserName.Text.Trim();
                Response.Redirect("~/N_Admin/Apply_Permission.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('申请失败！请重试')");
            }
        }
    }
}