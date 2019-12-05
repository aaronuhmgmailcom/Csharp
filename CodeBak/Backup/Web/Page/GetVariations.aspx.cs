using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;
using eChartProject.eChartManagement.Enum;

namespace eChartProject.Web.Page
{
    public partial class GetVariations : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string selectid = Request.Form["selectid"];
                    string rowsJson = string.Empty;
                    if (selectid.Contains(Nodetype.message.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.message.ToString().Length);
                        //get answer
                        DataSet ds = bll.GetList(" RelatedID=" + int.Parse(selectid));
                        rowsJson = VariationsRowHelper.GetHtmlRows(ds);
                        Response.Write(rowsJson);
                        Response.End();
                    }
                }
                catch
                {

                }
            }
        }


    }
}
