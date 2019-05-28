using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using UserFB.BLL;

namespace UserFB.Web.Chart_Analysis
{
    public partial class User_Analysis : System.Web.UI.Page
    {
        List<object> lists = new List<object>();
        string result = "";
        string result1 = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string method = Request.QueryString["method"];
            if (!string.IsNullOrEmpty(method))
            {
                if (method == "getdata")
                {

                    dataGender();
                }
            }

            string method1 = Request.QueryString["method1"];
            if (!string.IsNullOrEmpty(method1))
            {
                if (method1 == "getdata1")
                {
                    dataAge();
                }
            }

            if (!IsPostBack)
            {

                GetAge1();
                GetPro();
                GetAgeTable();
                GetAgeTable();
                GetLoginName();
                ApplyNumber();
                ReplyNumber();
            }
        }

        protected void GetLoginName()
        {
            BLL.AdminManager adminManager1 = new BLL.AdminManager();
            Model.Admin admin1 = adminManager1.GetModel1(Session["SadminID"].ToString());

            LabelUser.Text = admin1.adminName;
        }


        private void dataGender()
        {

            lists = new List<object>();

            int numG = GetGSexDataALL();
            int numB= GetBSexDataALL();
            
            string sexG = "女";
            string sexB = "男";
            var obj = new { names = sexG, nums = numG };
            var obj1 = new { names = sexB, nums =numB };
           
            lists.Add(obj);
            lists.Add(obj1);
            
            object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj);

            // Response.Write(JSONObj);
            //  一定要加，不然前端接收失败
            Response.End();
        }
        protected void GetPro()
        {
            int numG = GetGSexDataALL();
            int numB = GetBSexDataALL();
            int All = numG + numB;
            double GPro =numG / (All * 1.00);           
            string resultG = GPro.ToString("p");//保留两位小数
            double BPro = numB / (All * 1.00);
            string resultB = BPro.ToString("p");

            LabelGnumPro.Text =Convert.ToString( resultG);
            LabelGnum.Text = Convert.ToString(numG);
            LabelGirl.Text = "女";
            LabelBnum.Text = Convert.ToString(numB);
            LabelBnumPro.Text = Convert.ToString(resultB);
            LabelBoy.Text = "男";
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


        private void dataAge()
        {

            lists = new List<object>();

            int Age1 = GetAge1();
            int Age2 = GetAge2();
            int Age3 = GetAge3();
            int Age4 = GetAge4();
            int Age5 = GetAge5();
            int Age6 = GetAge6();

            string range1 = "12岁以下";
            string range2 = "13-17岁";
            string range3 = "18-25岁";
            string range4 = "26-35岁";
            string range5 = "36岁-45岁";
            string range6 = "46岁以上";

          

            var obj1 = new { names1 = range1, nums1 = Age1 };
            var obj2 = new { names1 = range2, nums1 = Age2 };
            var obj3 = new { names1 = range3, nums1 = Age3 };
            var obj4= new { names1 = range4, nums1 = Age4 };
            var obj5 = new { names1 = range5, nums1 = Age5 };
            var obj6 = new { names1 = range6, nums1 = Age6 };


         
            lists.Add(obj1);
            lists.Add(obj2);
            lists.Add(obj3);
            lists.Add(obj4);
            lists.Add(obj5);
            lists.Add(obj6);

            object JSONObj1 = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj1);

            // Response.Write(JSONObj);
            //  一定要加，不然前端接收失败
            Response.End();
        }

        protected void GetAgeTable()
        {
            int Age1 = GetAge1();
            int Age2 = GetAge2();
            int Age3 = GetAge3();
            int Age4 = GetAge4();
            int Age5 = GetAge5();
            int Age6 = GetAge6();

            string range1 = "12岁以下";
            string range2 = "13-17岁";
            string range3 = "18-25岁";
            string range4 = "26-35岁";
            string range5 = "36岁-45岁";
            string range6 = "46岁以上";

            LabelAge1.Text = Convert.ToString(Age1);
            LabelAge2.Text = Convert.ToString(Age2);
            LabelAge3.Text = Convert.ToString(Age3);
            LabelAge4.Text = Convert.ToString(Age4);
            LabelAge5.Text = Convert.ToString(Age5);
            LabelAge6.Text = Convert.ToString(Age6);

            Labelrange1.Text = range1;
            Labelrange2.Text = range2;
            Labelrange3.Text = range3;
            Labelrange4.Text = range4;
            Labelrange5.Text = range5;
            Labelrange6.Text = range6;

        }

        protected int GetAge1()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 0;
            int Str2 = 12;
            int CountNum1 = usersManager.GetAge(Str1,Str2);
            return CountNum1;
        }

        protected int GetAge2()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 13;
            int Str2 = 17;
            int CountNum2 = usersManager.GetAge(Str1, Str2);
            return CountNum2;
        }

        protected int GetAge3()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 18;
            int Str2 = 25;
            int CountNum3 = usersManager.GetAge(Str1, Str2);
            return CountNum3;
        }

        protected int GetAge4()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 26;
            int Str2 = 35;
            int CountNum4 = usersManager.GetAge(Str1, Str2);
            return CountNum4;
        }

        protected int GetAge5()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 36;
            int Str2 = 45;
            int CountNum5 = usersManager.GetAge(Str1, Str2);
            return CountNum5;
        }

        protected int GetAge6()
        {

            Model.Users users = new Model.Users();
            BLL.UsersManager usersManager = new BLL.UsersManager();
            int Str1 = 46;
            int Str2 = 100;
            int CountNum6 = usersManager.GetAge(Str1, Str2);
            return CountNum6;
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

        //private string GetSelIDList()
        //{
        //    string v = "j";
        //    return v;
        //}
    }
}