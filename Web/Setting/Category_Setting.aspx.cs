using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserFB.Web.Setting
{
    public partial class Category_Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Bind()
        {

            Model.Category category1 = new Model.Category();
            BLL.CategoryManager category2 = new BLL.CategoryManager();
            GridView1.DataSource = category2.GetAllList();
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Category category3 = new Model.Category();
            BLL.CategoryManager category4 = new BLL.CategoryManager();
            int categoryID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txbCategory") as TextBox).Text);
            bool bo = category4.Delete(categoryID);
            if (bo == true)
            {
                Bind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //Bind();



            GridView1.EditIndex = e.NewEditIndex;
            Bind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void BntSave_Click(object sender, EventArgs e)
        {
            Model.Category category3 = new Model.Category();
            BLL.CategoryManager category4 = new BLL.CategoryManager();
            //users.userName = txbUserName.Text;
            category3.category = txbAdd.Text;
            bool bo = category4.Add(category3);
            if (bo == true)
            {
                // Response.Redirect("~/Default.aspx");
                Bind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('添加失败！')");
            }
        }
    }
}