using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;
using eChartProject.eChartManagement.Enum;
using eChartProject.eChartManagement.Entity;
using System.Web.Security;

namespace eChartProject.Web
{
    public partial class ClientLogin : System.Web.UI.Page
    {
        public static eChartProject.BLL.eChart.fund FundBll
        {
            get { return new eChartProject.BLL.eChart.fund(); }
        }
        public static eChartProject.BLL.eChart.fundbankaccount FundBankAccountBll
        {
            get { return new eChartProject.BLL.eChart.fundbankaccount(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string username = Request.Form["id"];
                    string pswd = Request.Form["pass"];
                    bool persist = Request.Form["persist"].ToString()=="true"?true:false;

                    DoLogin(username, pswd,persist);
                 
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pswd"></param>
        private void DoLogin(string username, string pswd,bool persist)
        {
            string errMsg = string.Empty;
            string strWhere = " EmailAddress='" + username + "'" ;
            List<eChartProject.Model.eChart.fund> user = FundBll.GetModelList(strWhere);


            if (user != null && user.Count > 0)
            {
                ClientUserInfo clientUserInfo = new ClientUserInfo();
                clientUserInfo.Email = user[0].EmailAddress;
                clientUserInfo.FundID = user[0].ID;

                strWhere = " FundID=" + clientUserInfo.FundID + " and isclientadded=0  and FundBankAccountNo = '" + pswd + "'";
                List<eChartProject.Model.eChart.fundbankaccount> fundbank = FundBankAccountBll.GetModelList(strWhere);

                if (fundbank != null && fundbank.Count > 0)
                {
                    SessionInfo.ClientUserInfo = clientUserInfo;

                    FormsAuthentication.SetAuthCookie(clientUserInfo.FundID.ToString(), persist);
                    Response.Write("success");
                    Response.End();
                }
                else
                {
                    errMsg = "The email or the password is invalid.";
                    Response.Write(errMsg);
                    Response.End();
                }
            }
            else
            {
                errMsg = "The email or the password is invalid.";
                Response.Write(errMsg);
                Response.End();
            }
        }
    }
}
