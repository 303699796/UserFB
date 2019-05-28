using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using LTP.Accounts.Data;
using Maticsoft.Common;
using UserFB.BLL;
using UserFB.Model;
using System.Data;

namespace UserFB.Web.Login
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime tnow = DateTime.Now;//现在时间
            ArrayList AlYear = new ArrayList();
            int i;
            for (i = 2019; i >= 1960; i--)
                AlYear.Add(i);
            ArrayList AlMonth = new ArrayList();
            for (i = 1; i <= 12; i++)
                AlMonth.Add(i);
            if (!this.IsPostBack)
            {
                DropDownListYear.DataSource = AlYear;
                DropDownListYear.DataBind();//绑定年
                                            //选择当前年
                DropDownListYear.SelectedValue = tnow.Year.ToString();
                DropDownListMonth.DataSource = AlMonth;
                DropDownListMonth.DataBind();//绑定月
                                             //选择当前月
                DropDownListMonth.SelectedValue = tnow.Month.ToString();
                int year, month;
                year = Int32.Parse(DropDownListYear.SelectedValue);
                month = Int32.Parse(DropDownListMonth.SelectedValue);
                BindDays(year, month);//绑定天
                                      //选择当前日期
                DropDownListDay.SelectedValue = tnow.Day.ToString();
            }
        }


        //判断闰年
        private bool CheckLeap(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        //绑定每月的天数
        private void BindDays(int year, int month)
        {
            int i;
            ArrayList AlDay = new ArrayList();

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    for (i = 1; i <= 31; i++)
                        AlDay.Add(i);
                    break;
                case 2:
                    if (CheckLeap(year))
                    {
                        for (i = 1; i <= 29; i++)
                            AlDay.Add(i);
                    }
                    else
                    {
                        for (i = 1; i <= 28; i++)
                            AlDay.Add(i);
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    for (i = 1; i <= 30; i++)
                        AlDay.Add(i);
                    break;
            }
            DropDownListDay.DataSource = AlDay;
            DropDownListDay.DataBind();
        }



        //选择年
        private void DropDownListYear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int year, month;
            year = Int32.Parse(DropDownListYear.SelectedValue);
            month = Int32.Parse(DropDownListMonth.SelectedValue);
            BindDays(year, month);
        }
        //选择月


        private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int year, month;
            year = Int32.Parse(DropDownListYear.SelectedValue);
            month = Int32.Parse(DropDownListMonth.SelectedValue);
            BindDays(year, month);

        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            Model.Users users = new Model.Users();
            users.userName = txbUserName.Text;
            users.password = txbPassword1.Text;
            users.gender = DropDownList1.SelectedItem.Text;

            string date = DropDownListYear.SelectedItem.Text.Trim().ToString() + "/" + DropDownListMonth.SelectedItem.Text.Trim().ToString() + "/" + DropDownListDay.SelectedItem.Text.Trim().ToString();
            //string dateString = date;
            //DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            //users.birthDate = dt;
            DateTime time = Convert.ToDateTime(date);
            users.birthDate = time;
            //users.birthDate = Convert.ToDateTime("1985-12-25"); 

            BLL.UsersManager users1 = new UsersManager();
           
            bool bo = users1.Add(users);
            if (bo == true)
            {
                string str = "username='" + txbUserName.Text.Trim() + "'";
                DataSet ds = users1.GetList(str);       
                Session["userID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                Session["username"] = txbUserName.Text.Trim();
                Response.Redirect("~/Users/Question.aspx");

            }
            else
            {
                Response.Write("<script language=javascript>alert('注册失败！')");
            }
        }
    }
    }
