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
namespace UserFB.Web.Feedback
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserID.Text))
			{
				strErr+="UserID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtfeedbackTime.Text))
			{
				strErr+="feedbackTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategoryID.Text))
			{
				strErr+="categoryID格式错误！\\n";	
			}
			if(this.txtInfo.Text.Trim().Length==0)
			{
				strErr+="Info不能为空！\\n";	
			}
			if(this.txtcontact.Text.Trim().Length==0)
			{
				strErr+="contact不能为空！\\n";	
			}
			if(this.txtisInvalid.Text.Trim().Length==0)
			{
				strErr+="isInvalid不能为空！\\n";	
			}
			if(this.txtsolutionState.Text.Trim().Length==0)
			{
				strErr+="solutionState不能为空！\\n";	
			}
			if(this.txthandler.Text.Trim().Length==0)
			{
				strErr+="handler不能为空！\\n";	
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
			int UserID=int.Parse(this.txtUserID.Text);
			DateTime feedbackTime=DateTime.Parse(this.txtfeedbackTime.Text);
			int categoryID=int.Parse(this.txtcategoryID.Text);
			string Info=this.txtInfo.Text;
			string contact=this.txtcontact.Text;
			string isInvalid=this.txtisInvalid.Text;
			string solutionState=this.txtsolutionState.Text;
			string handler=this.txthandler.Text;
			string remark=this.txtremark.Text;

			UserFB.Model.Feedback model=new UserFB.Model.Feedback();
			model.UserID=UserID;
			model.feedbackTime=feedbackTime;
			model.categoryID=categoryID;
			model.Info=Info;
			model.contact=contact;
			model.isInvalid=isInvalid;
			model.solutionState=solutionState;
			model.handler=handler;
			model.remark=remark;

			UserFB.BLL.FeedbackManager bll=new UserFB.BLL.FeedbackManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
