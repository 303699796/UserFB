using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFB.BLL;

namespace UserFB.Web.G_Admin_List
{
    public partial class G_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewBind();
                HisBind();
                GetLoginName();



            }
        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["GadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }


        protected void NewBind()
        {
            Model.Distribution distribution = new Model.Distribution();
            BLL.DistributionManager manager = new BLL.DistributionManager();
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["GadminID"].ToString());
       
            int ID= Convert.ToInt32(admin1.adminID);          
            string Str = " adminID='" + ID + "'and state !=  '" + "1" + "'";       
            GridView1.DataSource = manager.GetList(Str);
            GridView1.DataBind();
        }


        protected void HisBind()
        {
            Model.Distribution distribution = new Model.Distribution();
            BLL.DistributionManager manager = new BLL.DistributionManager();
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["GadminID"].ToString());

            int ID = Convert.ToInt32(admin1.adminID);

            string Str = " adminID='" + ID + "'and state =  '" + "1" + "'";
            GridView2.DataSource = manager.GetList(Str);
            GridView2.DataBind();
        }

        private string GetSelIDList()
        {
            string idList = "";
            bool boxChecked = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkBox = (CheckBox)GridView1.Rows[i].FindControl("ModifyThis");
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


        protected void Btn_Solve_Click(object sender, EventArgs e)
        {
            string state = "1";
            string idList = GetSelIDList();
            if (idList.Trim().Length == 0)
            {
                return;
            }
            BLL.DistributionManager manager = new BLL.DistributionManager();
            manager.UpdateList(state, idList);
            Response.Write("<script language=javascript>alert('标记成功！')</script>");
            NewBind();
            HisBind();


            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager Fmanager = new FeedbackManager();


            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["GadminID"].ToString());
            int ID = Convert.ToInt32(admin1.adminID);

            string Str1 = "solutionState='" + state + "'";
            string Str2 = "adminID='" + ID + "' and  state =  '" + state + "'";
            Fmanager.UpdateSolution(Str1, Str2);


        }

        protected void Btn_Block_Click(object sender, EventArgs e)
        {
            string state = "2";
            string idList = GetSelIDList();
            if (idList.Trim().Length == 0)
            {
                return;
            }
            Model.Distribution distribution = new Model.Distribution();
            BLL.DistributionManager manager = new BLL.DistributionManager();
            manager.UpdateList(state, idList);
            Response.Write("<script language=javascript>alert('标记成功！')</script>");

            NewBind();
            HisBind();

            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager Fmanager = new FeedbackManager();


            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["GadminID"].ToString());
            int ID = Convert.ToInt32(admin1.adminID);

            string Str1 = "solutionState='" + state + "'";
            string Str2 = "adminID='" + ID + "'and state =  '" + state + "'";
             Fmanager.UpdateSolution(Str1, Str2);
  
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#D1EEEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
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
