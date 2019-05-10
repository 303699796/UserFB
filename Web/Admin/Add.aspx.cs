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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string adminName=this.txtadminName.Text;
			string adminPassword=this.txtadminPassword.Text;
			string department=this.txtdepartment.Text;
			string job=this.txtjob.Text;
			string permission=this.txtpermission.Text;
			string remark=this.txtremark.Text;

			UserFB.Model.Admin model=new UserFB.Model.Admin();
			model.adminName=adminName;
			model.adminPassword=adminPassword;
			model.department=department;
			model.job=job;
			model.permission=permission;
			model.remark=remark;

			UserFB.BLL.AdminManager bll=new UserFB.BLL.AdminManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
