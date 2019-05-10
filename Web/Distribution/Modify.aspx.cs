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
namespace UserFB.Web.Distribution
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int distributionID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(distributionID);
				}
			}
		}
			
	private void ShowInfo(int distributionID)
	{
		UserFB.BLL.DistributionManager bll=new UserFB.BLL.DistributionManager();
		UserFB.Model.Distribution model=bll.GetModel(distributionID);
		this.lbldistributionID.Text=model.distributionID.ToString();
		this.txtfeedbackID.Text=model.feedbackID.ToString();
		this.txtdescription.Text=model.description;
		this.txtdistributionTime.Text=model.distributionTime.ToString();
		this.txtadminID.Text=model.adminID.ToString();
		this.txtassignerID.Text=model.assignerID.ToString();
		this.txtstate.Text=model.state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtfeedbackID.Text))
			{
				strErr+="feedbackID格式错误！\\n";	
			}
			if(this.txtdescription.Text.Trim().Length==0)
			{
				strErr+="description不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdistributionTime.Text))
			{
				strErr+="distributionTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtadminID.Text))
			{
				strErr+="adminID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtassignerID.Text))
			{
				strErr+="assignerID格式错误！\\n";	
			}
			if(this.txtstate.Text.Trim().Length==0)
			{
				strErr+="state不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int distributionID=int.Parse(this.lbldistributionID.Text);
			int feedbackID=int.Parse(this.txtfeedbackID.Text);
			string description=this.txtdescription.Text;
			DateTime distributionTime=DateTime.Parse(this.txtdistributionTime.Text);
			int adminID=int.Parse(this.txtadminID.Text);
			int assignerID=int.Parse(this.txtassignerID.Text);
			string state=this.txtstate.Text;


			UserFB.Model.Distribution model=new UserFB.Model.Distribution();
			model.distributionID=distributionID;
			model.feedbackID=feedbackID;
			model.description=description;
			model.distributionTime=distributionTime;
			model.adminID=adminID;
			model.assignerID=assignerID;
			model.state=state;

			UserFB.BLL.DistributionManager bll=new UserFB.BLL.DistributionManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
