using System;
using System.Collections.Generic;
using System.Text;

namespace eChartProject.eChartManagement.Entity
{

    public class DirectoryInfo
    {
        /// <summary>
        /// 目录信息
        /// </summary>
        public FolderInfo FolderInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 目录下Msg列表
        /// </summary>
        public List<MsgInfo> Msgs
        {
            get;
            set;
        }

        /// <summary>
        /// 目录下Folder列表
        /// </summary>
        public List<DirectoryInfo> Folders
        {
            get;
            set;
        }
    }
}
