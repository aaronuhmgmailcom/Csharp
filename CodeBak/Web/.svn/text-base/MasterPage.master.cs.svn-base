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

namespace eChartProject.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        /// <summary>
        /// btnLoginOut Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            SessionInfo.Clear();
            //Server.Transfer("Login.aspx");
            Response.Redirect("/Page/Login.aspx");
        }

        public string _tabtitle = "";
        public string TabTitle
        {
            get
            {
                return _tabtitle;
            }
            set
            {
                _tabtitle = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
    }
}
