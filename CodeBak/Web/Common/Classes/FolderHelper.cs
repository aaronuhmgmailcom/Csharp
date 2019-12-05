using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Wistron.WiSync.Server.Entity;

namespace Wistron.WiSync.Server.WiSyncPortal.Common.Classes
{

    public static class FolderHelper
    {
        private static JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();

        public static string GetJsonFolders(DirectoryInfo dir)
        {
            string jsonString = string.Empty;
            if (dir != null)
            {
                List<Folder> folders = new List<Folder>();
                List<DirectoryInfo> folderList = dir.Folders;
                folderList.Sort(new FolderNameComparer());
                foreach (var folderInfo in folderList)
                {
                    folders.Add(new Folder() {
                        FolderId = folderInfo.FolderInfo.FolderID.Value, 
                        FolderName = folderInfo.FolderInfo.FolderName
                    });
                }
                jsonString = JsonSerializer.Serialize(folders);
            }

            return jsonString;
        }
    }
}