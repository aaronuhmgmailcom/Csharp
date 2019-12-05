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
    public partial class GetDBTableFieldName : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_rule RuleBll
        {
            get { return new eChartProject.BLL.eChart.server_contents_rule(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string ruleid = Request.Form["ruleid"];

                    //Get Rule 
                    eChartProject.Model.eChart.server_contents_rule modelans = new eChartProject.Model.eChart.server_contents_rule();
                    DataSet ds = RuleBll.GetList(" ID=" + int.Parse(ruleid));

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string strRule = ds.Tables[0].Rows[0]["Rule1"].ToString();
                        TableEnt te = new TableEnt();
                        te = XmlSerialization<TableEnt>.DeSerialize(strRule);

                        strRule = te.TableInfo.Name + "&" + te.FieldInfo.Name;
                        Response.Write(strRule);
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
