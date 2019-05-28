using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.Users
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                GetLoginName();
                ReplyNumber();

            }
        }

        protected void Bind()
        {


            BLL.UsersManager usersManager = new BLL.UsersManager();
            Model.Users users = usersManager.GetModel1(Session["userID"].ToString());
            int ID = Convert.ToInt32(users.UserID);


            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new BLL.ReplyManager();
            string Str = " receiverID='" + ID + "'";
            GridView1.DataSource = replyManager.GetFBList(Str);
            GridView1.DataBind();


            

        }


        protected void GetLoginName()
        {


            BLL.UsersManager usersM = new UsersManager();
            Model.Users users = usersM.GetModel1(Session["userID"].ToString());
            LabelUser.Text = users.userName;
            //  LabelUser.Text = Convert.ToString(Session["username"]);
        }

        protected void ReplyNumber()
        {


            Model.Reply reply1 = new Model.Reply();
            BLL.ReplyManager replyManager1 = new ReplyManager();
            BLL.UsersManager usersM = new UsersManager();
            Model.Users users = usersM.GetModel1(Session["userID"].ToString());
            int s = Convert.ToInt32(users.UserID);
            string str = "0";
            int id = s;
            replyManager1.UpdateState(str, s);
            LabelMessage.Text = "0";
            LabelMessage.Visible = false;
        }

        protected void BntReply_Click(object sender, EventArgs e)
        {
            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();


            Model.Reply reply1 = new Model.Reply();
            BLL.ReplyManager replyManager1 = new ReplyManager();
            string str = "replyID='" + Labeltest.Text + "'";
            string id = replyManager1.GetUserID(str);

          //  string str1 = "replyID='" + Labeltest.Text + "'";
            string replyFB = replyManager1.GetFBID(str);


            BLL.UsersManager usersM = new UsersManager();
            Model.Users users=usersM.GetModel1(Session["UserID"].ToString());
            int s = Convert.ToInt32(users.UserID);


            //BLL.AdminManager adminManager1 = new BLL.AdminManager();
            //Model.Admin admin1 = adminManager1.GetModel1(Session["UserID"].ToString());
            //int s = Convert.ToInt32(admin1.adminID);


            reply.feedbackID = Convert.ToInt32(replyFB);
            reply.text = txtReply.Text;
            reply.replierID = s;
            reply.remark = "1";
            reply.receiverID = Convert.ToInt32(id);
            bool bo = replyManager.Add(reply);
            if (bo == true)
            {

                Response.Write("<script language=javascript>alert('回复成功！')</script>");

            }
            else
            {
                Response.Write("<script language=javascript>alert('回复失败！请重试')");
            }
        }

        protected void Btn_select_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].ToString();//获得第一个单元格的值   

            string b = Convert.ToString(this.GridView1.DataKeys[row.DataItemIndex].Values[0]);//获得DataKeys的值   
            Labeltest.Text = b;

            GridView1.Columns[7].Visible = true;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();

        }
    }
}