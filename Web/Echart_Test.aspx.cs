using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace UserFB.Web
{
    public partial class Echart_Test : System.Web.UI.Page
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
                    data();
                }
            }
        }
        private void data()
        {

            lists = new List<object>();

            int a = 50;
            int b = 12;
            string c = "y";
            string d = "p";
            //var obj = new { names = "yuan", nums = a };
            //var obj1 = new { names = "yuan1", nums = b };

            var obj = new { names = c, nums = a };
            var obj1 = new { names =d , nums = b };
            lists.Add(obj);
            lists.Add(obj1);
            object JSONObj = (Object)JsonConvert.SerializeObject(lists);
            Response.Write(JSONObj);
          
            // Response.Write(JSONObj);
            //  一定要加，不然前端接收失败
            Response.End();
        }



        //public class Handler : IHttpHandler
        //{
        //    JavaScriptSerializer jsS = new JavaScriptSerializer();
        //    List<object> lists = new List<object>();
        //    string result = "";

        //    public void ProcessRequest(HttpContext context)
        //    {
        //        context.Response.ContentType = "text/plain";

        //        string method = context.Request["method"];
        //        if (!string.IsNullOrEmpty(method))
        //        {
        //            if (method == "getdata")
        //            {
        //                lists = new List<object>();

        //                var obj = new { names = "yuan", nums = 12 };
        //                var obj1 = new { names = "yuan1", nums = 19 };
        //                lists.Add(obj);
        //                lists.Add(obj1);


        //                jsS = new JavaScriptSerializer();
        //                result = jsS.Serialize(lists);
        //                context.Response.Write(result);
        //            }
        //        }
        //        //context.Response.Write("Hello World");
        //    }

        //    public bool IsReusable
        //    {
        //        get
        //        {
        //            return false;
        //        }
        //    }

    }
}


           
        

   
       




   
      
    
 
