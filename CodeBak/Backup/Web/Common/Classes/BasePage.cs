using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace eChartProject.Web.Common
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.Init += new EventHandler(BasePage_Init);
            this.Load += new EventHandler(BasePage_Load);
        }

        public const string PAGE_SELECT_CULTURE = "__Culture";

        public bool IsLogin
        {
            get
            {
                if (SessionInfo.UserInfo != null)
                    return true;
                else
                    return false;
            }
        }

        public void SetCurrentUICulture()
        {
            if (Request.Params[PAGE_SELECT_CULTURE] != null)
            {
                string culture = Request.Params[PAGE_SELECT_CULTURE].Trim();
                if (!string.IsNullOrEmpty(culture))
                {
                    try
                    {
                        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                    }
                    catch
                    {

                    }
                }
            }
        }

        public void ShowModalDialog(WebControl webCtrl, string url, int width, int height, bool IsPostBack)
        {
            webCtrl.Attributes["onclick"] = string.Format("var returnValue = showModalDialog('{0}','','dialogWidth={1}px;dialogHeight={2}px;status=no;help=no;scroll=no');return {3};", url, width, height, IsPostBack.ToString().ToLower());
        }

        public void ShowModalDialog(WebControl webCtrl, string url, int width, int height, char separator, bool IsPostBack, params Control[] getValueControls)
        {
            ShowModalDialog(webCtrl, url, width, height, false, IsPostBack, separator, getValueControls);
        }

        public void ShowModalDialog(WebControl webCtrl, string url, int width, int height, bool IsShowScroll, bool IsPostBack, char separator, params Control[] getValueControls)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("var flag = true;var returnValue = showModalDialog('{0}','','dialogWidth={1}px;dialogHeight={2}px;status=no;help=no;scroll={3}');if(typeof(returnValue) == 'undefined') return false;", url, width, height, IsShowScroll));
            sb.Append("if(returnValue.split('" + separator.ToString() + "').length != " + getValueControls.Length.ToString() + ") { flag = false; }");
            if (getValueControls.Length > 0)
            {
                for (int i = 0; i < getValueControls.Length; i++)
                {
                    if (getValueControls[i] is WebControl)
                    {
                        ((WebControl)getValueControls[i]).Attributes["readonly"] = "true";
                    }
                    sb.Append(string.Format("document.getElementById('{0}').value = flag ? returnValue.split('{1}')[{2}] : '';", getValueControls[i].ClientID, separator, i));
                }
            }
            sb.Append("return ").Append(IsPostBack.ToString().ToLower()).Append(";");
            webCtrl.Attributes["onclick"] = sb.ToString();
        }

        public void ShowModalDialog(string FunctionName, int width, int height, bool IsShowScroll, bool IsPostBack)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("function {0}(url) {{", FunctionName));
            sb.Append(string.Format("var returnValue = showModalDialog(url,'','dialogWidth={0}px;dialogHeight={1}px;status=no;help=no;{2}');", width, height, IsShowScroll ? "scroll=yes" : "scroll=no"));
            sb.Append("return ").Append(IsPostBack.ToString().ToLower()).Append("; }");
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), FunctionName, sb.ToString(), true);
        }

        public void ShowModalDialog(string FunctionName, string url, int width, int height, bool IsShowScroll, bool IsPostBack)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("function {0}() {{", FunctionName));
            sb.Append(string.Format("var returnValue = showModalDialog('{0}','','dialogWidth={1}px;dialogHeight={2}px;status=no;help=no;{3}');", url, width, height, IsShowScroll ? "scroll=yes" : "scroll=no"));
            sb.Append("return ").Append(IsPostBack.ToString().ToLower()).Append("; }");
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), FunctionName, sb.ToString(), true);
        }

        public void SetReturnValue(WebControl webCtrl, Control returnControl)
        {
            webCtrl.Attributes["onclick"] = string.Format("window.returnValue = document.getElementById('{0}').value;window.close();", returnControl.ClientID);
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            string curLang = SessionInfo.CurrentLang;
            if (string.IsNullOrEmpty(curLang) && Request.UserLanguages != null)
            {
                curLang = Request.UserLanguages[0];
                int i = curLang.IndexOf(";");
                if (i > 0)
                {
                    curLang = curLang.Substring(0, i);
                }
            }

            if (!string.IsNullOrEmpty(curLang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(curLang);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }

            SetCurrentUICulture();
        }

        protected override void OnError(EventArgs e)
        {

            System.Exception ex = Server.GetLastError();
            Server.ClearError();

            Session["exception"] = ex;

            Response.Redirect("Warning.aspx?ErrorPath=" + Request.RawUrl);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        void BasePage_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserInfo();
            }
        }

        void BasePage_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string culture = "";
                if (Request.Params[PAGE_SELECT_CULTURE] != null)
                {
                    culture = Request.Params[PAGE_SELECT_CULTURE].Trim();
                }
                ClientScript.RegisterHiddenField(PAGE_SELECT_CULTURE, culture);
            }
        }

        private void LoadUserInfo()
        {
            if (Context.Session[SessionInfo.USER_INFO] == null)
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Context.Request.Cookies[cookieName];
                if (authCookie == null)
                {
                    Response.Redirect("Login.aspx");
                }

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
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            if (SessionInfo.UserInfo != null)
            {
                if (!string.IsNullOrEmpty(SessionInfo.UserInfo.Email) & !string.IsNullOrEmpty(SessionInfo.UserInfo.Password))
                {
                    if (this.Master != null)
                    {
                        (this.Master.FindControl("email") as HtmlInputControl).Value = SessionInfo.UserInfo.Email;
                        (this.Master.FindControl("pswd") as HtmlInputControl).Value = SessionInfo.UserInfo.Password;
                        (this.Master.FindControl("lblName") as Label).Text = SessionInfo.UserInfo.UserName ;
                        
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        public bool AllowAnonymous
        {
            get
            {
                return ViewState["AllowAnonymous"] != null && (bool)ViewState["AllowAnonymous"];
            }
            set
            {
                ViewState["AllowAnonymous"] = value;
            }
        }
    }
}