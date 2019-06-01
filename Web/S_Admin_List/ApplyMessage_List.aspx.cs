using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.S_Admin_List
{
    public partial class ApplyMessage_List : System.Web.UI.Page
    {
        Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
        BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewBind();
                HistoryBind();
                ApplyNumber();
                GetLoginName();
                ReplyNumber();
            }
        }
        protected void NewBind()
        {


            GridView1.DataSource = apply.GetALLNewList();
            GridView1.DataBind();

        }
        protected void HistoryBind()
        {


            GridView2.DataSource = apply.GetHistoryList();
            GridView2.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
       

            
        }





        protected void btnAgree_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
          
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            NewBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
        }

        private string GetSelIDList()
        {
            string idList = "";
            bool boxChecked = false;
            for (int i=0;i<GridView1.Rows.Count;i++)
            {
                CheckBox checkBox = (CheckBox)GridView1.Rows[i].FindControl("ModifyThis");
                if(checkBox!=null && checkBox.Checked)
                {
                    boxChecked = true;
                    if(GridView1.DataKeys[i].Value!=null)
                    {
                        idList += GridView1.DataKeys[i].Value.ToString() + ",";

                    }
                }
            }
            if(boxChecked)
            {
                idList = idList.Substring(0, idList.LastIndexOf(","));
            }
            return idList;
        }

        protected void Btn_Agree_Click(object sender, EventArgs e)
        {
            string state = "1";
            string idList = GetSelIDList();
            if(idList.Trim().Length==0)
            {
                return;
            }          
            new BLL.ApplyMessageManager().UpdateList(state,idList);
            Response.Write("<script language=javascript>alert('已同意该申请！')</script>");
            NewBind();
            HistoryBind();

        }

        protected void Btn_Refuse_Click(object sender, EventArgs e)
        {
            string state = "2";
            string idList = GetSelIDList();
            if (idList.Trim().Length == 0)
            {
                return;
            }
            new BLL.ApplyMessageManager().UpdateList(state, idList);
            Response.Write("<script language=javascript>alert('已拒绝该申请！')</script>");
            NewBind();
            HistoryBind();
        }

      

        protected void ApplyNumber()
        {
         

            Model.ApplyMessage ApplyMessage = new Model.ApplyMessage();
            BLL.ApplyMessageManager apply = new BLL.ApplyMessageManager();

            string str = "0";
            apply.UpdateState(str);
            LabelApply.Text = "0";
            LabelApply.Visible = false;

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

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
         
            LabelUser.Text = admin1.adminName;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
        }
    }
}