using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using eChartProject.Web.Common;
using System.Collections.Generic;

namespace eChartProject.Web
{
    public partial class Default : System.Web.UI.Page
    {
        public static eChartProject.BLL.eChart.fund FundBll
        {
            get { return new eChartProject.BLL.eChart.fund(); }
        }
        public static eChartProject.BLL.eChart.fundbankaccount FundBankAccountBll
        {
            get { return new eChartProject.BLL.eChart.fundbankaccount(); }
        }
        public static eChartProject.BLL.eChart.server_contents_message msgBLL
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        public static eChartProject.BLL.eChart.server_contents_folders folderBLL
        {
            get { return new eChartProject.BLL.eChart.server_contents_folders(); }
        }
        /// <summary>
        /// btnLoginOut Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            SessionInfo.Clear();
            lbtnLogout.Style["display"] = "none";

            btnLogin.Style["display"] = "inline";
            ddRemember.Style["display"] = "inline";


            ValidationSummary.Style["display"] = "none";
            PrivateValidation.Style["display"] = "none";

            //Server.Transfer("Login.aspx");
            //Response.Redirect("Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //display the Supporter's info
            eChartProject.BLL.eChart.accounts_users bll = new eChartProject.BLL.eChart.accounts_users();
            string strWhere = " 1=1 order by UserID desc";
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
                userInfo.UserName = user[0].Username;
                userInfo.UserStatus = (int)user[0].UserStatus;

                SessionInfo.UserInfo = userInfo;

                this.txtName.Value = userInfo.UserName;
                this.txtGender.Value = userInfo.Gender=="true"?"F":"M";
                this.txtCountry.Value=userInfo.Country;
                this.txtCity.Value = userInfo.City;
                this.txtAge.Value = userInfo.Age.ToString() +" yrs";
                TextName.InnerText = userInfo.UserName;
            }
            //GET CLIENT USER'S COOKIE INFORMATION
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = null;

                authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                FormsIdentity identity = new FormsIdentity(authTicket);

                string fundID = identity.Name;
                int outresult;
                if (int.TryParse(fundID, out outresult))
                {
                    strWhere = " ID=" + fundID;
                    List<eChartProject.Model.eChart.fund> user2 = FundBll.GetModelList(strWhere);


                    if (user != null && user.Count > 0)
                    {
                        ClientUserInfo clientUserInfo = new ClientUserInfo();
                        clientUserInfo.Email = user2[0].EmailAddress;
                        clientUserInfo.FundID = user2[0].ID;

                        strWhere = " FundID=" + clientUserInfo.FundID + " and isclientadded=0  ";
                        List<eChartProject.Model.eChart.fundbankaccount> fundbank = FundBankAccountBll.GetModelList(strWhere);

                        if (fundbank != null && fundbank.Count > 0)
                        {
                            clientUserInfo.Pswd = fundbank[0].FundBankAccountNo;
                            SessionInfo.ClientUserInfo = clientUserInfo;

                            txtEmail.Value = clientUserInfo.Email;
                            txtPassword.Attributes.Add("value ", clientUserInfo.Pswd);
                            btnLogin.Style["display"] = "none";
                            ddRemember.Style["display"] = "none";

                            lbtnLogout.Style["display"] = "inline";
                            ValidationSummary.Style["display"] = "none";
                            PrivateValidation.Style["display"] = "inline";
                        }
                        else
                        {
                            lbtnLogout.Style["display"] = "none";
                        }
                    }
                    else
                    {
                        lbtnLogout.Style["display"] = "none";
                    }
                }
                else
                {
                    lbtnLogout.Style["display"] = "none";
                }
            }
            else
            {
                lbtnLogout.Style["display"] = "none";
            }

            InitializeLearnMORE();
        }

        private void InitializeLearnMORE()
        {
            string strWhere = " PARENTID= 1 order by folderID ASC";
            List<eChartProject.Model.eChart.server_contents_folders> folders = folderBLL.GetModelList(strWhere);
            int demoFolderid = -1;
            string OUTPUTHTML = string.Empty;
            if (folders != null && folders.Count > 0)
            {
                demoFolderid = folders[0].FolderID;
                strWhere = " FOLDERID = " + demoFolderid;
                List<eChartProject.Model.eChart.server_contents_message> msgs = msgBLL.GetModelList(strWhere);

                if (msgs != null && msgs.Count > 0)
                {
                    for (int i = 0; i < (msgs.Count>4?5:msgs.Count);i++ )
                    {
                        OUTPUTHTML += "<dd   style='text-align:left;margin-top:10px;margin-left:10px;' >";
                        OUTPUTHTML += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span><a href='#' id='" + msgs[i].ID + "' onclick=\"seggestClick('" + msgs[i].Question + "')\">" + msgs[i].Question + "</a></span>";
                        OUTPUTHTML += "</dd>";
                    }
                    if (SessionInfo.ClientUserInfo == null) SessionInfo.ClientUserInfo = new ClientUserInfo();
                    SessionInfo.ClientUserInfo.CurrentFolderID = msgs[0].FolderID; 
                    learnMoreDL.InnerHtml = OUTPUTHTML;
                }
            }
        }
      
    }
}
