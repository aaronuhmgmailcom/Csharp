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
    public partial class EditRule : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        public static eChartProject.BLL.eChart.server_contents_folders Fbll
        {
            get { return new eChartProject.BLL.eChart.server_contents_folders(); }
        }
        public static eChartProject.BLL.eChart.server_contents_answers abll
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
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
                    string fieldname = Request.Form["fieldname"];
                    string id = Request.Form["id"];
                    string tablename = Request.Form["tablename"];
                    string selectid = Request.Form["selectid"];
                    if (selectid.Contains(Nodetype.message.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.message.ToString().Length);

                        TableEnt te = new TableEnt();
                        TableInfo ti = new TableInfo();
                        FieldInfo fi = new FieldInfo();
                        ti.Name = tablename;
                        fi.Name = fieldname;
                        te.TableInfo = ti;
                        te.FieldInfo = fi;

                        string result = "";
                        result = XmlSerialization<TableEnt>.Serialize(te);

                        eChartProject.Model.eChart.server_contents_rule scr = new eChartProject.Model.eChart.server_contents_rule();
                        scr.ID = int.Parse(id);
                        scr.MessageID = int.Parse(selectid);
                        scr.Rule1 = result;
                        RuleBll.Update(scr);

                        Response.Write("success");
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
