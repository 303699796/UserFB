using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserFB.Web.N_Admin
{
    public partial class Apply_Permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Bind()
        {
            Model.Question question1 = new Model.Question();
            BLL.QuestionManager question2 = new BLL.QuestionManager();
            GridView1.DataSource = question2.GetAllList();
            GridView1.DataBind();
        }
    }
}