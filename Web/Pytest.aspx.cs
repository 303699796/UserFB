using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace UserFB.Web
{
    public partial class Pytest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ScriptRuntime pyRunTime = Python.CreateRuntime();
            //dynamic obj = pyRunTime.UseFile("C:/Users/Weijie/Source/Repos/WebApplication1/WebApplication1/Python/ceshi3.py");
            //int val = obj.Strengthen_Money_WuQi(5, 2);
            ////MessageBox.Show(val + "");
            //TextBox1.Text = val + "";
            try
            {
                //ScriptEngine ssa = Python.CreateEngine();
                //ScriptScope ssb = ssa.CreateScope();
                //ScriptSource ssc = ssa.CreateScriptSourceFromFile("F:/weijie/UserFB/UserFB/Web/Python/2.7test1.py");
                //ssc.Execute(ssb);
                ////var result = ssc.Execute<object>("result");
                //var result = ssb.GetVariable<Func<object>>("result");
                //TextBox1.Text = result().ToString();
                ////Image1.ImageUrl = "F:/weijie/第二版/UFB/Web/Images/用户头像.jpg";


                string sAruments = @"2.7test1.py";//要处理的python文件名
                RunPythonScript(sAruments);


                //ScriptRuntime pyRuntime3 = Python.CreateRuntime(); //创建一下运行环境
                //var engine = pyRuntime3.GetEngine("python");
                //var pyScope = engine.CreateScope();
                //var paths = engine.GetSearchPaths();
                //paths.Add(@"F:/weijie/UserFB/UserFB/packages/IronPython.2.7.9/lib");
                //engine.SetSearchPaths(paths);
                //dynamic obj3 = pyRuntime3.UseFile("F:/weijie/UserFB/UserFB/Web/Python/newfile_jieba1.py"); //调用一个Python文件



            }
            catch (SystemException ex)
            {

                Response.Write("<script language=javascript>alert('申请失败！请重试')");
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



        protected void Button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ScriptEngine ssa = Python.CreateEngine();
            //    ScriptScope ssb = ssa.CreateScope();
            //    ScriptSource ssc = ssa.CreateScriptSourceFromFile("F:/weijie/UserFB/UserFB/Web/Python/2.7test1.py");
            //    ssc.Execute(ssb);
            //    //var result = ssc.Execute<object>("result");
            //    var result = ssb.GetVariable<Func<object>>("result");
            //    TextBox1.Text = result().ToString();
            //    Image1.ImageUrl = "F:/weijie/第二版/UFB/Web/Images/用户头像.jpg";
            //}
            //catch (SystemException ex)
            //{

            //    Response.Write("<script language=javascript>alert('申请失败！请重试')");
            //}
        }
    }
}
