using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using eChartProject.Web.Common;

namespace eChartProject.Web.Page
{
    public partial class Welcome : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl control = Page.Master.FindControl("liMonitorAndOp") as HtmlGenericControl;
            if (control != null)
                control.Attributes["class"] = "current";

        }
    }
}