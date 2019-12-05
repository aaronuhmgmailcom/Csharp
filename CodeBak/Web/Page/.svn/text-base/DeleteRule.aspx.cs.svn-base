using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;
using eChartProject.eChartManagement.Enum;
using eChartProject.eChartManagement.Entity;

namespace eChartProject.Web.Page
{
    public partial class DeleteRule : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_rule RuleBll
        {
            get { return new eChartProject.BLL.eChart.server_contents_rule(); }
        }
        public static eChartProject.BLL.eChart.server_contents_answers abll
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
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
                    string ruleid = Request.Form["ruleid"];
                    RuleBll.Delete(int.Parse(ruleid));

                    string selectid = Request.Form["selectid"];
                    string answer = Request.Form["answer"];

                    selectid = selectid.Remove(0, Nodetype.message.ToString().Length);

                    eChartProject.Model.eChart.server_contents_answers modelans = new eChartProject.Model.eChart.server_contents_answers();
                    DataSet ds = abll.GetList(" messageID=" + int.Parse(selectid));
                    //update the answer of message
                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
                        modelans.ID = int.Parse(ID);
                        modelans.Answer = answer.Trim();
                        modelans.MessageID = int.Parse(selectid);
                        modelans.isDeleted = 0;

                        abll.Update(modelans);
                    }
                    //if all rule deleted, update the message ispublic tag to true
                    eChartProject.Model.eChart.server_contents_rule modelrule = new eChartProject.Model.eChart.server_contents_rule();
                    DataSet dsRule = RuleBll.GetList(" messageID=" + int.Parse(selectid));

                    if (dsRule != null && dsRule.Tables != null && dsRule.Tables.Count > 0 && dsRule.Tables[0].Rows.Count == 0)
                    {
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.isPublic = 1;
                        model.ID = int.Parse(selectid);
                        bll.UpdateByIsPublic(model);
                    }

                    Response.Write("success");
                    Response.End();
                }
                catch
                {

                }
            }
        }
    }
}
