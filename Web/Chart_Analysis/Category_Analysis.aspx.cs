using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace UserFB.Web.Chart_Analysis
{
    public partial class Category_Analysis : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string method = Request.QueryString["method"];
            if (!string.IsNullOrEmpty(method))
            {
                if (method == "getdata")
                {
                    data();
                }
            }

            if (!IsPostBack)
            {
                Bind();
            }
           
        }

      

        private void data()
        {
            List<object> lists = new List<object>();
            List<object> listsC = new List<object>();
            string result = "";

        

           // lists = new List<object>();
            lists = new List<object>();

            DataSet data = GetGSexDataALL();
            lists.Add(data);

            object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj);


           // 一定要加，不然前端接收失败
            Response.End();

            //int a = 50;
            //int b = 12;
            //string c = "y";
            //string d = "p";
            ////var obj = new { names = "yuan", nums = a };
            ////var obj1 = new { names = "yuan1", nums = b };

            //var obj = new { names = c, nums = a };
            //var obj1 = new { names = d, nums = b };
            //lists.Add(obj);
            //lists.Add(obj1);
            //object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            //Response.Write(JSONObj);


            ////  一定要加，不然前端接收失败
            //Response.End();
        }


        protected DataSet GetGSexDataALL()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            //Model.Users users = new Model.Users();
            //BLL.UsersManager usersManager = new BLL.UsersManager();

            //string strG = "gender ='"+Label1.Text.Trim()+ "'";
            string StrAll = "";
            DataSet ds = feedbackManager.GetList(StrAll);
            //DataSet ds = new CategoryManager().GetAllList();
            return ds;

        }

        protected  void FunctionToComboBox(DataSet ds, DropDownList dropDownList)
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            //Model.Users users = new Model.Users();
            //BLL.UsersManager usersManager = new BLL.UsersManager();

            //string strG = "gender ='"+Label1.Text.Trim()+ "'";
            string StrAll = "";
            DataSet data = feedbackManager.GetList(StrAll);


           
            //DropDownList1.Items.Clear();

            //for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            //{
            //    DropDownList1.Items.Add(Convert.ToString( data.Tables[0].Rows[i][0]));
            //}

        }

        protected void Bind()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            GridView1.DataSource = feedbackManager.GetAllFeedback();
            GridView1.DataBind();
            Label1.Text = GridView1.Rows[0].Cells[0].Text;
        }

        protected void Btn_Today_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Yesterday_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_7days_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Month_Click(object sender, EventArgs e)
        {

        }
    }
}