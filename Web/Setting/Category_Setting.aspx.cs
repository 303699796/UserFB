using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.Setting
{
    public partial class Category_Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                GetLoginName();
                ApplyNumber();
                ReplyNumber();
            }
        }
        protected void Bind()
        {

            Model.Category category1 = new Model.Category();
            BLL.CategoryManager category2 = new BLL.CategoryManager();
            GridView1.DataSource = category2.GetAllList();
            GridView1.DataBind();

        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Model.Category category3 = new Model.Category();
            BLL.CategoryManager category4 = new BLL.CategoryManager();
            int categoryID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("LabelID") as Label).Text);
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
            Model.Category category = new Model.Category();
            category.categoryID= Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            category.category= (GridView1.Rows[e.RowIndex].FindControl("txtCategory") as TextBox).Text;

            BLL.CategoryManager categoryManager = new BLL.CategoryManager();
            bool bo = categoryManager.Update(category);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                GridView1.EditIndex = -1;
                Bind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！请重试')");
            }
           
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

        protected void ApplyNumber()
        {

            Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
            BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();
            string str = "remark='" + "1" + "'";
            int number = apply.GetRecordCount(str);
            if (number > 0)
            {
                LabelApply.Visible = true;
                LabelApply.Text = Convert.ToString(number);

            }

        }

        protected void ReplyNumber()
        {

            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();

            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            int s = Convert.ToInt32(admin1.adminID);
            string str = "remark='" + "1" + "'and receiverID='" + s + "'";
            int number = replyManager.GetRecordCount(str);
            if (number > 0)
            {
                LabelMessage.Visible = true;
                LabelMessage.Text = Convert.ToString(number);

            }

        }
    }
}