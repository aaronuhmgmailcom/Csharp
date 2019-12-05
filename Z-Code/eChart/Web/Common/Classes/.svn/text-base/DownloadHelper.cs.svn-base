using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wistron.WiSync.Server.InputOutput;
using Wistron.WiSync.Server.Entity;
using Wistron.WiSync.Server.Management;

namespace Wistron.WiSync.Server.WiSyncPortal.Common.Classes
{
    public static class DownloadHelper
    {
        public static DirectoryInfo GetDownloadDirecotyInfo(int folderId, LoginInput login)
        {
            DirectoryManager dm = new DirectoryManager();
            string fullpath = dm.GetFullPath(folderId);
            DownloadNodeInfoInput dii = new DownloadNodeInfoInput();
            dii.FullPath = fullpath;
            dii.Login = login;
            dii.IsShowDelete = false;

            DownloadDirectoryInfoOutput di = dm.DownloadFullDirectoryInfo(dii);
            if (di != null & di.Data != null)
            {
                return di.Data;
            }
            else
            {
                return null;
            }
        }
    }
}