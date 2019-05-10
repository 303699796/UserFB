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
			int feedbackID=int.Parse(this.txtfeedbackID.Text);
			string description=this.txtdescription.Text;
			DateTime distributionTime=DateTime.Parse(this.txtdistributionTime.Text);
			int adminID=int.Parse(this.txtadminID.Text);
			int assignerID=int.Parse(this.txtassignerID.Text);
			string state=this.txtstate.Text;

			UserFB.Model.Distribution model=new UserFB.Model.Distribution();
			model.feedbackID=feedbackID;
			model.description=description;
			model.distributionTime=distributionTime;
			model.adminID=adminID;
			model.assignerID=assignerID;
			model.state=state;

			UserFB.BLL.DistributionManager bll=new UserFB.BLL.DistributionManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
