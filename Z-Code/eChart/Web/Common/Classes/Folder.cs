using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wistron.WiSync.Server.WiSyncPortal.Common.Classes
{
    public class Folder
    {
        private int folderId;
        private string folderName;

        public int FolderId
        {
            get { return folderId; }
            set { folderId = value; }
        }
        
        public string FolderName
        {
            get { return folderName; }
            set { folderName = value; }
        }
    }
}