using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using eChartProject.Web.Common;
using System.Web.Security;
using eChartProject.eChartManagement.Enum;

namespace eChartProject.Web.Page
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = null;

                authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                FormsIdentity identity = new FormsIdentity(authTicket);


               
                string username = identity.Name;

                eChartProject.BLL.eChart.accounts_users bll = new eChartProject.BLL.eChart.accounts_users();
                string strWhere = "username='" + username + "'";
                List<eChartProject.Model.eChart.accounts_users> user = bll.GetModelList(strWhere);



                if (user != null && user.Count > 0)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.Email = user[0].Email;
                    userInfo.Password = user[0].Password;
                    userInfo.UserId = user[0].UserID;
                    userInfo.Age = (int)user[0].Age;
                    userInfo.City = user[0].City;
                    userInfo.Country = user[0].Country;
                    userInfo.UserName = username;
                    userInfo.UserStatus = (int)user[0].UserStatus;

                    SessionInfo.UserInfo = userInfo;

                    
                    Maticsoft.Common.MessageBox.Redirect(this, "Welcome.aspx");

                    txtPassword.Disabled = true;
                    txtEmail.Disabled = true;
                    
                }
            }
        }
        /// <summary>
        /// btnLoginClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ValidationSummary.Style["display"] = "none";
            string username = txtEmail.Value.Trim();
            string pswd = MD5AndSHA256Provider.MD5(txtPassword.Value.Trim());
            DoLogin(username, pswd);

            //StringBuilder sb = new StringBuilder("<script>window.location.href = 'Welcome.aspx';</script>");
            //Response.Write("<script>window.location.href = 'Welcome.aspx';</script>");
            //Page.RegisterStartupScript(this.ToString(), sb.ToString());
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pswd"></param>
        private void DoLogin(string username, string pswd)
        {
            string errMsg = string.Empty;
           
                eChartProject.BLL.eChart.accounts_users bll = new eChartProject.BLL.eChart.accounts_users();
                string strWhere = "username='"    + username + "' and password = '" +pswd+ "'";
                List<eChartProject.Model.eChart.accounts_users> user = bll.GetModelList(strWhere);


                if (user != null && user.Count > 0)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.Email = user[0].Email;
                    userInfo.Password = pswd;
                    userInfo.UserId = user[0].UserID;
                    userInfo.Age = (int)user[0].Age;
                    userInfo.City = user[0].City;
                    userInfo.Country = user[0].Country;
                    userInfo.UserName = username;
                    userInfo.UserStatus = (int)user[0].UserStatus;

                    SessionInfo.UserInfo = userInfo;

                    if (userInfo.UserStatus == (int)EnumUserStatus.Blocked)
                    {
                        errMsg = "Please activate your account in the email sent to you.";
                    }
                    FormsAuthentication.RedirectFromLoginPage(username, cbRemember.Checked);
                }
                else
                {
                    errMsg = "The email or the password is invalid.";

                }
             
                ValidationSummary.InnerText = errMsg;
                ValidationSummary.Style["display"] = "inline";
                txtPassword.Value = "";
            

        }

 

    }
}
