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
namespace UserFB.Web.Reply
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int replyID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(replyID);
				}
			}
		}
			
	private void ShowInfo(int replyID)
	{
		UserFB.BLL.ReplyManager bll=new UserFB.BLL.ReplyManager();
		UserFB.Model.Reply model=bll.GetModel(replyID);
		this.lblreplyID.Text=model.replyID.ToString();
		this.txtfeedbackID.Text=model.feedbackID.ToString();
		this.txtreplierID.Text=model.replierID.ToString();
		this.txtreceiverID.Text=model.receiverID.ToString();
		this.txttext.Text=model.text;
		this.txttime.Text=model.time.ToString();
		this.txtremark.Text=model.remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtfeedbackID.Text))
			{
				strErr+="feedbackID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtreplierID.Text))
			{
				strErr+="replierID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtreceiverID.Text))
			{
				strErr+="receiverID格式错误！\\n";	
			}
			if(this.txttext.Text.Trim().Length==0)
			{
				strErr+="text不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txttime.Text))
			{
				strErr+="time格式错误！\\n";	
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
			int replyID=int.Parse(this.lblreplyID.Text);
			int feedbackID=int.Parse(this.txtfeedbackID.Text);
			int replierID=int.Parse(this.txtreplierID.Text);
			int receiverID=int.Parse(this.txtreceiverID.Text);
			string text=this.txttext.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);
			string remark=this.txtremark.Text;


			UserFB.Model.Reply model=new UserFB.Model.Reply();
			model.replyID=replyID;
			model.feedbackID=feedbackID;
			model.replierID=replierID;
			model.receiverID=receiverID;
			model.text=text;
			model.time=time;
			model.remark=remark;

			UserFB.BLL.ReplyManager bll=new UserFB.BLL.ReplyManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
