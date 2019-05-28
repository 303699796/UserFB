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
                Segment();
                GetLoginName();
                ApplyNumber();
                ReplyNumber();
                GBind();
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

        protected void GBind()
        {
            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
            GridView1.DataSource = feedbackManager.GetAllFeedback();
            GridView1.DataBind();
        }

        private void GridExport(DataTable dt, string strFile, string strAppType)
        {
          // string strAppType = "";
            //switch (strExt)
            //{
            //    case "xls":
            //        strAppType = "application/ms-excel";
            //        break;
            //    case "doc":
            //        strAppType = "application/ms-word";
            //        break;
            //    case "txt":
                   strAppType = "application/ms-txt";
            //        break;
            //    case "html":
            //    case "htm":
            //        strAppType = "application/ms-html";
            //        break;
            //    default: return;
            //}
            //GridView MyGridView = new GridView();
            //MyGridView.DataSource = dt;
            //MyGridView.DataBind();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Buffer = true;
            //HttpContext.Current.Response.AddHeader("Content-Type", "text/html; charset=GB2312");
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.{1}", HttpUtility.UrlEncode(strFile, Encoding.GetEncoding("GB2312")), strAppType));
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //HttpContext.Current.Response.ContentType =" application / ms - txt";
            ////MyGridView.Page.EnableViewState = false;
            ////二、定义一个输入流
            //System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
            //System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
            //System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            ////三、将目标数据绑定到输入流输出
            //GridView1.RenderControl(oHtmlTextWriter);
            //HttpContext.Current.Response.Write(oStringWriter.ToString());
            //HttpContext.Current.Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Buffer = true;
            //HttpContext.Current.Response.AddHeader("Content-Type", "text/html; charset=GB2312");
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.{1}", HttpUtility.UrlEncode("001", Encoding.GetEncoding("GB2312")), "xlsx"));
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //HttpContext.Current.Response.ContentType = "application/ms-txt";
            //Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=GB2312/>");
            //GridView1.Page.EnableViewState = false;
            ////二、定义一个输入流
            //System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
            //System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
            //System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            ////三、将目标数据绑定到输入流输出
            //GridView1.RenderControl(oHtmlTextWriter);
            //HttpContext.Current.Response.Write(oStringWriter.ToString());
            //HttpContext.Current.Response.End();


            //Response.Clear();
            //Response.Buffer = false;
            //Response.Charset = "GB2312";
            //DateTime dt = System.DateTime.Now;
            //string str = dt.ToString("yyyyMMddhhmmss");
            //// str = str + ".xls";
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".xlsx");

            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel";

            //Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=GB2312/>");
            //this.EnableViewState = false;
            //System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            //HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            //GridView1.RenderControl(oHtmlTextWriter);
            //Response.Write(oStringWriter.ToString());
            //Response.End();

            Model.Feedback feedback = new Model.Feedback();
            BLL.FeedbackManager feedbackManager = new BLL.FeedbackManager();
           DataSet ds = feedbackManager.GetAllList();

            //Response.Clear();
            //Response.Buffer = false;
            //Response.Charset = "GB2312";
            //DateTime dt = System.DateTime.Now;
            //string str = dt.ToString("yyyyMMddhhmmss");
            //// str = str + ".xls";
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".xlsx");

            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel";

            //Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=GB2312/>");
            //this.EnableViewState = false;
            //System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            //HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            //ds.RenderControl(oHtmlTextWriter);
            //Response.Write(oStringWriter.ToString());
            //Response.End();



            Response.Clear();
            Response.Buffer = false;
            Response.Charset = "GB2312";
            DateTime dt = System.DateTime.Now;
            string str = dt.ToString("yyyyMMddhhmmss");
            // str = str + ".xls";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");

            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/ms-txt";
            Response.Write("<meta http-equiv=Content-Type;content=/text/html;charset=GB2312/>");

            // HttpContext.Current.Response.Clear（）;
            // string FileName = fileName +“。txt”;
            // HttpContext.Current.Response.Buffer = true;
            // HttpContext.Current.Response.Charset =“GB2312”;
            //   HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
            //  HttpContext.Current.Response.AppendHeader（“Content - Disposition”，“attachment; filename =”+HttpUtility.UrlEncode（FileName，Encoding.UTF8）.ToString（））;
            //  HttpContext.Current.Response.ContentType =“application / ms - text”;
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
            //base.VerifyRenderingInServerForm(control);
        }
    }
}