using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using eChartProject.Web.Common;

namespace eChartProject.Web
{
    public partial class SaveSetting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string username = Request.Form["username"];
                    string pass = Request.Form["password"];
                    string country = Request.Form["country"];
                    string city = Request.Form["city"];
                    string email = Request.Form["email"];
                    string gender = Request.Form["gender"];
                    string age = Request.Form["age"];

                    eChartProject.Model.eChart.accounts_users model = new eChartProject.Model.eChart.accounts_users();

                    model.FundID = 1;
                    model.Username = username;
                    model.Password = Utils.MD5(pass.Trim());
                    model.Age = int.Parse(age);
                    model.City = city;
                    model.Country = country;
                    model.Email = email;
                    model.Gender = int.Parse(gender);
                    model.UserStatus = 1;

                    eChartProject.BLL.eChart.accounts_users bll = new eChartProject.BLL.eChart.accounts_users();
                    bll.Add(model);

                    Response.Write("success");
                    Response.End();
                }
                catch
                {
                   
                }
            } 
        }
    }
}
