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

namespace UserFB.Web.Chart_Analysis
{
    public partial class Keywords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                Segment();
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
                string sAruments = @"2.7test1.py";//要处理的python文件名
                RunPythonScript(sAruments);
               // Image1.ImageUrl = "F:/weijie/UserFB/UserFB/Web/Images/beijing003.png";
               

            }
            catch (SystemException ex)
            {

                Response.Write("<script language=javascript>alert('加载失败！请重试')");
            }
        }

      


        public static void RunPythonScript(string sArgName)
        {
            Process p = new Process();
            string path = "F:/weijie/UserFB/UserFB/Web/Python/2.7test1.py";// 待处理python文件的路径
         

            string sArguments = path;
        

            //下面为启动一个进程来执行脚本文件设置参数 

            p.StartInfo.FileName = @"D:/Python/python2.7/python.exe"; //注意路径 

            p.StartInfo.Arguments = sArguments;//这样参数就是CUT.py 路径1 路径2 路径3....

            Console.WriteLine(sArguments);

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();//启动进程 
        }

        private void Segment()
        {
            try
            {
                string sAruments1 = @"test_txt.py";//要处理的python文件名
                RunPythonScript1(sAruments1);
                // Image1.ImageUrl = "F:/weijie/UserFB/UserFB/Web/Images/beijing003.png";


            }
            catch (SystemException ex)
            {

                Response.Write("<script language=javascript>alert('加载失败！请重试')");
            }
        }


        public static void RunPythonScript1(string sArgName)
        {
            Process p = new Process();
         
            string path1 = "F:/weijie/UserFB/UserFB/Web/Python/test_txt.py";// 待处理python文件的路径

           // string sArguments = path;
            string sArguments1 = path1;

            //下面为启动一个进程来执行脚本文件设置参数 

            p.StartInfo.FileName = @"D:/Python/python2.7/python.exe"; //注意路径 

            p.StartInfo.Arguments = sArguments1;//这样参数就是CUT.py 路径1 路径2 路径3....

            Console.WriteLine(sArguments1);

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
    }
}