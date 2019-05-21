using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;
using UserFB.BLL;
using UserFB.Model;

namespace UserFB.Web.Setting
{
    public partial class Question_Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!Page.IsPostBack)
            {
                //gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                //gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                //btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
                BindData();
               CategoryDataBind();
                GetLoginName();
                


            }
        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
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
            DropDownList_Category.DataSource = ds;
            DropDownList_Category.DataBind();

        }
       
        protected void Bind()
        {
           
            //Model.Question question1 = new Model.Question();
            //BLL.QuestionManager question2 = new BLL.QuestionManager();
            //GridView1.DataSource = question2.GetAllList();
            //GridView1.DataBind();

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "background:#FFF");
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
            //    linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");


            //}
        }

        protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            Model.Question question1 = new Model.Question();
            BLL.QuestionManager question2 = new BLL.QuestionManager();
            question2.DeleteList(idlist);
          
            BindData();
        }
        public void BindData()
        {
            Model.Question question1 = new Model.Question();
            BLL.QuestionManager question2 = new BLL.QuestionManager();
           

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            
            ds = question2.GetList(strWhere.ToString());
            gridView.DataSource = ds;
            gridView.DataBind();
        }
        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                  
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        protected void BntSave_Click(object sender, EventArgs e)
        {

            Model.Question question = new Model.Question();
            question.question = txtQuestion.Text.Trim();
            question.solution = txtSolution.Text.Trim();
            question.categoryID =Convert.ToInt32( DropDownList_Category.SelectedValue.ToString());

            BLL.QuestionManager questionManager = new BLL.QuestionManager();
            bool bo = questionManager.Add(question);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('添加成功！')</script>");
                BindData();
            }
            else
            {
                Response.Write("<script language=javascript>alert('添加失败！请重试')");
            }

           
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            BindData();
          //  CategoryModifyBind(e.NewEditIndex);
        }
        //private void CategoryModifyBind(int questionID)
        //{
        //    DropDownList list = gridView.Rows[questionID].FindControl("DDL_Category") as DropDownList;
        //    BLL.CategoryManager categoryM = new CategoryManager();
         



        //}


        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            BindData();
        }

        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Model.Question question = new Model.Question();
            question.question = (gridView.Rows[e.RowIndex].FindControl("txtQuestion") as TextBox).Text;
            question.solution=(gridView.Rows[e.RowIndex].FindControl("txtSolution") as TextBox).Text;
            question.questionID = Convert.ToInt32(gridView.DataKeys[e.RowIndex].Value);
            question.categoryID=Int32.Parse((gridView.Rows[e.RowIndex].FindControl("txtCcategory") as TextBox).Text); 

            BLL.QuestionManager questionManager = new BLL.QuestionManager();
            bool bo = questionManager.Update(question);
            if (bo == true)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                gridView.EditIndex = -1;
                BindData();
            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！请重试')");
            }
            
        }
    }
}