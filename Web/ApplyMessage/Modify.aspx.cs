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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ApplyID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ApplyID);
				}
			}
		}
			
	private void ShowInfo(int ApplyID)
	{
		UserFB.BLL.ApplyMessageManager bll=new UserFB.BLL.ApplyMessageManager();
		UserFB.Model.ApplyMessage model=bll.GetModel(ApplyID);
		this.lblApplyID.Text=model.ApplyID.ToString();
		this.txtapplicantID.Text=model.applicantID.ToString();
		this.txtapproverID.Text=model.approverID.ToString();
		this.txtname.Text=model.name;
		this.txtdepartment.Text=model.department;
		this.txtjob.Text=model.job;
		this.txtpermission.Text=model.permission;
		this.txtapplyTime.Text=model.applyTime.ToString();
		this.txtapplyState.Text=model.applyState;
		this.txtremark.Text=model.remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int ApplyID=int.Parse(this.lblApplyID.Text);
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
			model.ApplyID=ApplyID;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
