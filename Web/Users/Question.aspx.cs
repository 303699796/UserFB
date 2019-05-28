using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;
using UserFB.Model;

namespace UserFB.Web.Users
{
    public partial class Question : System.Web.UI.Page
    {
        Model.Category category = new Model.Category();
        BLL.CategoryManager categoryManager = new BLL.CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
               // CategoryBind();
                DDLCategoryBind();
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

        protected void Bind()
        {
            Model.Question question = new Model.Question();
            BLL.QuestionManager questionManager = new BLL.QuestionManager();
            GridView1.DataSource = questionManager.GetAllQuestion();
            GridView1.DataBind();

        }
        //protected void CategoryBind()
        //{
           
        //    GridView2.DataSource = categoryManager.GetAllList();         
        //    GridView2.DataBind();

        //}

        private void DDLCategoryBind()
        {

            DataSet ds = new CategoryManager().GetAllList();
            DataRow dr = ds.Tables[0].NewRow();
            dr["category"] = "— —请选择— —";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            DropDownList_Category.DataTextField = "category";
            DropDownList_Category.DataValueField = "categoryID";
            DropDownList_Category.DataSource = ds;
            DropDownList_Category.DataBind();
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
           
        //    //LinkButton tempBTN = (LinkButton)sender;
        //    //Button1.Text = tempBTN.Text;
        //    Button1.Text = DropDownList_Category.SelectedValue;
        //    string strWhere = "categoryID='" + DropDownList_Category.SelectedValue + "'";
        //   // string Str = "categoryID'" + DropDownList_Category.SelectedValue + "'";
        //    BLL.QuestionManager questionManager = new QuestionManager();
        //    DataSet ds = questionManager.GetList(strWhere);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    { 
        //        GridView3.DataSource = ds;
        //        GridView3.DataBind();
        //        GridView1.Visible = false;
        //        GridView3.Visible = true;
        //    }





        

        protected void But_Search_Click(object sender, EventArgs e)
        {
            //LinkButton tempBTN = (LinkButton)sender;
            //Button1.Text = tempBTN.Text;
          //  Button1.Text = DropDownList_Category.SelectedValue;
            string strWhere = "categoryID='" + DropDownList_Category.SelectedValue + "'";
            // string Str = "categoryID'" + DropDownList_Category.SelectedValue + "'";
            BLL.QuestionManager questionManager = new QuestionManager();
            DataSet ds = questionManager.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView3.DataSource = ds;
                GridView3.DataBind();
                GridView1.Visible = false;
                GridView3.Visible = true;
                Btn_All.Visible = true;
            }
        }

        protected void Btn_All_Click(object sender, EventArgs e)
        {
            GridView3.Visible = false;
            GridView1.Visible = true;
            Bind(); ;
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