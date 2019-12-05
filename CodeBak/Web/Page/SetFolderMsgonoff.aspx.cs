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
    public partial class SetFolderMsgonoff : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        public static eChartProject.BLL.eChart.server_contents_folders Fbll
        {
            get { return new eChartProject.BLL.eChart.server_contents_folders(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string onoroffstr = Request.Form["onoroff"];
                    int onoroff = 0;
                    string selectid = Request.Form["selectid"];
                    if (onoroffstr == "true") onoroff = 1;
                    else onoroff = 0;


                    if (selectid.Contains("folder"))
                    {
                        selectid = selectid.Remove(0, "folder".Length);
                        eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();

                        model.FolderID = int.Parse(selectid);
                        model.isOffline = onoroff;

                        Fbll.UpdateByIsOffline(model);

                        SetOnOfflineAllMessageInFolder(selectid,onoroff);

                        Response.Write("success");
                        Response.End();
                    }
                    else if (selectid.Contains("message"))
                    {
                        selectid = selectid.Remove(0, "message".Length);
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.ID = int.Parse(selectid);
                        model.isOffLine = onoroff;

                        bll.UpdateByIsoffline(model);
                        Response.Write("success");
                        Response.End();

                    }
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// set all message offline when user let a folder offline
        /// </summary>
        /// <param name="id"></param>
        /// <param name="onoroff"></param>
        /// <returns></returns>
        private bool SetOnOfflineAllMessageInFolder(string id,int onoroff)
        {
            eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();

            DataSet ds;
            ds = bll.GetList("FolderID = " + id + " ORDER BY SORTORDER DESC");

            if (ds != null & ds.Tables.Count != 0 & ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string msgid = dr["ID"].ToString();
                    model.ID = int.Parse(msgid);
                    model.isOffLine = onoroff;
                    bll.UpdateByIsoffline(model);
                }
            }

            return true;
        }

    }
}
