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
namespace UserFB.Web.Question
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
					int questionID=(Convert.ToInt32(strid));
					ShowInfo(questionID);
				}
			}
		}
		
	private void ShowInfo(int questionID)
	{
		UserFB.BLL.QuestionManager bll=new UserFB.BLL.QuestionManager();
		UserFB.Model.Question model=bll.GetModel(questionID);
		this.lblquestionID.Text=model.questionID.ToString();
		this.lblcategoryID.Text=model.categoryID.ToString();
		this.lblquestion.Text=model.question;
		this.lblsolution.Text=model.solution;
		this.lbltime.Text=model.time.ToString();

	}


    }
}
