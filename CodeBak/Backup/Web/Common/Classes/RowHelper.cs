using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using eChartProject.eChartManagement.Entity;

namespace eChartProject.Web.Common
{
    public static class RowHelper
    {
        private static JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();

        public static string GetHtmlRows(DirectoryInfo dir)
        {
            string htmlString = string.Empty;

            if (dir != null)
            {
                List<DirectoryInfo> folderList = dir.Folders;
                List<MsgInfo> fileList = dir.Msgs;
                List<Row> rows = new List<Row>();
                rows= GetFolderRowsByFolderList(folderList);

                htmlString = JsonSerializer.Serialize(rows);
            }

            return htmlString;
        }

        private static List<Row> GetMsgRowsByMsgList(List<MsgInfo> msgList)
        {
            List<Row> rows = new List<Row>();
            if (msgList != null)
            {
                for (int i = 0; i < msgList.Count; i++)
                {
                    rows.Add(ConvertRowFromFileInfo(msgList[i]));
                }
            }
            return rows;
        }
        
        private static List<Row> GetFolderRowsByFolderList(List<DirectoryInfo> folderList)
        {
            List<Row> rows = new List<Row>();
            if (folderList != null)
            {
                for (int i = 0; i < folderList.Count; i++)
                {
                    rows.Add(ConvertRowFromFolderInfo(folderList[i]));
                }
            }
            return rows;
        }

        private static Row ConvertRowFromFileInfo(MsgInfo msg)
        {
            Row r = new Row(msg.Question,
                IconHelper.GetFileIcon(msg.IsOffline,msg.IsPublic),
                msg.ID,
                1,
                msg.IsDeleted,
                msg.IsOffline,
                null
                );
            return r;
        }

        private static Row ConvertRowFromFolderInfo(DirectoryInfo folder)
        {
            List<Row> rows = new List<Row>();
            if (folder.Folders != null && folder.Folders.Count > 0)
            {
                for (int i = 0; i < folder.Folders.Count; i++)
                {
                    Row r2 = new Row(folder.Folders[i].FolderInfo.FolderName,
                       IconHelper.GetFolderIcon(folder.Folders[i].FolderInfo.isOffline),
                       folder.Folders[i].FolderInfo.FolderID,
                       0,
                       folder.Folders[i].FolderInfo.IsDeleted,
                       folder.Folders[i].FolderInfo.isOffline,
                       null
                       );

                    Row r3 = new Row();
                    if (folder.Folders[i].Msgs != null && folder.Folders[i].Msgs.Count > 0)
                    {
                       r2.Rows = new List<Row>();
                       for (int j = 0; j < folder.Folders[i].Msgs.Count; j++)
                       {
                            r3 = ConvertRowFromFileInfo(folder.Folders[i].Msgs[j]);
                            r2.Rows.Add(r3);
                       }
                    }
                    rows.Add(r2);
                }
            }



            Row r = new Row(folder.FolderInfo.FolderName,
                IconHelper.GetRootIcon(),
                folder.FolderInfo.FolderID,
                0,
                folder.FolderInfo.IsDeleted,
                folder.FolderInfo.isOffline,
                rows
                );
            return r;
        }

       
        private static string FormatDateTime(DateTime? dt)
        {
            string result = string.Empty;
            if (dt != null)
                result = string.Format("{0:yyyy/MM/dd hh:mm tt}", dt.Value);
            return result;
        }
    }

}