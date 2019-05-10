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
namespace UserFB.Web.Reply
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
					int replyID=(Convert.ToInt32(strid));
					ShowInfo(replyID);
				}
			}
		}
		
	private void ShowInfo(int replyID)
	{
		UserFB.BLL.ReplyManager bll=new UserFB.BLL.ReplyManager();
		UserFB.Model.Reply model=bll.GetModel(replyID);
		this.lblreplyID.Text=model.replyID.ToString();
		this.lblfeedbackID.Text=model.feedbackID.ToString();
		this.lblreplierID.Text=model.replierID.ToString();
		this.lblreceiverID.Text=model.receiverID.ToString();
		this.lbltext.Text=model.text;
		this.lbltime.Text=model.time.ToString();
		this.lblremark.Text=model.remark;

	}


    }
}
