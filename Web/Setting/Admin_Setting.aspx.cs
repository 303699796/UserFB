﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.Setting
{
    public partial class Admin_Setting : System.Web.UI.Page
    {
        Model.Admin admin = new Model.Admin();
        BLL.AdminManager adminManager = new BLL.AdminManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                GetLoginName();
                ApplyNumber();
                ReplyNumber();
            }
        }
        protected void Bind()
        {


            GridView1.DataSource = adminManager.GetAllList();
            GridView1.DataBind();

        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
         

            int adminID=Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Labelid") as Label).Text);
            bool bo = adminManager.Delete(adminID);
            if (bo==true)
            {
                Response.Write("<script language=javascript>alert('删除成功！')</script>");
                Bind();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            admin.adminID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            admin.adminName = (GridView1.Rows[e.RowIndex].FindControl("txtAdmin") as TextBox).Text;
            admin.department = (GridView1.Rows[e.RowIndex].FindControl("txtDepartment") as TextBox).Text;
            admin.job = (GridView1.Rows[e.RowIndex].FindControl("txtJob") as TextBox).Text;
            admin.permission = (GridView1.Rows[e.RowIndex].FindControl("txtPermission") as TextBox).Text;
            admin.adminPassword= (GridView1.Rows[e.RowIndex].FindControl("LabelPassword") as Label).Text;


            bool bo = adminManager.Update(admin);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                GridView1.EditIndex = -1;
                Bind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！请重试')");
            }


        }

        protected void ApplyNumber()
        {

            Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
            BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();
            string str = "remark='" + "1" + "'";
            int number = apply.GetRecordCount(str);
            if (number > 0)
            {
                LabelApply.Visible = true;
                LabelApply.Text = Convert.ToString(number);

            }

        }

        protected void ReplyNumber()
        {

            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();

            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            int s = Convert.ToInt32(admin1.adminID);
            string str = "remark='" + "1" + "'and receiverID='" + s + "'";
            int number = replyManager.GetRecordCount(str);
            if (number > 0)
            {
                LabelMessage.Visible = true;
                LabelMessage.Text = Convert.ToString(number);

            }

        }
    }
}