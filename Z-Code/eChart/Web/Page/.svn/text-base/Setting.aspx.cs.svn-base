using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using eChartProject.Web.Common;
using System.Web.UI.HtmlControls;

namespace eChartProject.Web.Page
{
    public partial class Setting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set the Tab Tag to this tab when User click it 
                HtmlGenericControl control = Page.Master.FindControl("liSetting") as HtmlGenericControl;
                if (control != null)
                    control.Attributes["class"] = "current";


                string sa = Request.Form["username"];
                Response.Write(sa);
            } 
        }

       
    }
}
