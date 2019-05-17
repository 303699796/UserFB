using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace UserFB.Web.Chart_Analysis
{
    public partial class User_Analysis : System.Web.UI.Page
    {
        List<object> lists = new List<object>();
        string result = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string method = Request.QueryString["method"];
            if (!string.IsNullOrEmpty(method))
            {
                if (method == "getdata")
                {
                    GetGSexDataALL();
                    GetBSexDataALL();
                    data();
                }
            }

            //if (!IsPostBack)
            //{

            //    GetGSexDataALL();
            //    GetBSexDataALL();



            //}
        }

        private void data()
        {

            lists = new List<object>();

            int numG = GetGSexDataALL();
            int numB= GetBSexDataALL();
            string sexG = "女";
            string sexB = "男";
            var obj = new { names = sexG, nums = numG };
            var obj1 = new { names = sexB, nums = numB };
           
            lists.Add(obj);
            lists.Add(obj1);
            
            object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj);

            // Response.Write(JSONObj);
            //  一定要加，不然前端接收失败
            Response.End();
        }

        protected int GetGSexDataALL()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            //Model.Users users = new Model.Users();
            //BLL.UsersManager usersManager = new BLL.UsersManager();

            //string strG = "gender ='"+Label1.Text.Trim()+ "'";
            string StrAll = "gender='" + "女" + "'";
            int GnumAll = feedbackManager.GetRecordCountNum(StrAll);
            return GnumAll;
           
        }

        protected int GetBSexDataALL()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            //Model.Users users = new Model.Users();
            //BLL.UsersManager usersManager = new BLL.UsersManager();

            //string strG = "gender ='"+Label1.Text.Trim()+ "'";
            string StrAll = "gender='" + "男" + "'";
            int BnumAll = feedbackManager.GetRecordCountNum(StrAll);
            return BnumAll;
        }

        //protected int GetBSexDataMonth()
        //{
        //    Model.Feedback feedback = new Model.Feedback();
        //    BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
 
        //    DateTime StimeM = DateTime.Now.AddDays(-30).Date;
        //    DateTime EtimeM = DateTime.Now.AddDays(1).Date;

        //    string strTimeM = "feedbackTime>'" + StimeM + "'and feedbackTime<'" + EtimeM + "'";
        //    string StrM = "gender='" + "男" + "'";
        //    int BnumM = feedbackManager.GetRecordCountTime(StrM, strTimeM);
        //    return BnumM;
        //}

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

        private string GetSelIDList()
        {
            string v = "j";
            return v;
        }
    }
}