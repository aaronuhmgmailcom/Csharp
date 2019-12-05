using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using eChartProject.eChartManagement.Entity;
using System.Data;

namespace eChartProject.Web.Common
{
    public static class VariationsRowHelper
    {
        private static JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();

        public static string GetHtmlRows(DataSet ds)
        {
            string htmlString = string.Empty;

            if (ds != null)
            {
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<MsgInfo> msgList =new List<MsgInfo>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        MsgInfo mi = new MsgInfo();
                        mi.ID = int.Parse(dr["ID"].ToString());
                        mi.RelatedID = int.Parse(dr["RelatedID"].ToString());
                        mi.Question = dr["Question"].ToString();
                        mi.IsPublic = dr["IsPublic"].ToString().ToUpper()=="TRUE"?true:false;
                        mi.IsOffline = dr["IsOffline"].ToString().ToUpper() == "TRUE" ? true : false;
                        msgList.Add(mi);
                    }
                    List<VariarionsROW> rows = new List<VariarionsROW>();
                    rows.AddRange(GetMsgRowsByMsgList(msgList));

                    htmlString = JsonSerializer.Serialize(rows);
                }
            }

            return htmlString;
        }

        private static List<VariarionsROW> GetMsgRowsByMsgList(List<MsgInfo> msgList)
        {
            List<VariarionsROW> rows = new List<VariarionsROW>();
            if (msgList != null)
            {
                for (int i = 0; i < msgList.Count; i++)
                {
                    rows.Add(ConvertRowFromFileInfo(msgList[i]));
                }
            }
            return rows;
        }

        private static VariarionsROW ConvertRowFromFileInfo(MsgInfo msg)
        {
            VariarionsROW r = new VariarionsROW(msg.Question,
                msg.ID,
                1,
                msg.IsDeleted,
                msg.IsOffline
                );
            return r;
        }

       
    }

}