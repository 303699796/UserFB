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
namespace UserFB.Web.Category
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
					int categoryID=(Convert.ToInt32(strid));
					ShowInfo(categoryID);
				}
			}
		}
		
	private void ShowInfo(int categoryID)
	{
		UserFB.BLL.CategoryManager bll=new UserFB.BLL.CategoryManager();
		UserFB.Model.Category model=bll.GetModel(categoryID);
		this.lblcategoryID.Text=model.categoryID.ToString();
		this.lblcategory.Text=model.category;
		this.lbltime.Text=model.time.ToString();

	}


    }
}
