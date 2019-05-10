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
namespace UserFB.Web.Distribution
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
					int distributionID=(Convert.ToInt32(strid));
					ShowInfo(distributionID);
				}
			}
		}
		
	private void ShowInfo(int distributionID)
	{
		UserFB.BLL.DistributionManager bll=new UserFB.BLL.DistributionManager();
		UserFB.Model.Distribution model=bll.GetModel(distributionID);
		this.lbldistributionID.Text=model.distributionID.ToString();
		this.lblfeedbackID.Text=model.feedbackID.ToString();
		this.lbldescription.Text=model.description;
		this.lbldistributionTime.Text=model.distributionTime.ToString();
		this.lbladminID.Text=model.adminID.ToString();
		this.lblassignerID.Text=model.assignerID.ToString();
		this.lblstate.Text=model.state;

	}


    }
}
