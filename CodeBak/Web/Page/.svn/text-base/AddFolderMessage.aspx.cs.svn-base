using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;

namespace eChartProject.Web.Page
{
    public partial class AddFolder : BasePage
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string foldername = Request.Form["foldername"];
                    string selectid = Request.Form["selectid"];
                    string message = Request.Form["message"];

                    if (selectid.Contains("root"))
                    {
                        selectid = selectid.Remove(0, "root".Length);

                        eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();

                        model.Foldername = foldername.Trim();
                        model.ParentID = int.Parse(selectid);
                        model.isDeleted = 1;
                        model.isOffline = 0;

                        Fbll.Add(model);

                        Response.Write("success");
                        Response.End();
                    }
                    else if (selectid.Contains("folder"))
                    {
                        selectid = selectid.Remove(0, "folder".Length);
                        //insert message
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();

                        model.Question = message.Trim();
                        model.FolderID = int.Parse(selectid);
                        model.isOffLine = 0;
                        model.isPublic = 1;
                        model.isVariations = 0;
                        model.RelatedID = 0;
                        model.sortOrder = SortOrderHelper.GetSortOrder(model.FolderID);
                        model.isDeleted = 1;

                        bll.Add(model);

                        //insert answer
                        eChartProject.Model.eChart.server_contents_answers ansmodel = new eChartProject.Model.eChart.server_contents_answers();
                        ansmodel.Answer = "";
                        ansmodel.MessageID = bll.GetMaxId()-1;
                        ansmodel.isDeleted = 0;
                        abll.Add(ansmodel);

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
