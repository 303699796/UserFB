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
        BLL.FeedbackManager  feedbackManager = new BLL.FeedbackManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                CategoryDataBind();
            }
        }
        protected void Bind()
        {
            GridView1.DataSource = feedbackManager.GetAllFeedback();
            GridView1.DataBind();
        }

        private void CategoryDataBind()
        {
           
            DataSet ds = new CategoryManager().GetAllList();
            DataRow dr = ds.Tables[0].NewRow();
            dr["category"] = "--请选择--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            DropDownList_Category.DataTextField = "category";
            DropDownList_Category.DataValueField = "category";
            DropDownList_Category.DataSource = ds;
            DropDownList_Category.DataBind();
        }

       

        protected void btn_Search_Click(object sender, EventArgs e)
        {

        }

        protected void btn_End_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Star_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Invalid_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Dealwith_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar_End_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar_Star_SelectionChanged(object sender, EventArgs e)
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

            Bind();
        }
    }
}