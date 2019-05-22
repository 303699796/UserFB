using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.S_Admin_List
{
    public partial class Reply_Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Bind();
                GetLoginName();
                ApplyNumber();



            }
        }
        protected void Bind()
        {
            BLL.AdminManager adminManager = new BLL.AdminManager();
            Model.Admin admin=adminManager.GetModel1(Session["SadminID"].ToString());
            int ID = Convert.ToInt32(admin.adminID);


            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new BLL.ReplyManager();
            string Str = " receiverID='" + ID + "'";
            GridView1.DataSource = replyManager.GetFBList(Str);
            GridView1.DataBind();
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

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].ToString();//获得第一个单元格的值   

            string b = Convert.ToString(this.GridView1.DataKeys[row.DataItemIndex].Values[0]);//获得DataKeys的值   
            Labeltest.Text = b;
            GridView1.Columns[9].Visible = true;


            //Model.Feedback feedback = new Model.Feedback();
            //BLL.FeedbackManager Fmanager = new FeedbackManager();
            //string Str1 = "feedbackID='" + Labeltest.Text + "'";
            //string s = Fmanager.GetListID(Str1);
            //LabelName.Text = s;


        }

        protected void BntReply_Click(object sender, EventArgs e)
        {
            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();


            Model.Reply reply1 = new Model.Reply();
            BLL.ReplyManager replyManager1 = new ReplyManager();
            string str = "replyID='" + Labeltest.Text + "'";
            string id = replyManager1.GetUserID(str);

            string str1 = "replyID='" + Labeltest.Text + "'";
            string replyFB = replyManager1.GetFBID(str);





            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            int s = Convert.ToInt32(admin1.adminID);
            reply.feedbackID = Convert.ToInt32(replyFB);
            reply.text = txtReply.Text;
            reply.replierID = s;
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
    }
}