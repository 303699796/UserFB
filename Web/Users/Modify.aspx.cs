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
namespace UserFB.Web.Users
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int UserID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(UserID);
				}
			}
		}
			
	private void ShowInfo(int UserID)
	{
		UserFB.BLL.UsersManager bll=new UserFB.BLL.UsersManager();
		UserFB.Model.Users model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID.ToString();
		this.txtuserName.Text=model.userName;
		this.txtpassword.Text=model.password;
		this.txtgender.Text=model.gender;
		this.txtbirthDate.Text=model.birthDate.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuserName.Text.Trim().Length==0)
			{
				strErr+="userName不能为空！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(this.txtgender.Text.Trim().Length==0)
			{
				strErr+="gender不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtbirthDate.Text))
			{
				strErr+="birthDate格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserID=int.Parse(this.lblUserID.Text);
			string userName=this.txtuserName.Text;
			string password=this.txtpassword.Text;
			string gender=this.txtgender.Text;
			DateTime birthDate=DateTime.Parse(this.txtbirthDate.Text);


			UserFB.Model.Users model=new UserFB.Model.Users();
			model.UserID=UserID;
			model.userName=userName;
			model.password=password;
			model.gender=gender;
			model.birthDate=birthDate;

			UserFB.BLL.UsersManager bll=new UserFB.BLL.UsersManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
