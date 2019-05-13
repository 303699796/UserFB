﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserFB.Web.S_Admin_List
{
    public partial class ApplyMessage_List : System.Web.UI.Page
    {
        Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
        BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewBind();
                HistoryBind();

            }
        }
        protected void NewBind()
        {


            GridView1.DataSource = apply.GetALLNewList();
            GridView1.DataBind();

        }
        protected void HistoryBind()
        {


            GridView2.DataSource = apply.GetHistoryList();
            GridView2.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ApplyMessage.ApplyID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ApplyMessage.name = (GridView1.Rows[e.RowIndex].FindControl("LabelName") as Label).Text;
            ApplyMessage.department = (GridView1.Rows[e.RowIndex].FindControl("LabelDepartment") as Label).Text;
            ApplyMessage.job = (GridView1.Rows[e.RowIndex].FindControl("LabelJob") as Label).Text;
            ApplyMessage.applyTime = DateTime.Parse((GridView1.Rows[e.RowIndex].FindControl("LabelTime") as Label).Text);
            ApplyMessage.applyState = "已同意";
            ApplyMessage.permission= (GridView1.Rows[e.RowIndex].FindControl("LabelPermission") as Label).Text;

            bool bo = apply.Update(ApplyMessage);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                GridView1.EditIndex = -1;
                NewBind();
                HistoryBind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！请重试')");
            }

            
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
          
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            NewBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}