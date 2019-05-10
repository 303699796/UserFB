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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string category=this.txtcategory.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);

			UserFB.Model.Category model=new UserFB.Model.Category();
			model.category=category;
			model.time=time;

			UserFB.BLL.CategoryManager bll=new UserFB.BLL.CategoryManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
