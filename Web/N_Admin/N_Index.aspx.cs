using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace UserFB.Web.N_Admin
{
    public partial class N_Index : System.Web.UI.Page
    {
        Model.Feedback feedback = new Model.Feedback();
        BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

        List<object> lists = new List<object>();
        string result = "";


        protected void Page_Load(object sender, EventArgs e)
        {



            string method = Request.QueryString["method"];

            if (!IsPostBack)
            {
                GetLoginName();

                Getdata();
                GetDay1();
                GetDay2();
                GetDay3();
                GetDay4();
                GetDay5();
                GetDay6();
                GetDay7();

                GetRows1();
                GetRows2();
                GetRows3();
                GetRows4();
                GetRows5();
                GetRows6();
                GetRows7();
                GetSolution();


            }

            if (!string.IsNullOrEmpty(method))
            {
                if (method == "getdata")
                {
                    GetNumber();

                }
            }



        }
        protected void GetLoginName()
        {
    
            LabelUser.Text = Convert.ToString(Session["NadminName"]);
         
        }



        protected void Getdata()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

            //今天数据
            //  string Day1 = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            DateTime Stime1 = DateTime.Now.AddDays(0).Date;
            DateTime Etime1 = DateTime.Now.AddDays(1).Date;
            string strWhere1 = "feedbackTime>'" + Stime1 + "'and feedbackTime<'" + Etime1 + "'";
            int rows1 = feedbackManager.GetRecordCount(strWhere1);
            LabelDdayNum.Text = rows1.ToString();

            //  LabelDay1.Text = Day1;
            LabelNum1.Text = rows1.ToString();


            string Day1 = GetDay1();

            //昨天数据
            string Day2 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            DateTime Stime2 = DateTime.Now.AddDays(-1).Date;
            DateTime Etime2 = DateTime.Now.AddDays(0).Date;
            string strWhere2 = "feedbackTime>'" + Stime2 + "'and feedbackTime<'" + Etime2 + "'";
            int rows2 = feedbackManager.GetRecordCount(strWhere2);
            LabelYdayNum.Text = rows2.ToString();

            LabelDay2.Text = Day2;
            LabelNum2.Text = rows2.ToString();

        }

        protected string GetDay1()
        {
            string Day1 = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            LabelDay1.Text = Day1;
            return Day1;
        }
        protected string GetDay2()
        {
            string Day2 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            LabelDay2.Text = Day2;
            return Day2;
        }

        protected string GetDay3()
        {
            string Day3 = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            LabelDay3.Text = Day3;
            return Day3;
        }

        protected string GetDay4()
        {
            string Day4 = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            LabelDay4.Text = Day4;
            return Day4;
        }

        protected string GetDay5()
        {
            string Day5 = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd");
            LabelDay5.Text = Day5;
            return Day5;
        }

        protected string GetDay6()
        {
            string Day6 = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
            LabelDay6.Text = Day6;
            return Day6;
        }
        protected string GetDay7()
        {
            string Day7 = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            LabelDay7.Text = Day7;
            return Day7;
        }

        protected int GetRows1()
        {
            DateTime Stime1 = DateTime.Now.AddDays(0).Date;
            DateTime Etime1 = DateTime.Now.AddDays(1).Date;
            string strWhere1 = "feedbackTime>'" + Stime1 + "'and feedbackTime<'" + Etime1 + "'";
            int rows1 = feedbackManager.GetRecordCount(strWhere1);
            LabelYdayNum.Text = rows1.ToString();
            LabelNum1.Text = rows1.ToString();
            return rows1;
        }

        protected int GetRows2()
        {
            DateTime Stime2 = DateTime.Now.AddDays(-1).Date;
            DateTime Etime2 = DateTime.Now.AddDays(0).Date;
            string strWhere2 = "feedbackTime>'" + Stime2 + "'and feedbackTime<'" + Etime2 + "'";
            int rows2 = feedbackManager.GetRecordCount(strWhere2);
            LabelYdayNum.Text = rows2.ToString();

            LabelNum2.Text = rows2.ToString();
            return rows2;
        }

        protected int GetRows3()
        {
            DateTime Stime3 = DateTime.Now.AddDays(-2).Date;
            DateTime Etime3 = DateTime.Now.AddDays(-1).Date;
            string strWhere3 = "feedbackTime>'" + Stime3 + "'and feedbackTime<'" + Etime3 + "'";
            int rows3 = feedbackManager.GetRecordCount(strWhere3);

            LabelNum3.Text = rows3.ToString();
            return rows3;
        }

        protected int GetRows4()
        {
            DateTime Stime4 = DateTime.Now.AddDays(-3).Date;
            DateTime Etime4 = DateTime.Now.AddDays(-2).Date;
            string strWhere4 = "feedbackTime>'" + Stime4 + "'and feedbackTime<'" + Etime4 + "'";
            int rows4 = feedbackManager.GetRecordCount(strWhere4);

            LabelNum4.Text = rows4.ToString();
            return rows4;
        }


        protected int GetRows5()
        {
            DateTime Stime5 = DateTime.Now.AddDays(-4).Date;
            DateTime Etime5 = DateTime.Now.AddDays(-3).Date;
            string strWhere5 = "feedbackTime>'" + Stime5 + "'and feedbackTime<'" + Etime5 + "'";
            int rows5 = feedbackManager.GetRecordCount(strWhere5);

            LabelNum5.Text = rows5.ToString();
            return rows5;
        }


        protected int GetRows6()
        {
            DateTime Stime6 = DateTime.Now.AddDays(-5).Date;
            DateTime Etime6 = DateTime.Now.AddDays(-4).Date;
            string strWhere6 = "feedbackTime>'" + Stime6 + "'and feedbackTime<'" + Etime6 + "'";
            int rows6 = feedbackManager.GetRecordCount(strWhere6);

            LabelNum6.Text = rows6.ToString();
            return rows6;
        }


        protected int GetRows7()
        {
            DateTime Stime7 = DateTime.Now.AddDays(-6).Date;
            DateTime Etime7 = DateTime.Now.AddDays(-5).Date;
            string strWhere7 = "feedbackTime>'" + Stime7 + "'and feedbackTime<'" + Etime7 + "'";
            int rows7 = feedbackManager.GetRecordCount(strWhere7);

            LabelNum7.Text = rows7.ToString();

            return rows7;
        }



        public void GetNumber()
        {


           


            string Day1 = GetDay1();
            string Day2 = GetDay2();
            string Day3 = GetDay3();
            string Day4 = GetDay4();
            string Day5 = GetDay5();
            string Day6 = GetDay6();
            string Day7 = GetDay7();


            int rows1 = GetRows1();
            int rows2 = GetRows2();
            int rows3 = GetRows3();
            int rows4 = GetRows4();
            int rows5 = GetRows5();
            int rows6 = GetRows6();
            int rows7 = GetRows7();


            lists = new List<object>();


            var obj = new { names = Day7, nums = rows7 };
            var obj1 = new { names = Day6, nums = rows6 };
            var obj2 = new { names = Day5, nums = rows5 };
            var obj3 = new { names = Day4, nums = rows4 };
            var obj4 = new { names = Day3, nums = rows3 };
            var obj5 = new { names = Day2, nums = rows2 };
            var obj6 = new { names = Day1, nums = rows1 };

            lists.Add(obj);
            lists.Add(obj1);
            lists.Add(obj2);
            lists.Add(obj3);
            lists.Add(obj4);
            lists.Add(obj5);
            lists.Add(obj6);


            object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj);
          
            //  一定要加，不然前端接收失败
            Response.End();


        }

        protected void GetSolution()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

            DateTime StimeW = DateTime.Now;
            DateTime EtimeW = DateTime.Now.AddDays(0).Date;

            string strWhere5 = "feedbackTime>'" + StimeW + "'and feedbackTime<'" + EtimeW + "'and solutionState='" + "1" + "'";
            int rows5 = feedbackManager.GetRecordCount(strWhere5);

            LabelWSolve.Text = rows5.ToString();
            int Sum = feedbackManager.GetAllRecordCount();
            int NSolve = Sum - rows5;
            LabelNSolve.Text = Convert.ToString(NSolve);
        }

    }
}