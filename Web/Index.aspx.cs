﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace UserFB.Web
{
    public partial class Index : System.Web.UI.Page
    {

        List<object> lists = new List<object>();
        string result = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {



            string method = Request.QueryString["method"];

            if (!IsPostBack)
            {

                Getdata();
               


            }

            if (!string.IsNullOrEmpty(method))
            {
                if (method == "getdata")
                {
                    GetNumber();
                    
                }
            }


           
        }

        

            protected void Getdata()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

            //今天数据
            string Day1 = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            DateTime Stime1 = DateTime.Now.AddDays(0).Date;
            DateTime Etime1 = DateTime.Now.AddDays(1).Date;
            string strWhere1 = "feedbackTime>'" + Stime1 + "'and feedbackTime<'" + Etime1 + "'";
            int rows1 = feedbackManager.GetRecordCount(strWhere1);
            LabelDdayNum.Text = rows1.ToString();

            LabelDay1.Text = Day1;
            LabelNum1.Text = rows1.ToString();

            //昨天数据
            string Day2 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            DateTime Stime2 = DateTime.Now.AddDays(-1).Date;
            DateTime Etime2 = DateTime.Now.AddDays(0).Date;
            string strWhere2 = "feedbackTime>'" + Stime2 + "'and feedbackTime<'" + Etime2 + "'";
            int rows2 = feedbackManager.GetRecordCount(strWhere2);
            LabelYdayNum.Text = rows2.ToString();

            LabelDay2.Text = Day2;
            LabelNum2.Text = rows2.ToString();

            //前第3天
            string Day3 = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            DateTime Stime3 = DateTime.Now.AddDays(-2).Date;
            DateTime Etime3 = DateTime.Now.AddDays(-1).Date;
            string strWhere3 = "feedbackTime>'" + Stime3 + "'and feedbackTime<'" + Etime3 + "'";
            int rows3 = feedbackManager.GetRecordCount(strWhere3);
            LabelDay3.Text = Day3;
            LabelNum3.Text = rows3.ToString();

            //前第4天
            string Day4 = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            DateTime Stime4 = DateTime.Now.AddDays(-3).Date;
            DateTime Etime4 = DateTime.Now.AddDays(-2).Date;
            string strWhere4 = "feedbackTime>'" + Stime4 + "'and feedbackTime<'" + Etime4 + "'";
            int rows4 = feedbackManager.GetRecordCount(strWhere4);
            LabelDay4.Text = Day4;
            LabelNum4.Text = rows4.ToString();

            //前第5天
            string Day5 = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd");
            DateTime Stime5 = DateTime.Now.AddDays(-4).Date;
            DateTime Etime5 = DateTime.Now.AddDays(-3).Date;
            string strWhere5 = "feedbackTime>'" + Stime5 + "'and feedbackTime<'" + Etime5 + "'";
            int rows5 = feedbackManager.GetRecordCount(strWhere5);
            LabelDay5.Text = Day5;
            LabelNum5.Text = rows5.ToString();

            //前第6天
            string Day6 = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
            DateTime Stime6 = DateTime.Now.AddDays(-5).Date;
            DateTime Etime6 = DateTime.Now.AddDays(-4).Date;
            string strWhere6 = "feedbackTime>'" + Stime6 + "'and feedbackTime<'" + Etime6 + "'";
            int rows6 = feedbackManager.GetRecordCount(strWhere6);
            LabelDay6.Text = Day6;
            LabelNum6.Text = rows6.ToString();

            //前第7天
            string Day7 = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            DateTime Stime7 = DateTime.Now.AddDays(-6).Date;
            DateTime Etime7 = DateTime.Now.AddDays(-5).Date;
            string strWhere7 = "feedbackTime>'" + Stime7 + "'and feedbackTime<'" + Etime7 + "'";
            int rows7 = feedbackManager.GetRecordCount(strWhere7);
            LabelDay7.Text = Day7;
            LabelNum7.Text = rows7.ToString();

        }



        public void GetNumber()
        {

            
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();

            //今天数据
            string Day1= DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            DateTime Stime1 = DateTime.Now.AddDays(0).Date;
            DateTime Etime1 = DateTime.Now.AddDays(1).Date;
            string strWhere1 = "feedbackTime>'" + Stime1 + "'and feedbackTime<'" + Etime1 + "'";
            //PublicClass.rows1 = feedbackManager.GetRecordCount(strWhere1);
            //LabelDdayNum.Text = PublicClass.rows1.ToString();
            int rows1 = feedbackManager.GetRecordCount(strWhere1);
            LabelYdayNum.Text = rows1.ToString();
            LabelDay1.Text = Day1;
            LabelNum1.Text = rows1.ToString();


            //昨天数据
            string Day2 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            DateTime Stime2 = DateTime.Now.AddDays(-1).Date;
            DateTime Etime2 = DateTime.Now.AddDays(0).Date;
            string strWhere2 = "feedbackTime>'" + Stime2 + "'and feedbackTime<'" + Etime2 + "'";
            int rows2 = feedbackManager.GetRecordCount(strWhere2);
            LabelYdayNum.Text = rows2.ToString();
            LabelDay2.Text = Day2;
            LabelNum2.Text = rows2.ToString();


            //前第3天
            string Day3 = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            DateTime Stime3 = DateTime.Now.AddDays(-2).Date;
            DateTime Etime3 = DateTime.Now.AddDays(-1).Date;
            string strWhere3 = "feedbackTime>'" + Stime3 + "'and feedbackTime<'" + Etime3 + "'";
            int rows3 = feedbackManager.GetRecordCount(strWhere3);
            LabelDay3.Text = Day3;
            LabelNum3.Text = rows3.ToString();

            //前第4天
            string Day4 = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            DateTime Stime4 = DateTime.Now.AddDays(-3).Date;
            DateTime Etime4 = DateTime.Now.AddDays(-2).Date;
            string strWhere4 = "feedbackTime>'" + Stime4 + "'and feedbackTime<'" + Etime4 + "'";
            int rows4 = feedbackManager.GetRecordCount(strWhere4);
            LabelDay4.Text = Day4;
            LabelNum4.Text = rows4.ToString();

            //前第5天
            string Day5 = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd");
            DateTime Stime5 = DateTime.Now.AddDays(-4).Date;
            DateTime Etime5 = DateTime.Now.AddDays(-3).Date;
            string strWhere5 = "feedbackTime>'" + Stime5 + "'and feedbackTime<'" + Etime5 + "'";
            int rows5 = feedbackManager.GetRecordCount(strWhere5);
            LabelDay5.Text = Day5;
            LabelNum5.Text = rows5.ToString();

            //前第6天
            string Day6 = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
            DateTime Stime6 = DateTime.Now.AddDays(-5).Date;
            DateTime Etime6 = DateTime.Now.AddDays(-4).Date;
            string strWhere6 = "feedbackTime>'" + Stime6 + "'and feedbackTime<'" + Etime6 + "'";
            int rows6 = feedbackManager.GetRecordCount(strWhere6);
            LabelDay6.Text = Day6;
            LabelNum6.Text = rows6.ToString();

            //前第7天
            string Day7 =DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            DateTime Stime7 = DateTime.Now.AddDays(-6).Date;
            DateTime Etime7 = DateTime.Now.AddDays(-5).Date;
            string strWhere7 = "feedbackTime>'" + Stime7 + "'and feedbackTime<'" + Etime7 + "'";
            int rows7 = feedbackManager.GetRecordCount(strWhere7);
            LabelDay7.Text = Day7;
            LabelNum7.Text = rows7.ToString();



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

            // Response.Write(JSONObj);
            //  一定要加，不然前端接收失败
            Response.End();


        }

        //protected void GetTable()
        //{
        //    LabelDay1.Text = PublicClass.Day1;
        //    LabelNum1.Text = PublicClass.rows1.ToString();

        //    LabelDay1.Text = PublicClass.Day2;
        //    LabelNum1.Text = PublicClass.rows2.ToString();
        //}





    }
}