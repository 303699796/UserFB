using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;
using UserFB.Model;
using System.Data;
using System.Web.Security;

namespace UserFB.Web.Users
{
    public partial class Fill_Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryDataBind();
                GetLoginName();
                ReplyNumber();
            }
        }

        protected void GetLoginName()
        {


            BLL.UsersManager usersM = new UsersManager();
            Model.Users users = usersM.GetModel1(Session["userID"].ToString());
            LabelUser.Text = users.userName;
            // LabelUser.Text = Convert.ToString(Session["username"]);
        }

        protected void CategoryDataBind()
        {
            Model.Category category1 = new Model.Category();
            BLL.CategoryManager category2 = new BLL.CategoryManager();
            DropDownList_Category.DataTextField = "category";
            DropDownList_Category.DataValueField = "categoryID";
            DataSet ds = new CategoryManager().GetAllList();
            DataRow dr = ds.Tables[0].NewRow();
            dr["categoryID"] = 0;
            dr["category"] = "---请选择问题分类---";
            ds.Tables[0].Rows.InsertAt(dr, 0);                 
            DropDownList_Category.DataSource= ds;         
            DropDownList_Category.DataBind();
            
        }

     

        protected void But_submit_Click(object sender, EventArgs e)
        {
            
            Model.Feedback feedback = new Model.Feedback();
            feedback.categoryID = int.Parse(this.DropDownList_Category.SelectedValue);
            feedback.Info = txbInfo.Text.Trim();
            feedback.contact = txbContact.Text.Trim();
            feedback.handler = "未处理";

            feedback.UserID = Convert.ToInt32(Session["userID"]);

            BLL.FeedbackManager feedbackManager = new FeedbackManager();
            bool bo = feedbackManager.Add(feedback);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('提交成功')</script>");
                txbContact.Text = "";
                txbInfo.Text = "";
                this.DropDownList_Category.SelectedIndex = 0;
              
            }

            else
            {
                Response.Write("<script language=javascript>alert('提交失败！请重试')");
                }
            }

        protected void ReplyNumber()
        {

            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();

            BLL.UsersManager usersM = new UsersManager();
            Model.Users users = usersM.GetModel1(Session["userID"].ToString());
            int s = Convert.ToInt32(users.UserID);
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
