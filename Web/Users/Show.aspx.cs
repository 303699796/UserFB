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
namespace UserFB.Web.Users
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
					int UserID=(Convert.ToInt32(strid));
					ShowInfo(UserID);
				}
			}
		}
		
	private void ShowInfo(int UserID)
	{
		UserFB.BLL.UsersManager bll=new UserFB.BLL.UsersManager();
		UserFB.Model.Users model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID.ToString();
		this.lbluserName.Text=model.userName;
		this.lblpassword.Text=model.password;
		this.lblgender.Text=model.gender;
		this.lblbirthDate.Text=model.birthDate.ToString();

	}


    }
}
