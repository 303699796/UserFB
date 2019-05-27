using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserFB.BLL;
using UserFB.Model;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Reflection;

namespace UserFB.Web.S_Admin_List
{
    public partial class List : System.Web.UI.Page
    {
        Model.Feedback feedback = new Model.Feedback();
        BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindY();
                BindN();
                CategoryDataBind();
                AdminDataBind();
                ApplyNumber();
                GetLoginName();
            }
        }
        protected void BindY()
        {
            //  GridView1.DataSource = feedbackManager.GetAllFeedback();
            string state = "待分配";
            string str= "handler= '" + state + "'";
            GridView1.DataSource = feedbackManager.GetFeedbackByS(str);
            GridView1.DataBind();
        }

        protected void BindN()
        {
            //  GridView1.DataSource = feedbackManager.GetAllFeedback();
            string state = "待分配";
            string str = "handler != '" + state + "'";
            GridView2.DataSource = feedbackManager.GetFeedbackByS(str);
            GridView2.DataBind();
        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }

        private void CategoryDataBind()
        {

            DataSet ds = new CategoryManager().GetAllList();
            DataRow dr = ds.Tables[0].NewRow();
            dr["category"] = "--请选择--";
            dr["categoryID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            DropDownList_Category.DataTextField = "category";
            DropDownList_Category.DataValueField = "categoryID";
            DropDownList_Category.DataSource = ds;
            DropDownList_Category.DataBind();
        }



        protected void btn_Search_Click(object sender, EventArgs e)
        {

        }

       


      

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.Charset = "GB2312";
            DateTime dt = System.DateTime.Now;
            string str = dt.ToString("yyyyMMddhhmmss");
            str = str + ".xls";
            // Response.AppendHeader("Content-Disposition", "attachment;filename=pkmv_de.xls");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".xls");

            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/ms-excel";
            Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=GB2312/>");
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            GridView1.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void gvRecord_PageIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;

            BindY();
            BindN();
        }

        private string GetSelIDList()
        {
            string idList = "";
            bool boxChecked = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkBox = (CheckBox)GridView1.Rows[i].FindControl("Modify");
                if (checkBox != null && checkBox.Checked)
                {
                    boxChecked = true;
                    if (GridView1.DataKeys[i].Value != null)
                    {
                        idList += GridView1.DataKeys[i].Value.ToString() + ",";

                    }
                }
            }
            if (boxChecked)
            {
                idList = idList.Substring(0, idList.LastIndexOf(","));
            }
            return idList;
        }

        protected void btn_Invalid_Click(object sender, EventArgs e)
        {
            string state = "0";
            string idList = GetSelIDList();
            if (idList.Trim().Length == 0)
            {
                return;
            }
            new BLL.FeedbackManager().UpdateInvalid(state, idList);
            Response.Write("<script language=javascript>alert('已标记为无效！')</script>");
            BindY();
            BindN();
        }

        protected void btn_Dealwith_Click(object sender, EventArgs e)
        {
            string solution = "1";
            string idList = GetSelIDList();

            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin = adminManager1.GetModel1(Session["SadminID"].ToString());
            string name = admin.adminName;
            if (idList.Trim().Length == 0)
            {
                return;
            }
            new BLL.FeedbackManager().UpdateSolution(solution,name, idList);
            Response.Write("<script language=javascript>alert('已标记为已处理！')</script>");
            BindY();
            BindN();
        }

        protected void BntReply_Click(object sender, EventArgs e)
        {
      

         

            Model.Reply reply = new Model.Reply();
            BLL.ReplyManager replyManager = new ReplyManager();


            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            int s = Convert.ToInt32(admin1.adminID);
            reply.feedbackID = Convert.ToInt32(Labeltest.Text);
            reply.text = txtReply.Text;
            reply.replierID = s;
            reply.receiverID = Convert.ToInt32(LabelName.Text.Trim());
            bool bo = replyManager.Add(reply);
            if (bo == true)
            {

                Response.Write("<script language=javascript>alert('回复成功！')</script>");
                reply.text = "";

            }
            else
            {
                Response.Write("<script language=javascript>alert('回复失败！请重试')");
            }
            
       


        }

        protected void Btn_Distribution_Click(object sender, EventArgs e)
        {




            //    // int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;


            //  //  int row4 = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            //   // string sno = GridView1.Rows[row4].Cells[3].Text;




            Model.Distribution distribution = new Model.Distribution();
            BLL.DistributionManager manager = new DistributionManager();
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            int s = Convert.ToInt32(admin1.adminID);
            //    //  = Convert.(admin1);

            //    //  int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            //    //  string a=GridView1.Rows[row].Cells[1].Text;
            //    distribution.feedbackID = Convert.ToInt32(GridView1.DataKeys[0].Value);

            //    //Button btn = sender as Button;
            //    //GridViewRow row = btn.Parent.Parent as GridViewRow;
            //    //string a = row.Cells[1].ToString();//获得第一个单元格的值   
            //    //string b = Convert.ToString( this.GridView1.DataKeys[row.DataItemIndex].Values[0]);//获得DataKeys的值   



            distribution.feedbackID = Convert.ToInt32(Labeltest.Text);
            distribution.description = txtDistribution.Text.Trim();
            distribution.adminID = Convert.ToInt32(DropDownList_Distribution.SelectedValue.ToString());
            distribution.assignerID = s;
            distribution.state = "待处理";
            bool bo = manager.Add(distribution);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('分配成功！')</script>");
                txtDistribution.Text = "";
                DropDownList_Distribution.SelectedIndex = 0;
                UpdateFeedback(sender, e);
                BindY();
                BindN();
            }
            else
            {
                Response.Write("<script language=javascript>alert('分配失败！请重试')");
            }




        }

        protected void AdminDataBind()
        {
            Model.Admin admin = new Model.Admin();
            BLL.AdminManager adminManager = new AdminManager();
            DropDownList_Distribution.DataTextField = "adminName";
            DropDownList_Distribution.DataValueField = "adminID";
            DataSet ds = new AdminManager().GetAllList();
            DataRow dr = ds.Tables[0].NewRow();
            dr["adminID"] = 0;
            dr["adminName"] = "---请选择---";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            DropDownList_Distribution.DataSource = ds;
            DropDownList_Distribution.DataBind();


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "getID")
            //{
            //    int RowIndex = Convert.ToInt32(e.CommandArgument);
            //    DataKey keys = GridView1.DataKeys[RowIndex];      //行中的数据;
            //    string perid = keys.Value.ToString();
            //    Labeltest.Text = perid;

            //}



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].ToString();//获得第一个单元格的值   

            string b = Convert.ToString(this.GridView1.DataKeys[row.DataItemIndex].Values[0]);//获得DataKeys的值   
            Labeltest.Text = b;


            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager Fmanager = new FeedbackManager();
            string Str1 = "feedbackID='" + Labeltest.Text + "'";
            string s = Fmanager.GetListID(Str1);
            LabelName.Text = s;

            GridView1.Columns[9].Visible = true;

        }

        protected void UpdateFeedback(object sender, EventArgs e)
        {
            Model.Distribution distribution = new Model.Distribution();
            BLL.DistributionManager manager = new DistributionManager();

            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());
            string handlers = DropDownList_Distribution.SelectedItem.Text;


            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager Fmanager = new FeedbackManager();

            feedback.feedbackID = Convert.ToInt32(Labeltest.Text.Trim());
            feedback.handler = handlers;
            string Str1 = "handler='" + handlers + "'";
            string Str2 = "feedbackID='" + Labeltest.Text.Trim() + "'";
            bool bo2 = Fmanager.UpdateHandler(Str1, Str2);
            if (bo2 == true)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                BindY();
                BindN();
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

       
        protected void Btn_Category_Click(object sender, EventArgs e)
        {
           
            Model.Feedback feedbackC = new Model.Feedback();
            BLL.FeedbackManager managerC = new FeedbackManager();
            int CID = Convert.ToInt32( DropDownList_Category.SelectedValue);
            string strC= "F.categoryID='" + CID + "'";
          //  List dsC = managerC.GetFeedbackByS(strC);   
                // if (dsC.Tables[0].Rows.Count > 0)
            
                GridView1.DataSource = managerC.GetFeedbackByS(strC);
                GridView1.DataBind();


            

            //else 
            //{

            //    Response.Write("<script language=javascript>alert('暂无该分类反馈！')</script>");
            //    Bind();

            //}


        }

        protected void btn_KeyWSearch_Click(object sender, EventArgs e)
        {
            Model.Feedback feedbackC = new Model.Feedback();
            BLL.FeedbackManager managerC = new FeedbackManager();
          //  int CID = Convert.ToInt32(DropDownList_Category.SelectedValue);
          //  string strC = "F.categoryID='" + CID + "'";

            string Keyword = txbSearch.Text;
            string strC = "F.Info like '%" + Keyword + "%'";
            //  List dsC = managerC.GetFeedbackByS(strC);   
            // if (dsC.Tables[0].Rows.Count > 0)
          //  string strC = "F.categoryID='" + CID + "'or F.Info like '%" + Keyword + "%'";
            GridView1.DataSource = managerC.GetFeedbackByS(strC);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
               
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.Columns[0].Visible = true;
        }

        protected void Btn_Choos_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].ToString();//获得第一个单元格的值   

            string b = Convert.ToString(this.GridView1.DataKeys[row.DataItemIndex].Values[0]);//获得DataKeys的值   
            Labeltest.Text = b;


            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager Fmanager = new FeedbackManager();
            string Str1 = "feedbackID='" + Labeltest.Text + "'";
            string s = Fmanager.GetListID(Str1);
            LabelName.Text = s;

            GridView2.Columns[9].Visible = true;
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{


        //    int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        //    string sno = GridView1.Rows[row].Cells[2].Text;
        //    string s = sno;
        //    Response.Write("<script>alert('" + sno + "')</script>");
        //}


    }
}
