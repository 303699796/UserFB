using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserFB.Web.N_Admin
{
    public partial class Apply_Permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMessage();
                GetLoginName();
            }
            
        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["NadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        //  LabelUser.Text = Convert.ToString(Session["NadminName"]);
        }

        protected void GetMessage()
        {

            BLL.AdminManager adminManager1 = new BLL.AdminManager();
           // Model.Admin admin1 = adminManager1.GetModel1(Session["NadminName"].ToString());
           // BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["NadminID"].ToString());
           // DataSet ds = adminManager1.GetList();

            LabelUser.Text = admin1.adminName;
            txtID.Text = Convert.ToString(admin1.adminID);
            txtName.Text = admin1.adminName;
            txtDepartment.Text = admin1.department;
            txtJob.Text = admin1.job;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          
        }

        protected void But_Apply_Click(object sender, EventArgs e)
        {
        
            Model.ApplyMessage applyMessage = new Model.ApplyMessage();
            applyMessage.applicantID = Convert.ToInt32(txtID.Text);

            applyMessage.approverID = Convert.ToInt32("20000");

            applyMessage.name = txtName.Text.Trim();
            applyMessage.department = txtDepartment.Text.Trim();
            applyMessage.job = txtJob.Text.Trim();
            applyMessage.permission = RadioButtonList_Choose.SelectedValue;
            applyMessage.remark = "1";

            BLL.ApplyMessageManager applyMessageManager = new BLL.ApplyMessageManager();
            bool bo = applyMessageManager.Add(applyMessage);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('申请成功！请耐心等待管理员同意')</script>");
               
            }
            else
            {
                Response.Write("<script language=javascript>alert('申请失败！请重试')");
            }
        }

        //protected void ApplyNumber()
        //{


        //    //Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
        //    //BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();

        //    //BLL.AdminManager adminManager1 = new BLL.AdminManager();
        //    //Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
        //    //int s = Convert.ToInt32(admin1.adminID);

        //    //string str = "0";
        //    //apply.UpdateState(str,s);
        //    //LabelApply.Text = "0";
        //    //LabelApply.Visible = false;


        //    Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
        //    BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();



        //    string str = "0";
        //    apply.UpdateState(str);
        //    LabelMessage.Text = "0";
        //    LabelMessage.Visible = false;

        //}
    }
}