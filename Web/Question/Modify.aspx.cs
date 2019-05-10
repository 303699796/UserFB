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
namespace UserFB.Web.Question
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int questionID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(questionID);
				}
			}
		}
			
	private void ShowInfo(int questionID)
	{
		UserFB.BLL.QuestionManager bll=new UserFB.BLL.QuestionManager();
		UserFB.Model.Question model=bll.GetModel(questionID);
		this.lblquestionID.Text=model.questionID.ToString();
		this.txtcategoryID.Text=model.categoryID.ToString();
		this.txtquestion.Text=model.question;
		this.txtsolution.Text=model.solution;
		this.txttime.Text=model.time.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtcategoryID.Text))
			{
				strErr+="categoryID格式错误！\\n";	
			}
			if(this.txtquestion.Text.Trim().Length==0)
			{
				strErr+="question不能为空！\\n";	
			}
			if(this.txtsolution.Text.Trim().Length==0)
			{
				strErr+="solution不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txttime.Text))
			{
				strErr+="time格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int questionID=int.Parse(this.lblquestionID.Text);
			int categoryID=int.Parse(this.txtcategoryID.Text);
			string question=this.txtquestion.Text;
			string solution=this.txtsolution.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);


			UserFB.Model.Question model=new UserFB.Model.Question();
			model.questionID=questionID;
			model.categoryID=categoryID;
			model.question=question;
			model.solution=solution;
			model.time=time;

			UserFB.BLL.QuestionManager bll=new UserFB.BLL.QuestionManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
