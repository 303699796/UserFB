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
namespace UserFB.Web.ApplyMessage
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtapplicantID.Text))
			{
				strErr+="applicantID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtapproverID.Text))
			{
				strErr+="approverID格式错误！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
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
			if(!PageValidate.IsDateTime(txtapplyTime.Text))
			{
				strErr+="applyTime格式错误！\\n";	
			}
			if(this.txtapplyState.Text.Trim().Length==0)
			{
				strErr+="applyState不能为空！\\n";	
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
			int applicantID=int.Parse(this.txtapplicantID.Text);
			int approverID=int.Parse(this.txtapproverID.Text);
			string name=this.txtname.Text;
			string department=this.txtdepartment.Text;
			string job=this.txtjob.Text;
			string permission=this.txtpermission.Text;
			DateTime applyTime=DateTime.Parse(this.txtapplyTime.Text);
			string applyState=this.txtapplyState.Text;
			string remark=this.txtremark.Text;

			UserFB.Model.ApplyMessage model=new UserFB.Model.ApplyMessage();
			model.applicantID=applicantID;
			model.approverID=approverID;
			model.name=name;
			model.department=department;
			model.job=job;
			model.permission=permission;
			model.applyTime=applyTime;
			model.applyState=applyState;
			model.remark=remark;

			UserFB.BLL.ApplyMessageManager bll=new UserFB.BLL.ApplyMessageManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
