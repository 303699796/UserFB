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
namespace UserFB.Web.ApplyMessage
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ApplyID=(Convert.ToInt32(strid));
					ShowInfo(ApplyID);
				}
			}
		}
		
	private void ShowInfo(int ApplyID)
	{
		UserFB.BLL.ApplyMessageManager bll=new UserFB.BLL.ApplyMessageManager();
		UserFB.Model.ApplyMessage model=bll.GetModel(ApplyID);
		this.lblApplyID.Text=model.ApplyID.ToString();
		this.lblapplicantID.Text=model.applicantID.ToString();
		this.lblapproverID.Text=model.approverID.ToString();
		this.lblname.Text=model.name;
		this.lbldepartment.Text=model.department;
		this.lbljob.Text=model.job;
		this.lblpermission.Text=model.permission;
		this.lblapplyTime.Text=model.applyTime.ToString();
		this.lblapplyState.Text=model.applyState;
		this.lblremark.Text=model.remark;

	}


    }
}
