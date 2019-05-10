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
namespace UserFB.Web.Feedback
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
					int feedbackID=(Convert.ToInt32(strid));
					ShowInfo(feedbackID);
				}
			}
		}
		
	private void ShowInfo(int feedbackID)
	{
		UserFB.BLL.FeedbackManager bll=new UserFB.BLL.FeedbackManager();
		UserFB.Model.Feedback model=bll.GetModel(feedbackID);
		this.lblfeedbackID.Text=model.feedbackID.ToString();
		this.lblUserID.Text=model.UserID.ToString();
		this.lblfeedbackTime.Text=model.feedbackTime.ToString();
		this.lblcategoryID.Text=model.categoryID.ToString();
		this.lblInfo.Text=model.Info;
		this.lblcontact.Text=model.contact;
		this.lblisInvalid.Text=model.isInvalid;
		this.lblsolutionState.Text=model.solutionState;
		this.lblhandler.Text=model.handler;
		this.lblremark.Text=model.remark;

	}


    }
}
