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
namespace UserFB.Web.Category
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int categoryID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(categoryID);
				}
			}
		}
			
	private void ShowInfo(int categoryID)
	{
		UserFB.BLL.CategoryManager bll=new UserFB.BLL.CategoryManager();
		UserFB.Model.Category model=bll.GetModel(categoryID);
		this.lblcategoryID.Text=model.categoryID.ToString();
		this.txtcategory.Text=model.category;
		this.txttime.Text=model.time.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcategory.Text.Trim().Length==0)
			{
				strErr+="category不能为空！\\n";	
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
			int categoryID=int.Parse(this.lblcategoryID.Text);
			string category=this.txtcategory.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);


			UserFB.Model.Category model=new UserFB.Model.Category();
			model.categoryID=categoryID;
			model.category=category;
			model.time=time;

			UserFB.BLL.CategoryManager bll=new UserFB.BLL.CategoryManager();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
