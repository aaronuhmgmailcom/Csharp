using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using eChartProject.Web.Common;
using System.Data;
using System.Configuration;
using eChartProject.eChartManagement.Entity;

namespace eChartProject.Web.Page
{
    public partial class Content : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HtmlGenericControl control = Page.Master.FindControl("liContent") as HtmlGenericControl;
                if (control != null)
                    control.Attributes["class"] = "current";
               
            }
        }

    }
}