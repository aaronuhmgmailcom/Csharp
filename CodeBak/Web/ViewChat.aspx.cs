using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eChartProject.Web.Common;

namespace eChartProject.Web
{
    public partial class ViewChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string HTML = "Chat History:<br><br><table  border='0' width = 900px;><tr class='light'><td><b>DateTime</b></td><td ><b>Question</b></td><td ><b>Answer</b></td></tr>";

            if (SessionInfo.ClientUserInfo != null)
            {
                DataTable dt = SessionInfo.ClientUserInfo.ChattingHistory;
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HTML += "<tr class='dark'><td>" + dr["time"].ToString() + "</td><td >" + dr["question"].ToString() + "</td><td>" + dr["answer"].ToString() + "</td></tr>";
                    }
                }
            }
            HTML+="</table>";
            this.viewtable.InnerHtml = HTML;
        }
    }
}
