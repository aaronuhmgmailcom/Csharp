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
    public partial class DeleteFolderMessage : BasePage
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
                    string selectid = Request.Form["selectid"];

                    if (selectid.Contains("folder"))
                    {
                        selectid = selectid.Remove(0, "folder".Length);
                        eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();
                        
                        model.FolderID = int.Parse(selectid);
                        //model.isDeleted = 0;

                        //Fbll.UpdateByIsDelete(model);
                        Fbll.Delete(model.FolderID);

                        DeleteAllMessageInFolder(selectid);

                        Response.Write("success");
                        Response.End();
                    }
                    else if (selectid.Contains("message"))
                    {
                        selectid = selectid.Remove(0, "message".Length);
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.ID = int.Parse(selectid);
                        //model.isDeleted = 0;
                        //bll.UpdateByIsdeleted(model);
                        if (UpdateSortOrderBelow(model.ID))
                        {
                            if (bll.Delete(model.ID))
                            {
                                //send answer to ROBORT INTERFACE
                                DataTable dt = new DataTable();
                                dt.Columns.Add("uri");
                                dt.Columns.Add("question");
                                dt.Columns.Add("answer");

                                dt.Rows.Add(model.ID,null ,null);
                                Robot.SAVETOROBOT(dt);

                            }
                        }
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
        /// Delete messages that in the folder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteAllMessageInFolder(string id)
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
                    //model.isDeleted = 0;
                    //bll.UpdateByIsdeleted(model);
                    bll.Delete(model.ID);
                }
            }
           
            return true;
        }
        /// <summary>
        /// Update sortOrder field that which message's sortorder is smaller than the deleted Message 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool UpdateSortOrderBelow(int id)
        {
            eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();

            DataSet ds;
            ds = bll.GetList("ID = " + id + " ORDER BY SORTORDER DESC");

            if (ds != null & ds.Tables.Count != 0 & ds.Tables[0].Rows.Count > 0)
            {
                int msgid =  int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                int order = int.Parse(ds.Tables[0].Rows[0]["sortOrder"].ToString());
                int folderid = int.Parse( ds.Tables[0].Rows[0]["FolderID"].ToString());

                DataSet dsRow;
                dsRow = bll.GetList("FolderID = " + folderid + " ORDER BY SORTORDER DESC");
                if (dsRow != null & dsRow.Tables.Count != 0 & dsRow.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsRow.Tables[0].Rows)
                    {
                        if(int.Parse(dr["sortOrder"].ToString())>order) 
                        {
                            model.ID = int.Parse(dr["ID"].ToString());
                            model.sortOrder = int.Parse(dr["sortOrder"].ToString())-1;
                            bll.UpdateBySortOrder(model);
                     
                        }
                    }
                }
            }

            return true;
        }
        
    }
}
