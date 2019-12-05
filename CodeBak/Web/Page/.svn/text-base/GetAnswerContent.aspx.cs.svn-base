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
    public partial class GetAnswerContent : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_answers abll
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string selectid = Request.Form["selectid"];
                   
                    if (selectid.Contains(Nodetype.message.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.message.ToString().Length);
                       
                        //get answer
                        eChartProject.Model.eChart.server_contents_answers modelans = new eChartProject.Model.eChart.server_contents_answers();
                        DataSet ds = abll.GetList(" messageID=" + int.Parse(selectid));

                        if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            string strAnswer = ds.Tables[0].Rows[0]["Answer"].ToString();

                            Response.Write(strAnswer);
                            Response.End();
                        }
                    }
                }
                catch
                {

                }
            }
        }


    }
}
