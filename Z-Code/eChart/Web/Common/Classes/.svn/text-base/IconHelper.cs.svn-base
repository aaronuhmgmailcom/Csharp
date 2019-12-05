using System;
using System.Collections.Generic;
using System.Web;

namespace eChartProject.Web.Common
{
    public static class IconHelper
    {
        public static string GetFolderIcon(bool? isOnline)
        {
            string icon = string.Empty;

            switch (isOnline)
            {
                case false:
                    icon = Icons_Private.folder;
                    break;
                case true:
                    icon = Icons_Offline.folder;
                    break;
                default:
                    icon = Icons_Private.folder;
                    break;
            }

            return icon;
        }

        public static string GetFileIcon(bool? isOnline)
        {
            string icon = string.Empty;
            switch (isOnline)
            {
                case false:
                    icon = Icons_Private.msg;
                    break;
                case true:
                    icon = Icons_Offline.msg;
                    break;
                default:
                    icon = Icons_Private.msg;
                    break;
            }
            return icon;
        }

        public static string GetRootIcon()
        {
            string icon = string.Empty;
            icon = Icons_Private.root;
            return icon;
        }
     

    }
}