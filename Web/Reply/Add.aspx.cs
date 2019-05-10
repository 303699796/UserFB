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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			int feedbackID=int.Parse(this.txtfeedbackID.Text);
			int replierID=int.Parse(this.txtreplierID.Text);
			int receiverID=int.Parse(this.txtreceiverID.Text);
			string text=this.txttext.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);
			string remark=this.txtremark.Text;

			UserFB.Model.Reply model=new UserFB.Model.Reply();
			model.feedbackID=feedbackID;
			model.replierID=replierID;
			model.receiverID=receiverID;
			model.text=text;
			model.time=time;
			model.remark=remark;

			UserFB.BLL.ReplyManager bll=new UserFB.BLL.ReplyManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
