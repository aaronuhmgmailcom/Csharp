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
    public partial class MoveMsgUpDown : BasePage
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
                    string action = Request.Form["action"];
                    string selectid = Request.Form["selectid"];
                    
                    if (selectid.Contains("message"))
                    {
                        selectid = selectid.Remove(0, "message".Length);
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.ID = int.Parse(selectid);
                        model.sortOrder = managerMsgSortOrder(model.ID,action);

                        bll.UpdateBySortOrder(model);
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
        /// update current message's sort order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private int managerMsgSortOrder(int id,string action)
        {
            eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();

            DataSet ds;
            ds = bll.GetList("ID = " + id + " ORDER BY SORTORDER DESC");

            if (ds != null & ds.Tables.Count != 0 & ds.Tables[0].Rows.Count > 0)
            {
                int ifolderid = int.Parse(ds.Tables[0].Rows[0]["FolderID"].ToString());
                int iSortOrder = int.Parse(ds.Tables[0].Rows[0]["sortOrder"].ToString());

                //if(iSortOrder==0)return 0;
                return UpdateMsgOrderBefore(ifolderid, iSortOrder, action);
            }

            return 0;
        }
        /// <summary>
        /// update the other message's sortorder when a message move up or down 
        /// that they must in on foler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sortOrder"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private int UpdateMsgOrderBefore(int id, int sortOrder,string action)
        {
            eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();

            DataSet ds;
            int moveStep = 0;
            if (action == "up")
            {
                sortOrder--;
                moveStep = 1;
            }
            else
            {
                sortOrder++;
                moveStep = -1;
            }
            ds = bll.GetList("FolderID = " + id + " and SORTORDER =" + (sortOrder));
            if (sortOrder >= 0 && ds != null & ds.Tables.Count != 0 & ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["isDeleted"].ToString().ToUpper() == "FALSE" & ds.Tables[0].Rows[0]["isOffline"].ToString().ToUpper() == "TRUE")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    model.sortOrder = sortOrder+moveStep;
                    bll.UpdateBySortOrder(model);

                    UpdateMsgOrderBefore(id, sortOrder,action);
                }
                else
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    model.sortOrder = sortOrder + moveStep;
                    bll.UpdateBySortOrder(model);

                    return sortOrder;
                    //UpdateMsgOrderBefore(id, sortOrder);
                }
            }
            else 
            {
                sortOrder--;
                return sortOrder;
            }

            return 0;

        }

    }
}
