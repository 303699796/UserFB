using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace UserFB.Web.Admin
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int adminID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(adminID);
				}
			}
		}
			
	private void ShowInfo(int adminID)
	{
		UserFB.BLL.AdminManager bll=new UserFB.BLL.AdminManager();
		UserFB.Model.Admin model=bll.GetModel(adminID);
		this.lbladminID.Text=model.adminID.ToString();
		this.txtadminName.Text=model.adminName;
		this.txtadminPassword.Text=model.adminPassword;
		this.txtdepartment.Text=model.department;
		this.txtjob.Text=model.job;
		this.txtpermission.Text=model.permission;
		this.txtremark.Text=model.remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtadminName.Text.Trim().Length==0)
			{
				strErr+="adminName不能为空！\\n";	
			}
			if(this.txtadminPassword.Text.Trim().Length==0)
			{
				strErr+="adminPassword不能为空！\\n";	
			}
			if(this.txtdepartment.Text.Trim().Length==0)
			{
				strErr+="department不能为空！\\n";	
			}
			if(this.txtjob.Text.Trim().Length==0)
			{
				strErr+="job不能为空！\\n";	
			}
			if(this.txtpermission.Text.Trim().Length==0)
			{
				strErr+="permission不能为空！\\n";	
			}
			if(this.txtremark.Text.Trim().Length==0)
			{
				strErr+="remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int adminID=int.Parse(this.lbladminID.Text);
			string adminName=this.txtadminName.Text;
			string adminPassword=this.txtadminPassword.Text;
			string department=this.txtdepartment.Text;
			string job=this.txtjob.Text;
			string permission=this.txtpermission.Text;
			string remark=this.txtremark.Text;


			UserFB.Model.Admin model=new UserFB.Model.Admin();
			model.adminID=adminID;
			model.adminName=adminName;
			model.adminPassword=adminPassword;
			model.department=department;
			model.job=job;
			model.permission=permission;
			model.remark=remark;

			UserFB.BLL.AdminManager bll=new UserFB.BLL.AdminManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
