using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using UserFB.BLL;
using System.Data;
using System.Text;
using NPOI.HSSF.UserModel;
using System.Runtime.InteropServices;
using Maticsoft.Common;
using NPOI.SS.Util;


namespace UserFB.Web.Chart_Analysis
{
    public partial class Keywords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Bind();
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


        private void Bind()
        {
            try
            {       
                string sAruments = @"../keyword.py";//要处理的python文件名
                RunPythonScript(sAruments);
                Image1.ImageUrl = "../Images/wordcloud.png";
                Image2.ImageUrl = "../Images/number_1.png";


            }
            catch (SystemException ex)
            {

                Response.Write("<script language=javascript>alert('加载失败！请重试')");
            }
        }

      


        public static void RunPythonScript(string sArgName)
        {
            Process p = new Process();
            string path = @"../keyword.py";// 待处理python文件的路径
         

            string sArguments = path;
       
            //启动一个进程来执行脚本文件设置参数 

            p.StartInfo.FileName = @"D:/python3.7/python.exe"; 

            p.StartInfo.Arguments = sArguments;

            Console.WriteLine(sArguments);

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();//启动进程 
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

     

        protected void Button1_Click(object sender, EventArgs e)
        {
          
        //    Model.Feedback feedback = new Model.Feedback();
        //    BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
        //    DataSet ds = feedbackManager.GetTXTList();
        //    Response.Clear();
        //    Response.Buffer = false;
        //    Response.Charset = "utf - 8"; 
        //    DateTime dt = System.DateTime.Now;
        //    string str = dt.ToString("yyyyMMddhhmmss");    
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");
        //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //    Response.ContentType = "application/ms-txt";
        //    Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=utf-8/>");
          
        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //        for(int j = 0; j < ds.Tables[0].Columns.Count; j++)
        //    {
        //            sw.WriteLine(ds.Tables[0].Rows[i][j].ToString().Trim()+"\t");
        //        }
        //        sw.WriteLine("\r \n");
        //    }
        //    HttpContext.Current.Response.Write(sw.ToString());
        //    sw.Close();
        //    HttpContext.Current.Response.End();
       
    }

        protected void Gettxt()
        {
                Model.Feedback feedback = new Model.Feedback();
                BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
                DataSet ds = feedbackManager.GetTXTList();
                Response.Clear();
                Response.Buffer = false;
                Response.Charset = "utf - 8"; 
                DateTime dt = System.DateTime.Now;
                string str = dt.ToString("yyyyMMddhhmmss");    
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                Response.ContentType = "application/ms-txt";
                Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=utf-8/>");

                System.IO.StringWriter sw = new System.IO.StringWriter();
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                    for(int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                        sw.WriteLine(ds.Tables[0].Rows[i][j].ToString().Trim()+"\t");
                    }
                    sw.WriteLine("\r \n");
                }
                HttpContext.Current.Response.Write(sw.ToString());
                sw.Close();
                HttpContext.Current.Response.End();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }
    }
}