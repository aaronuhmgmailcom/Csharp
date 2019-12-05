using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace eChartProject.Web.Common
{
    public static class SortOrderHelper
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        /// <summary>
        /// GetSortOrder
        /// </summary>
        /// <param name="folderid"></param>
        /// <returns></returns>
        public static int? GetSortOrder(int? folderid)
        {
            eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
            DataSet ds;
            ds = bll.GetList("FolderID = " + folderid + " ORDER BY SORTORDER DESC");

            if (ds != null & ds.Tables.Count != 0 & ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["sortorder"].ToString()) + 1;

            }
            else
            {
                return 0;
            }
        }


    }
}
