using System;
using System.Collections.Generic;
using System.Text;

namespace eChartProject.eChartManagement.Entity
{
    public class FolderInfo
    {
       
        /// <summary>
        /// FolderID
        /// </summary>
        public int FolderID
        {
            get;
            set;
        }
        /// <summary>
        /// ParentID
        /// </summary>
        public int ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// FolderName
        /// </summary>
        public string FolderName
        {
            get;
            set;
        }
        /// <summary>
        /// isDelete
        /// </summary>
        public bool IsDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// isOffline
        /// </summary>
        public bool isOffline
        {
            get;
            set;
        }


    }
}
