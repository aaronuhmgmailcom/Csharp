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
    public partial class GetLearnMore : System.Web.UI.Page
    {
        public static eChartProject.BLL.eChart.server_contents_answers ansBLL
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
        public static eChartProject.BLL.eChart.server_contents_message msgBLL
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string uri = SessionInfo.ClientUserInfo.CurrentURI;
            if (string.IsNullOrEmpty(uri))
            {
                Response.Write("FAIL");
                Response.End();
            }
            else
            {
                Response.Write(GetLearnMORE(uri));
                Response.End();
            }


        }

        private string GetLearnMORE(string uri)
        {
            string OUTPUTHTML = string.Empty;

            string strWhere = " FOLDERID = (select folderid from server_contents_message where id= " + uri + ")";
            List<eChartProject.Model.eChart.server_contents_message> msgs = msgBLL.GetModelList(strWhere);

            if (msgs != null && msgs.Count > 0)
            {
                if (SessionInfo.ClientUserInfo.CurrentFolderID == msgs[0].FolderID) return "FAIL";
                for (int i = 0; i < (msgs.Count > 4 ? 5 : msgs.Count); i++)
                {
                    OUTPUTHTML += "<dd   style='text-align:left;margin-top:10px;margin-left:10px;' >";
                    OUTPUTHTML += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span><a href='#' id='" + msgs[i].ID + "' onclick=\"seggestClick('" + msgs[i].Question + "')\">" + msgs[i].Question + "</a></span>";
                    OUTPUTHTML += "</dd>";
                    
                }
                SessionInfo.ClientUserInfo.CurrentFolderID = msgs[0].FolderID; 
            }
            return OUTPUTHTML;
        }

    }
}
